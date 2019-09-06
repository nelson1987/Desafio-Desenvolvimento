using Desafio.Data.Mappings;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Desafio.Repository.Repositories
{
    public class DesafioContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DesafioContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (configuration.GetConnectionString("DesafioDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FundoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
        }

        public DbSet<Fundo> Fundo { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
