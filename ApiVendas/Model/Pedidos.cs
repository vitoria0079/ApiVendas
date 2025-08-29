using ApiVendas.Enums;

namespace ApiVendas.Model
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        public string EnderecoEntrega { get; set; }
        public StatusPedidos Status { get; set; }
        public string MetodoPagamento { get; set; }
    }
}
