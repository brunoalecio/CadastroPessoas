using CadastroPessoas.Application.Interfaces;
using MediatR;

public class CreatePessoaFisicaHandler : IRequestHandler<CreatePessoaFisicaCommand, Guid>
{
    private readonly IPessoaWriteRepository _writeRepository;
    private readonly IEventStoreRepository _eventStore;
    private readonly IMediator _mediator;
    private readonly IViaCepService _viaCepService;

    public CreatePessoaFisicaHandler(
        IPessoaWriteRepository writeRepository,
        IEventStoreRepository eventStore,
        IMediator mediator,
        IViaCepService viaCepService)
    {
        _writeRepository = writeRepository;
        _eventStore = eventStore;
        _mediator = mediator;
        _viaCepService = viaCepService;
    }

    public async Task<Guid> Handle(CreatePessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        var endereco = await _viaCepService.ConsultarCepAsync(request.Cep);

        var pessoa = new PessoaFisica(request.Nome, request.CPF);

        pessoa.DefinirEndereco(endereco);

        await _writeRepository.SaveAsync(pessoa);

        foreach (var domainEvent in pessoa.DomainEvents)
        {
            await _eventStore.SaveEventAsync(domainEvent);
            await _mediator.Publish(domainEvent);
        }

        pessoa.ClearDomainEvents();

        return pessoa.Id;
    }
}