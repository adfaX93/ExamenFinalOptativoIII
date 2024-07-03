using Dapper;
using Repository.Data.ConfiguracionesDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Producto
{
    public class ProductoRepository : IProductoRepository
    {
        IDbConnection connection;
        public ProductoRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(ProductoModel productoModel)
        {
            try
            {
                connection.Execute("INSERT INTO Producto(descripcion, cantidad_minima, cantidad_stock, precio_compra, precio_venta, categoria, marca, estado) " +
                           "VALUES (@Descripcion, @CantidadMinima, @CantidadStock, @PrecioCompra, @PrecioVenta, @Categoria, @Marca, @Estado)", productoModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Producto WHERE id_producto = {id}");
            return true;
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            return connection.Query<ProductoModel>("SELECT * FROM Producto");
        }

        public bool update(ProductoModel productoModel)
        {
            try
            {
                connection.Execute("UPDATE Producto SET " +
                           "descripcion = @Descripcion, " +
                           "cantidad_minima = @CantidadMinima, " +
                           "cantidad_stock = @CantidadStock, " +
                           "precio_compra = @PrecioCompra, " +
                           "precio_venta = @PrecioVenta, " +
                           "categoria = @Categoria, " +
                           "marca = @Marca " +
                           "estado = @Estado " +
                           "WHERE id_producto = @IdProducto", productoModel);
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
