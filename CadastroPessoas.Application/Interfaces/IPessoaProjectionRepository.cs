using System.Threading.Tasks;

public interface IPessoaProjectionRepository
{
    Task DeleteAsync(Guid id);
    Task UpdateAsync(PessoaReadModel pessoa);
}