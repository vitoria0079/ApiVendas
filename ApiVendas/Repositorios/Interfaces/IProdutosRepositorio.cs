using ApiVendas.Model;

namespace ApiVendas.Repositorios.Interfaces
{
    public interface IProdutosRepositorio
    {
        Task<List<Produtos>> BuscarTodosProdutos();
        Task<Produtos> BuscarPorId(int id);
        Task<Produtos> Adicionar(Produtos produtos);
        Task<Produtos> Atualizar(Produtos produtos, int id);
        Task<bool> Apagar(int id);
    }
}
