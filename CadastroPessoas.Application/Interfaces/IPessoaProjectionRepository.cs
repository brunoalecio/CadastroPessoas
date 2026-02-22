using System.Threading.Tasks;

public interface IPessoaProjectionRepository
{
    Task DeleteAsync(Guid id);
}