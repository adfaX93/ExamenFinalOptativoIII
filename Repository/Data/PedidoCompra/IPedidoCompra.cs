using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.PedidoCompra
{
    public interface IPedidoCompra
    {
        bool add(PedidoCompraModel pedidoCompraModel);
        bool update(PedidoCompraModel pedidoCompraModel);
        bool delete(int id);
        PedidoCompraModel getById(int id);
        IEnumerable<PedidoCompraModel> GetAll();
    }
}
