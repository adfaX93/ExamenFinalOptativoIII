using Dapper;
using Repository.Data.ConfiguracionesDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Sucursal
{
    public class SucursalRepository : ISucursalRepository
    {
        IDbConnection connection;
        public SucursalRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("INSERT INTO Sucursal(id_sucursal, descripcion, direccion, telefono, whatsapp, mail, estado) " +
                           "VALUES (@IdSucursal, @Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)", sucursalModel);
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM Sucursal WHERE id_sucursal = {id}");
            return true;
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return connection.Query<SucursalModel>("SELECT * FROM Sucursal");
        }

        public bool update(SucursalModel sucursalModel)
        {
            try
            {
                connection.Execute("UPDATE Sucursal SET " +
                           "descripcion = @Descripcion, " +
                           "direccion = @Direccion, " +
                           "telefono = @Telefono, " +
                           "whatsapp = @Whatsapp, " +
                           "mail = @Mail, " +
                           "estado = @Estado " +
                           "WHERE id_sucursal = @IdSucursal", sucursalModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
