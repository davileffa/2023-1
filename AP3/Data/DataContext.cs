using AP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AP3.Data
{
      public class DataContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=AP3.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais do modelo, se necessário
        }
    }
}
