namespace ApiVendas.Model
{
    public class PedidosProdutos
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produtos Produto { get; set; }
        public int PedidoId { get; set; }
        public Pedidos Pedido { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

    }
}
