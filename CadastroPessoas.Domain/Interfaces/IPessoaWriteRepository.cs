using System.Threading.Tasks;

public interface IPessoaWriteRepository
{
    Task SaveAsync(PessoaBase pessoa);
    Task DeleteAsync(Guid id);
    Task<PessoaFisica?> GetByIdAsync(Guid id);
    Task UpdateAsync(PessoaFisica pessoa);
}