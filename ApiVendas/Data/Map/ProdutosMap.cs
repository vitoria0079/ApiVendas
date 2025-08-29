using ApiVendas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiVendas.Data.Map
{
    public class ProdutosMap : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.PrecoUnitario).IsRequired();
        }
    }
}
