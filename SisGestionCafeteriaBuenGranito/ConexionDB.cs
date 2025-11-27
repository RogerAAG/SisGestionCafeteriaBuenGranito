using System;
using System.Configuration; // Necesario para leer App.config
using System.Data.SqlClient; // Necesario para SQL Server

namespace SisGestionCafeteriaBuenGranito
{
    public class ConexionDB
    {
        // Leemos la cadena del archivo App.config
        private static string cadena = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();

        // Método para obtener la conexión lista para usar
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadena);
                conexion.Open(); // Intentamos abrirla
                return conexion;
            }
            catch (Exception ex)
            {
                // Si falla, lanzamos el error para saber qué pasó
                throw new Exception("Error al conectar con la Base de Datos: " + ex.Message);
            }
        }

        // Método para cerrar la conexión (Buenas prácticas)
        public static void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}