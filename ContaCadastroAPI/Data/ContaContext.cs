using ContaCadastroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaCadastroAPI.Data
{
    public class ContaContext : DbContext
    {
        

        public ContaContext(DbContextOptions<ContaContext> opt) : base(opt)
        {

        }

        public DbSet<ContaCliente> ContasCliente { get; set; }

        public DbSet<ContaParceiro> ContasParceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaParceiroConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
