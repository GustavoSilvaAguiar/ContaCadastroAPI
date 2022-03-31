using ContaCadastroAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaCadastroAPI.Data
{
    public class ContaParceiroConfiguration : IEntityTypeConfiguration<ContaParceiro>
    {
        public void Configure(EntityTypeBuilder<ContaParceiro> builder)
        {
            builder.HasOne(one => one.ContaCliente)
                .WithMany(many => many.ContasParceiro)
                .HasForeignKey(fk => fk.ContaClienteId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
