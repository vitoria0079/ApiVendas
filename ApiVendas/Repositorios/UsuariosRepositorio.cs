using ApiVendas.Data;
using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly SistemaVendasDbContext _dbContext;

        public UsuariosRepositorio(SistemaVendasDbContext sistemaVendasdbContext)
        {
            _dbContext = sistemaVendasdbContext;
        }

        public async Task<Usuarios> Adicionar(Usuarios usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuarios usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do Id: {id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuarios> Atualizar(Usuarios usuario, int id)
        {
            Usuarios usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do Id: {id} não foi encontrado.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<Usuarios> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuarios>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
