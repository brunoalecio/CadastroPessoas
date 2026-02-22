using Microsoft.EntityFrameworkCore;
using CadastroPessoas.Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<PessoaFisica> PessoasFisicas { get; set; }
    public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
    public DbSet<EventStoreEntity> Events { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}