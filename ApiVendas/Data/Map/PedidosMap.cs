using ApiVendas.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Data.Map
{
    public class PedidosMap : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.MetodoPagamento).IsRequired();
        }
    }
}
