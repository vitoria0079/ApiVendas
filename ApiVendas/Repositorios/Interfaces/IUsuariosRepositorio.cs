using ApiVendas.Model;

namespace ApiVendas.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<Usuarios>> BuscarTodosUsuarios();
        Task<Usuarios> BuscarPorId(int id);
        Task<Usuarios> Adicionar(Usuarios usuario);
        Task<Usuarios> Atualizar(Usuarios usuario, int id);
        Task<bool> Apagar(int id);
    }
}
