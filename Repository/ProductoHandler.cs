﻿using Proyecto_Final.Models;
using System.Data.SqlClient;

namespace Proyecto_Final.Repository

{
    internal static class ProductoHandler
    {
        public static string cadenaConexion = "Data Source=LAPTOP-TLQMACS5;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Models.Producto> TraerProducto(long idUsuario)
        {
            List<Models.Producto> producto = new List<Models.Producto>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando2 = new SqlCommand($"SELECT * FROM Producto WHERE IdUsuario = @idUsuario ", conn);
                comando2.Parameters.AddWithValue("@idUsuario", idUsuario);


                conn.Open();
                SqlDataReader reader = comando2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Models.Producto productoTemporal = new Models.Producto();
                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Descripciones = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUsuario = reader.GetInt64(5);

                        producto.Add(productoTemporal);
                    }

                }
                return producto;

            }

        }


        public static Producto ObtenerProducto(long idProducto)
        {
            Producto producto = new Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT Producto.* FROM Producto\r\n  WHERE Producto.Id = @idProducto", conn);
                comando.Parameters.AddWithValue("@idProducto", idProducto);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);
                    
                }
                return producto;
            }
            
        }


        public static int CrearProducto (Producto producto)
        {

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES(@descripciones, @costo, @precioVenta, @stock, @idUsuario)", conexion);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public static int EliminarProducto (long id)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Producto WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

        public static int ModificarProducto (Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection (cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Producto\r\n  SET \r\n  Descripciones = @descripciones,\r\n  Costo = @costo,\r\n  PrecioVenta = @precioVenta,\r\n  Stock = @stock,\r\n  IdUsuario = @idUsuario\r\n  WHERE Producto.Id = @id", conexion);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                comando.Parameters.AddWithValue("@id", producto.Id);

                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }


        public static int UpdateStockProducto(long id, int cantidadVendidos)
        {
            Producto producto = ObtenerProducto(id);
            producto.Stock -= cantidadVendidos;
            return ModificarProducto(producto);
        }

    }
}














