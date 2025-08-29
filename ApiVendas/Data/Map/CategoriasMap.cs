using ApiVendas.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Data.Map
{
    public class CategoriasMap : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
