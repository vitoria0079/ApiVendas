using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;

        public CategoriasController(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categorias>>> BuscarTodasCategorias()
        {
            List<Categorias> categorias = await _categoriasRepositorio.BuscarTodosCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> BuscarPorId(int id)
        {
            Categorias categoria = await _categoriasRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> Adicionar([FromBody] Categorias categorias)
        {
            Categorias novaCategoria = await _categoriasRepositorio.Adicionar(categorias);
            return Ok(novaCategoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categorias>> Atualizar(int id, [FromBody] Categorias categorias)
        {
            categorias.Id = id;
            Categorias categoriaAtualizada = await _categoriasRepositorio.Atualizar(categorias, id);
            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
