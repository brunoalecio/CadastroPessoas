using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class PessoaFisicaProjectionHandler
    : INotificationHandler<PessoaFisicaCriadaEvent>
{
    private readonly IPessoaReadRepository _readRepository;

    public PessoaFisicaProjectionHandler(IPessoaReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task Handle(PessoaFisicaCriadaEvent notification, CancellationToken cancellationToken)
    {
        var readModel = new PessoaReadModel
        {
            Id = notification.Id,
            Nome = notification.Nome,
            Documento = notification.CPF
        };

        await _readRepository.AddAsync(readModel);
    }
}