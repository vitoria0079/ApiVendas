using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> BuscarTodosUsuarios()
        {
            List<Usuarios> usuarios = await _usuariosRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> BuscarPorId(int id)
        {
            Usuarios usuario = await _usuariosRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> Adicionar([FromBody] Usuarios usuarios)
        {
            Usuarios usuario = await _usuariosRepositorio.Adicionar(usuarios);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuarios>> Atualizar(int id, [FromBody] Usuarios usuarios)
        {
            usuarios.Id = id;
            Usuarios usuario = await _usuariosRepositorio.Atualizar(usuarios, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> Apagar(int id)
        {
            bool apagado = await _usuariosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
