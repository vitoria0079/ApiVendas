using ApiVendas.Data;
using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Repositorios
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public CategoriasRepositorio(SistemaVendasDbContext sistemaVendasdbContext)
        {
            _dbContext = sistemaVendasdbContext;
        }

        public async Task<Categorias> Adicionar(Categorias categorias)
        {
            await _dbContext.Categorias.AddAsync(categorias);
            await _dbContext.SaveChangesAsync();

            return categorias;
        }

        public async Task<bool> Apagar(int id)
        {
            Categorias categoriasPorId = await BuscarPorId(id);

            if (categoriasPorId == null)
            {
                throw new Exception($"Categorias do Id: {id} não foi encontrado.");
            }

            _dbContext.Categorias.Remove(categoriasPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Categorias> Atualizar(Categorias categorias, int id)
        {
            Categorias categoriasPorId = await BuscarPorId(id);

            if (categoriasPorId == null)
            {
                throw new Exception($"Categorias do Id: {id} não foi encontrado.");
            }

            categoriasPorId.Nome = categorias.Nome;
            categoriasPorId.Status = categorias.Status;
            _dbContext.Categorias.Update(categoriasPorId);
            await _dbContext.SaveChangesAsync();

            return categoriasPorId;
        }

        public async Task<Categorias> BuscarPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Categorias>> BuscarTodosCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}
