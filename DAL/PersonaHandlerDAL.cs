using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class PersonaHandlerDAL
    {
        /// <summary>
        /// Devuelve un listado de personas
        /// </summary>
        public static List<Persona> getPersonas()
        {
            List<Persona> list = new List<Persona>();
            Persona p;
            SqlConnection? conn = null;
            SqlDataReader? reader = null;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Personas ORDER BY Nombre, Apellidos";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Persona();

                        p.Id = (int)reader["ID"];
                        p.Nombre = (string)reader["Nombre"];
                        p.Apellidos = (string)reader["Apellidos"];
                        p.Telefono = (string)reader["Telefono"];
                        p.Direccion = (string)reader["Direccion"];
                        p.Foto = (string)reader["Foto"];
                        p.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        p.IDDepartamento = (int)reader["IDDepartamento"];

                        list.Add(p);
                    }
                }
            }
            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return list;
        }

        public static bool personExists(int id)
        {
            bool exists = false;



            return exists;
        }

        /// <summary>
        /// Busca una persona por id
        /// </summary>
        /// <param name="id">id de la persona</param>
        public static Persona getPersona(int id)
        {
            Persona p = new Persona();
            p.Id = -1;

            SqlConnection? conn = null;
            SqlDataReader? reader = null;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "SELECT * FROM Personas WHERE id = @id";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    if (reader.Read())
                    {
                        p.Id = (int)reader["ID"];
                        p.Nombre = (string)reader["Nombre"];
                        p.Apellidos = (string)reader["Apellidos"];
                        p.Telefono = (string)reader["Telefono"];
                        p.Direccion = (string)reader["Direccion"];
                        p.Foto = (string)reader["Foto"];
                        p.FechaNacimiento = (DateTime)reader["FechaNAcimiento"];
                        p.IDDepartamento = (int)reader["IDDepartamento"];
                    }
                }
            }
            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return p;
        }

        /// <summary>
        /// Busca una persona por id y añade el nombre del departamento
        /// post: devuelve una persona con id -1 si no se encuentra
        /// </summary>
        /// <param name="id">id de la persona</param>
        public static PersonaConDepartamento getPersonaConDepartamento(int id)
        {
            PersonaConDepartamento p = new PersonaConDepartamento();
            p.Id = -1;

            SqlConnection? conn = null;
            SqlDataReader? reader = null;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "SELECT P.*, D.Nombre 'NombreDepartamento' FROM Personas P INNER JOIN Departamentos D ON P.IDDepartamento = D.ID WHERE P.ID = @id";
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    if (reader.Read())
                    {
                        p.Id = (int)reader["ID"];
                        p.Nombre = (string)reader["Nombre"];
                        p.Apellidos = (string)reader["Apellidos"];
                        p.Telefono = (string)reader["Telefono"];
                        p.Direccion = (string)reader["Direccion"];
                        p.Foto = (string)reader["Foto"];
                        p.FechaNacimiento = (DateTime)reader["FechaNAcimiento"];
                        p.IDDepartamento = (int)reader["IDDepartamento"];
                        p.NombreDepartamento = (string)reader["NombreDepartamento"];
                    }
                }
            }
            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return p;
        }

        /// <summary>
        /// Manda una peticion para eliminar una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static int deletePersona(int id)
        {
            SqlConnection? conn = null;
            SqlDataReader? reader = null;
            int affectedRows = 0;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "DELETE FROM Personas WHERE id = @id";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }

            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return affectedRows;
        }

        /// <summary>
        /// Manda una peticion para agregar una persona a la base de datos
        /// </summary>
        /// <param name="p">Nueva Persona</param>
        public static int addPersona(Persona p)
        {
            SqlConnection? conn = null;
            SqlDataReader? reader = null;
            int affectedRows = 0;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", p.Apellidos);
                cmd.Parameters.AddWithValue("@tlf", p.Telefono);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@foto", p.Foto);
                cmd.Parameters.AddWithValue("@fechaNac", p.FechaNacimiento);
                cmd.Parameters.AddWithValue("@idDepart", p.IDDepartamento);

                cmd.CommandText = "INSERT INTO Personas(Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) VALUES (@nombre, @apellidos, @tlf, @direccion, @foto, @fechaNac, @idDepart)";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }

            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return affectedRows;
        }

        /// <summary>
        /// Manda una petición para actualizar una persona
        /// </summary>
        /// <param name="p"></param>
        public static int updatePersona(Persona p)
        {
            SqlConnection? conn = null;
            SqlDataReader? reader = null;
            int affectedRows = 0;

            try
            {
                conn = ConnectionDAL.connect();
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", p.Apellidos);
                cmd.Parameters.AddWithValue("@tlf", p.Telefono);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@foto", p.Foto);
                cmd.Parameters.AddWithValue("@fechaNac", p.FechaNacimiento);
                cmd.Parameters.AddWithValue("@idDepart", p.IDDepartamento);

                cmd.CommandText = "UPDATE Personas " +
                                  "SET Nombre = @nombre, " +
                                  "    Apellidos = @apellidos, " +
                                  "    Telefono = @tlf, " +
                                  "    Direccion = @direccion, " +
                                  "    Foto = @foto, " +
                                  "    FechaNacimiento = @fechaNac, " +
                                  "    IDDepartamento = @idDepart " +
                                  "WHERE ID = @id";
                cmd.Connection = conn;
                affectedRows = cmd.ExecuteNonQuery();
            }

            catch { throw; }
            finally { reader?.Close(); conn?.Close(); }

            return affectedRows;
        }
    }
}
