using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.DetallePedido
{
    public class DetallePedidoModel
    {
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int CantidadPedido { get; set; }
        public decimal Subtotal { get; set; }
    }
}
