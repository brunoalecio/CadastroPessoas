using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class PessoaFisicaAtualizadaProjectionHandler
    : INotificationHandler<PessoaFisicaAtualizadaEvent>
{
    private readonly IPessoaProjectionRepository _repository;

    public PessoaFisicaAtualizadaProjectionHandler(
        IPessoaProjectionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        PessoaFisicaAtualizadaEvent notification,
        CancellationToken cancellationToken)
    {
        var readModel = new PessoaReadModel
        {
            Id = notification.Id,
            Nome = notification.Nome,
            Documento = notification.CPF
        };

        await _repository.UpdateAsync(readModel);
    }
}