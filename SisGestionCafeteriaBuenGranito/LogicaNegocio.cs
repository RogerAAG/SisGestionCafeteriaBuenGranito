using System;
using System.Collections.Generic;
using System.Linq;

namespace SisGestionCafeteriaBuenGranito // Usamos el namespace de tu proyecto principal
{
    // Esta clase representa una línea del pedido (Ej: 2 Capuchinos)
    public class DetallePedido
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get { return Precio * Cantidad; } }
    }

    // Esta clase maneja toda la lógica de la venta (RF-01, RF-02, RF-03)
    public static class VentaActual
    {
        // Lista estática para que los datos sobrevivan mientras la app está abierta
        public static List<DetallePedido> ListaProductos = new List<DetallePedido>();

        // Contador para los turnos (A-01, A-02...)
        private static int contadorTurnos = 1;

        // Método para agregar producto (Lógica centralizada)
        public static void AgregarProducto(string nombre, decimal precio)
        {
            var item = ListaProductos.FirstOrDefault(x => x.Producto == nombre);
            if (item != null)
            {
                item.Cantidad++;
            }
            else
            {
                ListaProductos.Add(new DetallePedido { Producto = nombre, Precio = precio, Cantidad = 1 });
            }
        }

        // Método para calcular total (RF-02)
        public static decimal ObtenerTotal()
        {
            return ListaProductos.Sum(x => x.Subtotal);
        }

        // Método para generar turno (RF-03)
        public static string GenerarTurno()
        {
            string turno = $"A-{contadorTurnos.ToString("D2")}"; // Formato A-01
            contadorTurnos++;
            return turno;
        }

        // Limpiar después de cobrar
        public static void LimpiarVenta()
        {
            ListaProductos.Clear();
        }
    }
    public class PedidoConfirmado
    {
        public string NumeroTurno { get; set; }
        public List<DetallePedido> Items { get; set; }
        public DateTime HoraPedido { get; set; }
        public string Estado { get; set; } // "En Preparacion", "Listo"
    }

    // NUEVA CLASE: "Base de Datos" en memoria compartida entre Caja y Cocina
    public static class RepositorioPedidos
    {
        public static List<PedidoConfirmado> ColaCocina = new List<PedidoConfirmado>();

        public static void AgregarPedido(string turno, List<DetallePedido> productos)
        {
            // Creamos una copia de la lista para que no se borre al limpiar la caja
            var copiaProductos = new List<DetallePedido>(productos);

            ColaCocina.Add(new PedidoConfirmado
            {
                NumeroTurno = turno,
                Items = copiaProductos,
                HoraPedido = DateTime.Now,
                Estado = "En Preparacion"
            });
        }
    }
}