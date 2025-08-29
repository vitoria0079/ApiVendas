using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
        {
            _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutos>>> BuscarTodosPedidosProdutos()
        {
            List<PedidosProdutos> pedidosProdutos = await _pedidosProdutosRepositorio.BuscarTodosPedidosProdutos();
            return Ok(pedidosProdutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosProdutos>> BuscarPorId(int id)
        {
            PedidosProdutos pedidosProduto = await _pedidosProdutosRepositorio.BuscarPorId(id);
            return Ok(pedidosProduto);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosProdutos>> Adicionar([FromBody] PedidosProdutos pedidosProdutos)
        {
            PedidosProdutos novoPedidosProduto = await _pedidosProdutosRepositorio.Adicionar(pedidosProdutos);
            return Ok(novoPedidosProduto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosProdutos>> Atualizar(int id, [FromBody] PedidosProdutos pedidosProdutos)
        {
            pedidosProdutos.Id = id;
            PedidosProdutos atualizado = await _pedidosProdutosRepositorio.Atualizar(pedidosProdutos, id);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _pedidosProdutosRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
