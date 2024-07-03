using Repository.Data.DetallePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.PedidoCompra
{
    public class PedidoCompraModel
    {
        public int IdPedido { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }
        public string FechaHora { get; set; }
        public decimal Total { get; set; }

        public List<DetallePedidoModel> detallePedido { get; set; }
    }
}
