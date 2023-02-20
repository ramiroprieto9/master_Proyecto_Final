using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal static class VentaHandler
    {
        public static string cadenaConexion = "Data Source=LAPTOP-TLQMACS5;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Venta> TraerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Venta.Id FROM Venta\r\n  INNER JOIN Usuario\r\n  ON Venta.IdUsuario = Usuario.Id\r\n  WHERE Venta.IdUsuario = @idUsuario", conn);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Models.Venta productoTemporal = new Models.Venta();
                        productoTemporal.Id = reader.GetInt64(0);
                        ventas.Add(productoTemporal);
                    }

                }
                return ventas;
            }
        }

        public static long InsertarVenta(Venta venta)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Venta(Comentarios, IdUsuario) VALUES (@comentarios, @idUsuario); SELECT @@IDENTITY", conexion);
                comando.Parameters.AddWithValue("@comentarios", venta.Comentarios);
                comando.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);

                conexion.Open();
                return Convert.ToInt64(comando.ExecuteScalar());
            }
        }

        public static void CargarVenta(long idUsuario, List<Producto> productosVendidos)
        {
            Venta venta = new Venta();
            venta.Comentarios = ($"Venta realizada por usuario {idUsuario}");
            venta.IdUsuario = idUsuario;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                foreach (Producto item in productosVendidos)
                {
                    ProductoVendido producto_temporal = new ProductoVendido();

                    producto_temporal.Stock = item.Stock;
                    producto_temporal.IdProducto = item.Id;
                    producto_temporal.idVenta = InsertarVenta(venta);
                    ProductoVendidoHandler.InsertarProductoVendido(producto_temporal);

                }
            }

        }

    }
}
