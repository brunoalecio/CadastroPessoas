using Microsoft.EntityFrameworkCore;
using CadastroPessoas.Domain.Entities;

namespace CadastroPessoas.Infrastructure.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<EventStoreEntity> Events { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PessoaFisica>()
                .OwnsOne(p => p.Endereco);

            modelBuilder.Entity<PessoaJuridica>()
                .OwnsOne(p => p.Endereco);

            base.OnModelCreating(modelBuilder);
        }
    }
}