using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SisGestionCafeteriaBuenGranito
{
    public class AdminLogica
    {
        // --- 1. GESTIÓN DE PRODUCTOS (CUS06 / RF-13, RF-14) ---

        // Obtener todos los productos para llenar la grilla
        public DataTable ObtenerCatalogo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdProducto, NombreProducto, Precio, Categoria, Activo FROM Productos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Guardar Nuevo Producto (RF-13) o Editar (RF-14)
        public bool GuardarProducto(int id, string nombre, decimal precio, string categoria, bool activo)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query;
                if (id == 0) // Es NUEVO
                {
                    query = "INSERT INTO Productos (NombreProducto, Precio, Categoria, Activo) VALUES (@nom, @pre, @cat, @act)";
                }
                else // Es EDICIÓN
                {
                    query = "UPDATE Productos SET NombreProducto=@nom, Precio=@pre, Categoria=@cat, Activo=@act WHERE IdProducto=@id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters.AddWithValue("@pre", precio);
                cmd.Parameters.AddWithValue("@cat", categoria);
                cmd.Parameters.AddWithValue("@act", activo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // --- 2. REPORTES (CUS07 / RF-15) ---

        // Obtener ventas filtradas por fecha usando la VISTA de tu BD
        public DataTable ObtenerReporte(DateTime inicio, DateTime fin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // Usamos la Vista 'VistaHistorialVentas' que creamos en el script final
                string query = @"SELECT * FROM VistaHistorialVentas 
                                 WHERE FechaVenta >= @inicio AND FechaVenta <= @fin";

                SqlCommand cmd = new SqlCommand(query, con);
                // Ajustamos las horas para cubrir todo el día
                cmd.Parameters.AddWithValue("@inicio", inicio.Date);
                cmd.Parameters.AddWithValue("@fin", fin.Date.AddDays(1).AddSeconds(-1));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}