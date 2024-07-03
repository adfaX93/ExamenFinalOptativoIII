using Npgsql;

namespace Repository.Data.ConfiguracionesDB
{
    public class ConnectionDB
    {
        private string conexionString;
        public ConnectionDB(string conexionString)
        {
            this.conexionString = conexionString;
        }
        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(conexionString);
                conn.Open();
                return conn;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}