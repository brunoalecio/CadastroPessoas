using MediatR;
using CadastroPessoas.Domain.Events;

public class DeletePessoaCommandHandler
    : IRequestHandler<DeletePessoaCommand, bool>
{
    private readonly IPessoaWriteRepository _writeRepository;
    private readonly IEventStoreRepository _eventStore;
    private readonly IMediator _mediator;

    public DeletePessoaCommandHandler(
        IPessoaWriteRepository writeRepository,
        IEventStoreRepository eventStore,
        IMediator mediator)
    {
        _writeRepository = writeRepository;
        _eventStore = eventStore;
        _mediator = mediator;
    }

    public async Task<bool> Handle(
     DeletePessoaCommand request,
     CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);

        var evento = new PessoaRemovidaEvent(request.Id);

        await _eventStore.SaveEventAsync(evento);
        await _mediator.Publish(evento);

        return true;
    }
}