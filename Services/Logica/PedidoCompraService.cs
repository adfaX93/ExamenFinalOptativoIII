using Repository.Data.PedidoCompra;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class PedidoCompraService : IPedidoCompra
    {
        private PedidoCompraRepository pedidoCompraRepository;
        public PedidoCompraService(string connectionString)
        {
            pedidoCompraRepository = new PedidoCompraRepository(connectionString);
        }
        public bool add(PedidoCompraModel pedidoCompraModel)
        {
            return validarDatos(pedidoCompraModel) ? pedidoCompraRepository.add(pedidoCompraModel) : throw new Exception("Error al validar datos");
        }

        public bool delete(int id)
        {
            return id > 0 ? pedidoCompraRepository.delete(id) : false;
        }

        public IEnumerable<PedidoCompraModel> GetAll()
        {
           return pedidoCompraRepository.GetAll();
        }

        public PedidoCompraModel getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(PedidoCompraModel pedidoCompraModel)
        {
            return validarDatos(pedidoCompraModel) ? pedidoCompraRepository.update(pedidoCompraModel) : throw new Exception("Error en la validacion de datos");
        }
        public bool validarDatos(PedidoCompraModel pedido)
        {
            if (pedido == null)
                return false;

            return true;
        }
    }
}
