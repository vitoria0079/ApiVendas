using ApiVendas.Data.Map;
using ApiVendas.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Data
{
    public class SistemaVendasDbContext : DbContext
    {
        public SistemaVendasDbContext(DbContextOptions<SistemaVendasDbContext> options)
    : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<PedidosProdutos> PedidosProdutos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
