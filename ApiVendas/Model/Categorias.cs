using ApiVendas.Enums;

namespace ApiVendas.Model
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategorias Status { get; set; }
    }
}
