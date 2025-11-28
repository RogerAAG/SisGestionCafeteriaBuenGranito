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
            public string Apellido { get; set; }
            public int IdRol { get; set; } // 1: Admin, 2: Vendedor, 3: Cocina
        }

        // MÉTODO 1: VALIDAR INGRESO (LOGIN)
        public Usuario Autenticar(string dni, string password)
        {
            Usuario usuarioEncontrado = null;

            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdUsuario, Nombre, Apellido, IdRol FROM Usuarios WHERE DNI = @dni AND Contrasena = @pass AND Activo = 1";
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
                            Apellido = reader["Apellido"].ToString(),
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
        // --- MÉTODOS PARA CUS08 (GESTIÓN DE USUARIOS) ---

        // 1. Listar todos los usuarios (menos la propia contraseña por seguridad)
        public DataTable ObtenerUsuarios()
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = @"SELECT u.IdUsuario, u.Nombre, u.Apellido, u.DNI, 
                                r.NombreRol, u.Activo 
                         FROM Usuarios u
                         INNER JOIN Roles r ON u.IdRol = r.IdRol";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Editar Usuario (Cambiar rol o datos)
        public bool EditarUsuario(int id, string nom, string ape, string dni, int idRol, bool activo)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = @"UPDATE Usuarios SET 
                         Nombre=@nom, Apellido=@ape, DNI=@dni, IdRol=@rol, Activo=@act 
                         WHERE IdUsuario=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@ape", ape);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@rol", idRol);
                cmd.Parameters.AddWithValue("@act", activo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Resetear Contraseña (Opcional pero útil)
        public bool ResetearClave(int idUsuario, string nuevaClave)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Usuarios SET Contrasena = @pass WHERE IdUsuario = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.Parameters.AddWithValue("@pass", nuevaClave);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}