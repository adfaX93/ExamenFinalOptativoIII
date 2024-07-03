using Dapper;
using Repository.Data.ConfiguracionesDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Proveedor
{
    public class ProveedorRepository : IProveedorRepository
    {
        IDbConnection connection;
        public ProveedorRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(ProveedorModel proveedorModel)
        {
            try
            {
                connection.Execute("INSERT INTO Proveedor(id_proveedor, razon_social, tipo_documento, numero_documento, direccion, mail, celular, estado) " +
                           "VALUES (@IdProveedor, @RazonSocial, @TipoDocumento, @NumeroDocumento, @Direccion, @Mail, @Celular, @Estado)", proveedorModel);
                return true;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Proveedor WHERE id_proveedor = {id}");
            return true;
        }

        public IEnumerable<ProveedorModel> GetAll()
        {
            return connection.Query<ProveedorModel>("SELECT * FROM Proveedor");
        }

        public bool update(ProveedorModel proveedorModel)
        {
            try
            {
                connection.Execute("UPDATE Proveedor SET " +
                           "razon_social = @RazonSocial, " +
                           "tipo_documento = @TipoDocumento, " +
                           "numero_documento = @NumeroDocumento, " +
                           "direccion = @Direccion, " +
                           "mail = @Mail, " +
                           "celular = @Celular " +
                           "estado = @Estado " +
                           "WHERE id_proveedor = @IdProveedor", proveedorModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
