using System.ComponentModel;

namespace ApiVendas.Enums
{
    public enum StatusPedidos
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Processando")]
        Processando = 2,
        [Description("Enviado")]
        Enviado = 3,
        [Description("Entregue")]
        Entregue = 4

    }
}
