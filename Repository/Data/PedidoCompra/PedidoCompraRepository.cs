using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.DetallePedido;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.PedidoCompra
{
    public class PedidoCompraRepository : IPedidoCompra
    {
        IDbConnection connection;
        public PedidoCompraRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(PedidoCompraModel pedidoCompraModel)
        {
            try
            {
                var queryPedidoCompra = @"INSERT INTO Pedido_Compra(id_proveedor, id_sucursal, fecha_hora, total)
                                        VALUES(@IdProveedor, @IdSucursal, @FechaHora, @Total);

                                        SELECT CAST(SCOPE_IDENTITY() as int);";
                var idPedidoCompra = connection.QuerySingle<int>(queryPedidoCompra,new
                {
                    pedidoCompraModel.IdProveedor,
                    pedidoCompraModel.IdSucursal,
                    pedidoCompraModel.FechaHora,
                    pedidoCompraModel.Total
                });

                foreach(var detalle in pedidoCompraModel.detallePedido)
                {
                    var queryDetalle = @"INSERT INTO Detalle_Pedido(id_pedido, id_producto, cantidad_pedido, subtotal)
                                            VALUES(@IdPedido, @IdProducto, @CantidadPedido, @Subtotal);";
                    connection.Execute(queryDetalle, new
                    {
                        idPedidoCompra = idPedidoCompra,
                        detalle.IdProducto,
                        detalle.CantidadPedido,
                        detalle.Subtotal,
                    });
                }
                return true;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            try
            {
                connection.Execute("DELETE FROM Detalle_Pedido WHERE id_pedido = @Id", new { Id = id });
                connection.Execute("DELETE FROM Pedido_Compra WHERE id_pedido = @Id", new { Id = id });
                return true;
            }catch(Exception ex) { throw ex; }
        }

        public IEnumerable<PedidoCompraModel> GetAll()
        {
            try
            {
                var facturaDictionary = new Dictionary<int, PedidoCompraModel>();
                var query = @"SELECT
                            p.id_pedido, p.id_proveedor, p.id_sucursal, p.fecha_hora, p.total
                            FROM Pedido_Compra p
                            LEFT JOIN Detalle_Pedido d ON p.id_pedido = d.id_pedido";

                var facturas = connection.Query<PedidoCompraModel, DetallePedidoModel, PedidoCompraModel>(query, (pedidoCompra, detalle) =>
                {
                    if (!facturaDictionary.TryGetValue(pedidoCompra.IdPedido, out var currentPedidoCompra))
                    {
                        currentPedidoCompra = pedidoCompra;
                        currentPedidoCompra.detallePedido = new List<DetallePedidoModel>();
                        facturaDictionary.Add(currentPedidoCompra.IdPedido, currentPedidoCompra);
                    }

                    if (detalle != null)
                    {
                        currentPedidoCompra.detallePedido.Add(detalle);
                    }

                    return currentPedidoCompra;
                }, splitOn: "id_pedido").Distinct().ToList();

                return facturas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PedidoCompraModel getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(PedidoCompraModel pedidoCompraModel)
        {
            try
            {

                var queryFactura = @"UPDATE Pedido_Compra SET
                                    id_proveedor = @IdProveedor,
                                    id_sucursal = @IdSucursal,
                                    fecha_hora = @FechaHora,
                                    total = @Total
                                    WHERE id_pedido = @IdPedido;";

                connection.Execute(queryFactura, pedidoCompraModel);

                foreach (var detalle in pedidoCompraModel.detallePedido)
                {
                    var queryDetalle = @"UPDATE Detalle_Pedido SET
                                        id_pedido = @IdPedido,
                                        id_producto = @IdProducto,
                                        cantidad_pedido = @CantidadPedido,
                                        subtotal = @Subtotal 
                                        WHERE id_detalle_pedido = @IdDetallePedido;";
                    connection.Execute(queryDetalle, detalle);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
