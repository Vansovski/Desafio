using Invest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Invest.API.Data
{
    public class DataContext: DbContext
    {
        //Construtor do DataContext
        public DataContext(DbContextOptions<DataContext> options): base(options)
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
    }
}