using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ConnectionDAL
    {
        private const string CONN_URL = "server=mokos-server.database.windows.net;database=MokosDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

        /// <summary>
        /// Se conecta a la base de datos
        /// </summary>
        public static SqlConnection connect()
        {
            SqlConnection _db_connection = new SqlConnection();

            try
            {
                // Crear conexion
                _db_connection = new SqlConnection(CONN_URL);
                // Conectar
                _db_connection.Open();
            }
            catch
            {
                throw;
            }

            return _db_connection;
        }
    }
}
