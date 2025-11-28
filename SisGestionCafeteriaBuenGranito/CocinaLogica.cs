using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SisGestionCafeteriaBuenGranito
{
    public class CocinaLogica
    {
        // MODELO DE DATOS PARA LA VISTA
        public class PedidoCocina
        {
            public int IdPedido { get; set; }
            public string NumeroTurno { get; set; }
            public DateTime HoraEnvio { get; set; }
            public List<string> Productos { get; set; } = new List<string>();
        }

        // 1. OBTENER PEDIDOS "EN PREPARACIÓN" (RF-07)
        public List<PedidoCocina> ObtenerComandasPendientes()
        {
            var lista = new List<PedidoCocina>();

            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // Unimos Comandas -> Pedidos -> Detalles -> Productos
                string query = @"
                    SELECT c.IdPedido, p.NumeroTurno, c.HoraEnvioCocina, 
                           prod.NombreProducto, det.Cantidad
                    FROM Comandas c
                    INNER JOIN Pedidos p ON c.IdPedido = p.IdPedido
                    INNER JOIN DetallesPedido det ON p.IdPedido = det.IdPedido
                    INNER JOIN Productos prod ON det.IdProducto = prod.IdProducto
                    WHERE c.Estado = 'En Preparacion'
                    ORDER BY c.HoraEnvioCocina ASC"; // FIFO (Lo más viejo primero)

                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int id = Convert.ToInt32(r["IdPedido"]);
                        string prodDesc = $"{r["Cantidad"]} x {r["NombreProducto"]}";

                        // Agrupar: Si el pedido ya está en la lista, solo agregamos el producto
                        var pedidoExistente = lista.Find(x => x.IdPedido == id);

                        if (pedidoExistente == null)
                        {
                            var nuevo = new PedidoCocina
                            {
                                IdPedido = id,
                                NumeroTurno = r["NumeroTurno"].ToString(),
                                HoraEnvio = Convert.ToDateTime(r["HoraEnvioCocina"])
                            };
                            nuevo.Productos.Add(prodDesc);
                            lista.Add(nuevo);
                        }
                        else
                        {
                            pedidoExistente.Productos.Add(prodDesc);
                        }
                    }
                }
            }
            return lista;
        }

        // 2. MARCAR COMO LISTO (RF-08)
        public bool MarcarPedidoListo(int idPedido)
        {
            using (SqlConnection con = ConexionDB.ObtenerConexion())
            {
                // Actualizamos Estado y HoraFin
                string query = "UPDATE Comandas SET Estado = 'Listo', HoraFinPreparacion = GETDATE() WHERE IdPedido = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idPedido);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}