using ApiVendas.Data;
using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Repositorios
{
    public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public PedidosProdutosRepositorio(SistemaVendasDbContext sistemaVendasdbContext)
        {
            _dbContext = sistemaVendasdbContext;
        }

        public async Task<PedidosProdutos> Adicionar(PedidosProdutos pedidosProdutos)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosProdutos);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutos;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidosProdutos pedidosProdutosPorId = await BuscarPorId(id);

            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"PedidosProdutos com Id: {id} não foi encontrado.");
            }

            _dbContext.PedidosProdutos.Remove(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PedidosProdutos> Atualizar(PedidosProdutos pedidosProdutos, int id)
        {
            PedidosProdutos pedidosProdutosPorId = await BuscarPorId(id);

            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"PedidosProdutos com Id: {id} não foi encontrado.");
            }

            pedidosProdutosPorId.ProdutoId = pedidosProdutos.ProdutoId;
            pedidosProdutosPorId.PedidoId = pedidosProdutos.PedidoId;
            pedidosProdutosPorId.Quantidade = pedidosProdutos.Quantidade;
            pedidosProdutosPorId.PrecoUnitario = pedidosProdutos.PrecoUnitario;

            _dbContext.PedidosProdutos.Update(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();

            return pedidosProdutosPorId;
        }

        public async Task<PedidosProdutos> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosProdutos>> BuscarTodosPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }
    }
}

