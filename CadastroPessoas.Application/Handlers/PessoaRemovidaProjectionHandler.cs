using MediatR;
using CadastroPessoas.Domain.Events;
public class PessoaRemovidaProjectionHandler : INotificationHandler<PessoaRemovidaEvent>
{
    private readonly IPessoaProjectionRepository _repository;

    public PessoaRemovidaProjectionHandler(
        IPessoaProjectionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        PessoaRemovidaEvent notification,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(notification.Id);
    }
}