using Repository.Data.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ProductoService : IProductoRepository
    {
        private ProductoRepository productoRepository;
        public ProductoService(string connectionString)
        {
            productoRepository = new ProductoRepository(connectionString);
        }

        public bool add(ProductoModel productoModel)
        {
            return validarDatos(productoModel) ? productoRepository.add(productoModel) : throw new Exception("Error en la validacion de datos");
        }

        public bool delete(int id)
        {
            return id > 0 ? productoRepository.delete(id) : false;
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            return productoRepository.GetAll();
        }

        public bool update(ProductoModel productoModel)
        {
            return validarDatos(productoModel) ? productoRepository.update(productoModel) : throw new Exception("Error en la validacion de datos");
        }
        private bool validarDatos(ProductoModel producto)
        {
            if (producto == null)
                return false;
            if (string.IsNullOrEmpty(producto.Descripcion))
                return false;
            if (producto.CantidadMinima == null && producto.CantidadMinima < 1)
                return false;
            if (producto.CantidadStock == null)
                return false;
            if (producto.PrecioCompra == null)
                return false;
            if (producto.PrecioVenta == null)
                return false;
            if (string.IsNullOrEmpty(producto.Categoria))
                return false;
            if (string.IsNullOrEmpty(producto.Marca))
                return false;
            if (string.IsNullOrEmpty(producto.Estado))
                return false;
            if (producto.PrecioCompra <= 0 || producto.PrecioVenta <= 0)
                return false;

            return true;
        }
    }
}
