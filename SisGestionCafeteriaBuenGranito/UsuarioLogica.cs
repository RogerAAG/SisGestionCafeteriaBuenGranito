using System;
using System.Data;
using System.Data.SqlClient;

namespace SisGestionCafeteriaBuenGranito
{
    public class UsuarioLogica
    {
        // MODELO DE USUARIO (Para mover datos entre capas)
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public int IdRol { get; set; } // 1: Admin, 2: Vendedor, 3: Cocina
        }

        // MÉTODO 1: VALIDAR INGRESO (LOGIN)
        public Usuario Autenticar(string dni, string password)
        {
            Usuario usuarioEncontrado = null;

            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdUsuario, Nombre, IdRol FROM Usuarios WHERE DNI = @dni AND Contrasena = @pass AND Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@pass", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Si encontró algo...
                    {
                        usuarioEncontrado = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nombre = reader["Nombre"].ToString(),
                            IdRol = Convert.ToInt32(reader["IdRol"])
                        };
                    }
                }
            }
            return usuarioEncontrado; // Devuelve NULL si no existe
        }

        // MÉTODO 2: REGISTRAR NUEVO USUARIO
        public bool RegistrarUsuario(string nombre, string apellido, string dni, string pass, int idRol)
        {
            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    string query = "INSERT INTO Usuarios (Nombre, Apellido, DNI, Contrasena, IdRol) VALUES (@nom, @ape, @dni, @pass, @rol)";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@ape", apellido);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@rol", idRol);

                    cmd.ExecuteNonQuery(); // Ejecuta el INSERT
                    return true;
                }
            }
            catch (Exception)
            {
                return false; // Probablemente el DNI ya existe
            }
        }
    }
}