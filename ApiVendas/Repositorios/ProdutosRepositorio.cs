using ApiVendas.Data;
using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Repositorios
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public ProdutosRepositorio(SistemaVendasDbContext sistemaVendasdbContext)
        {
            _dbContext = sistemaVendasdbContext;
        }

        public async Task<Produtos> Adicionar(Produtos produtos)
        {
            await _dbContext.Produtos.AddAsync(produtos);
            await _dbContext.SaveChangesAsync();

            return produtos;
        }

        public async Task<bool> Apagar(int id)
        {
            Produtos produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Produtos> Atualizar(Produtos produto, int id)
        {
            Produtos produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto do Id: {id} não foi encontrado.");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.PrecoUnitario = produto.PrecoUnitario;

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<Produtos> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Produtos>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}
