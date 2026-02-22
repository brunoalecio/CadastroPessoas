using CadastroPessoas.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UpdatePessoaFisicaCommandHandler
    : IRequestHandler<UpdatePessoaFisicaCommand, bool>
{
    private readonly IPessoaWriteRepository _writeRepository;
    private readonly IEventStoreRepository _eventStore;
    private readonly IMediator _mediator;
    private readonly IViaCepService _viaCepService;

    public UpdatePessoaFisicaCommandHandler(
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

    public async Task<bool> Handle(
        UpdatePessoaFisicaCommand request,
        CancellationToken cancellationToken)
    {
        var pessoa = await _writeRepository.GetByIdAsync(request.Id);

        if (pessoa == null)
            return false;

        pessoa.AtualizarNome(request.Nome);
        pessoa.AtualizarCPF(request.CPF);

        var enderecoViaCep = await _viaCepService.ConsultarCepAsync(request.Cep);

        pessoa.DefinirEndereco(enderecoViaCep);

        await _writeRepository.UpdateAsync(pessoa);

        var evento = new PessoaFisicaAtualizadaEvent(
            pessoa.Id,
            pessoa.Nome,
            pessoa.CPF
        );

        await _eventStore.SaveEventAsync(evento);
        await _mediator.Publish(evento);

        return true;
    }
}