using ApiVendas.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutos>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutos> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProdutoId)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.PedidoId)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Quantidade)
                   .IsRequired();

            builder.Property(x => x.PrecoUnitario)
                   .IsRequired();
        }
    }
}
