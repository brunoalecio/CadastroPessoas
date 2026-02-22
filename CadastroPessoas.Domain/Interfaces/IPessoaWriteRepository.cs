using System.Threading.Tasks;

public interface IPessoaWriteRepository
{
    Task SaveAsync(PessoaBase pessoa);
    Task DeleteAsync(Guid id);
}