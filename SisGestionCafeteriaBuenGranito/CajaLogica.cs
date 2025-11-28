using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SisGestionCafeteriaBuenGranito
{
    public class CajaLogica
    {
        // MODELO TEMPORAL PARA EL CARRITO
        public class ItemCarrito
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal { get { return Precio * Cantidad; } }
        }
        // 1. Ver lista de pedidos que Cocina ya marcó como "Listos"
        public System.Data.DataTable ObtenerPedidosParaEntrega()
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // Consultamos solo los que están listos para recoger
                string query = @"SELECT p.IdPedido, p.NumeroTurno, p.Total 
                         FROM Pedidos p
                         INNER JOIN Comandas c ON p.IdPedido = c.IdPedido
                         WHERE c.Estado = 'Listo'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Cerrar el ciclo (Cambiar estado a "Entregado")
        public bool ConfirmarEntrega(int idPedido)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Comandas SET Estado = 'Entregado', HoraEntregaCliente = GETDATE() WHERE IdPedido = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idPedido);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // BUSCADOR DINÁMICO (Cumple RF-01)
        public List<ItemCarrito> BuscarProductosPorCoincidencia(string texto)
        {
            var lista = new List<ItemCarrito>();
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // El operador LIKE %texto% busca coincidencias parciales
                string query = "SELECT IdProducto, NombreProducto, Precio FROM Productos WHERE NombreProducto LIKE @texto AND Activo = 1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new ItemCarrito
                        {
                            IdProducto = Convert.ToInt32(r["IdProducto"]),
                            Nombre = r["NombreProducto"].ToString(),
                            Precio = Convert.ToDecimal(r["Precio"]),
                            Cantidad = 1
                        });
                    }
                }
            }
            return lista;
        }

        // 1. OBTENER PRECIO REAL DE LA BD (Para que coincida con lo que puso el Admin)
        public ItemCarrito BuscarProducto(string nombreProducto)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // Buscamos por nombre exacto
                string query = "SELECT IdProducto, NombreProducto, Precio FROM Productos WHERE NombreProducto = @nom AND Activo = 1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nom", nombreProducto);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new ItemCarrito
                        {
                            IdProducto = Convert.ToInt32(r["IdProducto"]),
                            Nombre = r["NombreProducto"].ToString(),
                            Precio = Convert.ToDecimal(r["Precio"]),
                            Cantidad = 1
                        };
                    }
                }
            }
            return null; // No existe o está inactivo
        }

        // 2. REGISTRAR LA VENTA COMPLETA (Transacción ACID)
        public bool RegistrarVenta(int idUsuarioVendedor, List<ItemCarrito> carrito, decimal total, out string turnoGenerado)
        {
            turnoGenerado = "";
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                SqlTransaction transaction = con.BeginTransaction(); // ¡INICIO DE TRANSACCIÓN!

                try
                {
                    // A. INSERTAR CABECERA (PEDIDO)
                    // Generamos turno simple basado en fecha o ID. Aquí usaremos "A-" + Random para simplificar
                    // (En un sistema real usaríamos una secuencia SQL)
                    string turno = "A-" + new Random().Next(100, 999).ToString();

                    string queryPedido = @"INSERT INTO Pedidos (NumeroTurno, Total, IdUsuarioVendedor) 
                                           VALUES (@turno, @total, @idUser); 
                                           SELECT SCOPE_IDENTITY();"; // Recuperar el ID creado

                    SqlCommand cmdPedido = new SqlCommand(queryPedido, con, transaction);
                    cmdPedido.Parameters.AddWithValue("@turno", turno);
                    cmdPedido.Parameters.AddWithValue("@total", total);
                    cmdPedido.Parameters.AddWithValue("@idUser", idUsuarioVendedor);

                    int idPedido = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // B. INSERTAR DETALLES
                    foreach (var item in carrito)
                    {
                        string queryDetalle = @"INSERT INTO DetallesPedido (IdPedido, IdProducto, Cantidad, PrecioUnitario) 
                                                VALUES (@idPed, @idProd, @cant, @prec)";
                        SqlCommand cmdDet = new SqlCommand(queryDetalle, con, transaction);
                        cmdDet.Parameters.AddWithValue("@idPed", idPedido);
                        cmdDet.Parameters.AddWithValue("@idProd", item.IdProducto);
                        cmdDet.Parameters.AddWithValue("@cant", item.Cantidad);
                        cmdDet.Parameters.AddWithValue("@prec", item.Precio); // Precio congelado
                        cmdDet.ExecuteNonQuery();
                    }

                    // C. INSERTAR COMANDA (Para la cocina - RF-06)
                    string queryComanda = @"INSERT INTO Comandas (IdPedido, Estado, HoraEnvioCocina) 
                                            VALUES (@idPed, 'En Preparacion', GETDATE())";
                    SqlCommand cmdCom = new SqlCommand(queryComanda, con, transaction);
                    cmdCom.Parameters.AddWithValue("@idPed", idPedido);
                    cmdCom.ExecuteNonQuery();

                    transaction.Commit(); // ¡CONFIRMAR TODO!
                    turnoGenerado = turno;
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback(); // Si algo falla, deshacer todo
                    return false;
                }
            }
        }
    }
}