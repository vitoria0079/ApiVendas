using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _produtosRepositorio;

        public ProdutosController(IProdutosRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> BuscarTodosProdutos()
        {
            List<Produtos> produtos = await _produtosRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> BuscarPorId(int id)
        {
            Produtos produto = await _produtosRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> Adicionar([FromBody] Produtos produtos)
        {
            Produtos novoProduto = await _produtosRepositorio.Adicionar(produtos);
            return Ok(novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtos>> Atualizar(int id, [FromBody] Produtos produtos)
        {
            produtos.Id = id;
            Produtos produtoAtualizado = await _produtosRepositorio.Atualizar(produtos, id);
            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _produtosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
