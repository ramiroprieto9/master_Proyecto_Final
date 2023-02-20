

using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal static class UsuarioHandler
    {
        public static string cadenaConexion = "Data Source=LAPTOP-TLQMACS5;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Models.Usuario TraerUsuario(string nombreUsuario)
        {
            Models.Usuario usuario = new Models.Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario =@nombreUsuario", conn);
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                }
                return usuario;
            }
        }

        public static Models.Usuario InicioSesion(string nombreUsuario, string contraseña)
        {
            Models.Usuario usuario = new Models.Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contrasena", conn);
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contrasena", contraseña);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                }
                return usuario;
            }
        }


        public static int ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Usuario\r\n  SET \r\n  Nombre = @nombre,\r\n  Apellido = @apellido,\r\n  NombreUsuario = @nombreUsuario,\r\n  Contraseña = @contrasena,\r\n  Mail = @mail\r\n  WHERE Usuario.Id = @id", conexion);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);
                comando.Parameters.AddWithValue("@id", usuario.Id);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public static int CrearUsuario(Usuario usuario)
        {

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES(@nombre, @apellido, @nombreUsuario, @contrasena, @mail)", conexion);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public static int EliminarUsuario(long id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Usuario WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }
    }
}
