using ApiVendas.Model;

namespace ApiVendas.Repositorios.Interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<Categorias>> BuscarTodosCategorias();
        Task<Categorias> BuscarPorId(int id);
        Task<Categorias> Adicionar(Categorias categorias);
        Task<Categorias> Atualizar(Categorias categorias, int id);
        Task<bool> Apagar(int id);
    }
}
