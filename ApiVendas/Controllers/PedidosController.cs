using ApiVendas.Model;
using ApiVendas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepositorio _pedidosRepositorio;

        public PedidosController(IPedidosRepositorio pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedidos>>> BuscarTodosPedidos()
        {
            List<Pedidos> pedidos = await _pedidosRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> BuscarPorId(int id)
        {
            Pedidos pedido = await _pedidosRepositorio.BuscarPorId(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedidos>> Adicionar([FromBody] Pedidos pedidos)
        {
            Pedidos novoPedido = await _pedidosRepositorio.Adicionar(pedidos);
            return Ok(novoPedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedidos>> Atualizar(int id, [FromBody] Pedidos pedidos)
        {
            pedidos.Id = id;
            Pedidos pedidoAtualizado = await _pedidosRepositorio.Atualizar(pedidos, id);
            return Ok(pedidoAtualizado);
        }
    }
}