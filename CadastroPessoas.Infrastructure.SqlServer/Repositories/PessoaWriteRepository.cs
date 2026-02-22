using System.Threading.Tasks;
using CadastroPessoas.Domain.Entities;
using CadastroPessoas.Infrastructure.SqlServer;

public class PessoaWriteRepository : IPessoaWriteRepository
{
    private readonly AppDbContext _context;

    public PessoaWriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(PessoaBase pessoa)
    {
        _context.Add(pessoa);
        await _context.SaveChangesAsync();
    }
}
