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
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.PessoasFisicas.FindAsync(id);

        if (entity != null)
        {
            _context.PessoasFisicas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<PessoaFisica?> GetByIdAsync(Guid id)
    {
        return await _context.PessoasFisicas.FindAsync(id);
    }

    public async Task UpdateAsync(PessoaFisica pessoa)
    {
        _context.PessoasFisicas.Update(pessoa);
        await _context.SaveChangesAsync();
    }
}
