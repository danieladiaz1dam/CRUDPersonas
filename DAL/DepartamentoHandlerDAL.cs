using ENT;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;

namespace DAL
{
    public class DepartamentoHandlerDAL
    {
        /// <summary>
        /// Devuelve una lista de departamentos de la base de datos
        /// </summary>
        public static List<Departamento> getDepartamentos()
        {
            List<Departamento> list = new List<Departamento>();
            Departamento d;
            SqlConnection? conn = null;
            SqlDataReader? reader = null;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Departamentos";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        d = new Departamento();

                        d.ID = (int)reader["ID"];
                        d.Nombre = (string)reader["Nombre"];

                        list.Add(d);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                reader?.Close();
                conn?.Close();
            }

            return list;
        }

        public static Departamento getDepartamento(int id)
        {
            Departamento d = new Departamento();

            SqlConnection? conn = null;
            SqlDataReader? reader = null;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "SELECT * FROM Departamentos WHERE ID = @id";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    if (reader.Read())
                    {
                        d.ID = (int)reader["ID"];
                        d.Nombre = (string)reader["Nombre"];
                    }
                }
            }
            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return d;
        }
    }
}
