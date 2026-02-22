using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CadastroPessoas.Application.Interfaces;

public class GetPessoasQueryHandler
    : IRequestHandler<GetPessoasQuery, List<PessoaReadModel>>
{
    private readonly IPessoaReadRepository _repository;

    public GetPessoasQueryHandler(IPessoaReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PessoaReadModel>> Handle(
        GetPessoasQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}