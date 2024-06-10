using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
           .Property(e => e.Rua)
           .HasMaxLength(100);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .HasMaxLength(50);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .HasMaxLength(50);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .HasMaxLength(10);

            modelBuilder.Entity<Endereco>().HasData(
                new Endereco { EnderecoId = 1, Rua = "Rua A", Cidade = "Cidade A", Estado = "Estado A", CEP = "12345-678" },
                new Endereco { EnderecoId = 2, Rua = "Rua B", Cidade = "Cidade B", Estado = "Estado B", CEP = "23456-789" },
                new Endereco { EnderecoId = 3, Rua = "Rua C", Cidade = "Cidade C", Estado = "Estado C", CEP = "34567-890" }
            );

            // Configuração da entidade Cliente
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteId = 1, Nome = "João Silva", Email = "joao.silva@example.com", EnderecoId = 1 },
                new Cliente { ClienteId = 2, Nome = "Maria Souza", Email = "maria.souza@example.com", EnderecoId = 2 },
                new Cliente { ClienteId = 3, Nome = "Pedro Santos", Email = "pedro.santos@example.com", EnderecoId = 3 }
            );
        }
    }
}


