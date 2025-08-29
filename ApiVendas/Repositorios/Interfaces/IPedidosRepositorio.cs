using ApiVendas.Model;

namespace ApiVendas.Repositorios.Interfaces
{
    public interface IPedidosRepositorio
    {
        Task<List<Pedidos>> BuscarTodosPedidos();
        Task<Pedidos> BuscarPorId(int id);
        Task<Pedidos> Adicionar(Pedidos pedidos);
        Task<Pedidos> Atualizar(Pedidos pedidos, int id);
        Task<bool> Apagar(int id);
    }
}
