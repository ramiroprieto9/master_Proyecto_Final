using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository
{
    internal static class ProductoVendidoHandler
    {
        public static string cadenaConexion = "Data Source=LAPTOP-TLQMACS5;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Models.Producto> TraerProductosVendidos(long idUsuario)
        {
            List<Models.Producto> productoVendido = new List<Models.Producto>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM ProductoVendido\r\n  INNER JOIN Venta\r\n  ON Venta.Id = ProductoVendido.IdVenta\r\n  WHERE Venta.IdUsuario =@idUsuario", conn);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Models.Producto productoTemporal = ProductoHandler.ObtenerProducto(reader.GetInt64(0));


                        productoVendido.Add(productoTemporal);
                    }
                }
            }
            return productoVendido;
        }

        public static int EliminarProductosVendidos(long idProducto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM ProductoVendido WHERE IdProducto = @idProducto", conexion);
                comando.Parameters.AddWithValue("@idProducto", idProducto);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }

        }

        public static int InsertarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoHandler.UpdateStockProducto(productoVendido.IdProducto, productoVendido.Stock);
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES(@stock, @idProducto, @idVenta)", conexion);
                comando.Parameters.AddWithValue("@stock", productoVendido.Stock);
                comando.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                comando.Parameters.AddWithValue("@idVenta", productoVendido.idVenta);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }
    }
}
