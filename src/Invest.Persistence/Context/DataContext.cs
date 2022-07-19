using Invest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Invest.Persistence.Context
{
    public class InvestContext: DbContext
    {
        //Construtor do InvestContext
        public InvestContext(DbContextOptions<InvestContext> options): base(options)
        {
            
        }

        //Criação de tabelas no Banco de Dados
        public DbSet<Cotista> Cotistas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Default");
            }
        }

        //Regras de relação entre tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cotistas com muitas operções e Operação com um Cotista associado
            modelBuilder.Entity<Cotista>()
            .HasMany(cotista => cotista.Operacoes)
            .WithOne(operacao => operacao.Cotista);
        }
    }
}