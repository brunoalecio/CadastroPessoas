using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPessoaReadRepository
{
    Task<List<PessoaReadModel>> GetAllAsync();
    Task AddAsync(PessoaReadModel model);
}