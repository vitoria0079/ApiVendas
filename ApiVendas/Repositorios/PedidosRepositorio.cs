using ApiVendas.Data;
using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Repositorios
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public PedidosRepositorio(SistemaVendasDbContext sistemaVendasdbContext)
        {
            _dbContext = sistemaVendasdbContext;
        }

        public async Task<Pedidos> Adicionar(Pedidos pedidos)
        {
            await _dbContext.Pedidos.AddAsync(pedidos);
            await _dbContext.SaveChangesAsync();

            return pedidos;
        }

        public async Task<bool> Apagar(int id)
        {
            Pedidos pedidosPorId = await BuscarPorId(id);

            if (pedidosPorId == null)
            {
                throw new Exception($"Pedidos do Id: {id} não foi encontrado.");
            }

            _dbContext.Pedidos.Remove(pedidosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Pedidos> Atualizar(Pedidos pedidos, int id)
        {
            Pedidos pedidosPorId = await BuscarPorId(id);

            if (pedidosPorId == null)
            {
                throw new Exception($"Pedidos do Id: {id} não foi encontrado.");
            }

            pedidosPorId.UsuarioId = pedidos.UsuarioId;
            pedidosPorId.EnderecoEntrega = pedidos.EnderecoEntrega;
            pedidosPorId.Status = pedidos.Status;
            pedidosPorId.MetodoPagamento = pedidos.MetodoPagamento;

            _dbContext.Pedidos.Update(pedidosPorId);
            await _dbContext.SaveChangesAsync();

            return pedidosPorId;
        }

        public async Task<Pedidos> BuscarPorId(int id)
        {
            return await _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pedidos>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
    }
}
