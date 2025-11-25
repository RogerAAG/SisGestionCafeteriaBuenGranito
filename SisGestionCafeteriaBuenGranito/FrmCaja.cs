using System;
using System.Collections.Generic; // Necesario para usar Listas
using System.Drawing;
using System.Linq; // Necesario para sumar totales rapido
using System.Windows.Forms;

namespace GranitoPOS // Asegúrate que esto coincida con el nombre que elegiste
{
    public partial class FrmCaja : Form
    {
        // Lista temporal para manejar el pedido actual en memoria
        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        private int contadorTurno = 1; // Simulación de turnos

        public FrmCaja()
        {
            InitializeComponent();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            // Configuración básica para que la tabla se vea bien
            dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.AllowUserToAddRows = false; // Evitar la fila vacía al final
            dgvPedido.ReadOnly = true;
        }

        // CLASES SIMPLES (Modelos temporales para que funcione la lógica)
        // Luego moveremos esto a tu Capa de Entidades
        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
        }

        public class DetalleVenta
        {
            public int IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal { get { return PrecioUnitario * Cantidad; } }
        }

        // MÉTODO CENTRAL: Agregar producto al carrito
        private void AgregarProducto(string nombre, decimal precio)
        {
            // Buscamos si el producto ya existe en la lista
            var itemExistente = carrito.FirstOrDefault(p => p.NombreProducto == nombre);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++; // Si existe, aumentamos cantidad
            }
            else
            {
                // Si no existe, lo creamos
                carrito.Add(new DetalleVenta
                {
                    IdProducto = new Random().Next(1, 1000), // ID simulado
                    NombreProducto = nombre,
                    PrecioUnitario = precio,
                    Cantidad = 1
                });
            }

            ActualizarVista();
        }

        // Refrescar la tabla y el total
        private void ActualizarVista()
        {
            dgvPedido.DataSource = null; // Limpiar origen
            dgvPedido.DataSource = carrito; // Reasignar lista actualizada

            // Formato de columnas (Ocultar ID si quieres)
            if (dgvPedido.Columns["IdProducto"] != null)
                dgvPedido.Columns["IdProducto"].Visible = false;

            // Calcular Total
            decimal total = carrito.Sum(x => x.Subtotal);
            lblTotal.Text = $"S/ {total:N2}"; // Formato moneda
        }

        private void btnCafe_MouseClick(object sender, MouseEventArgs e)
        {
            AgregarProducto("Café Americano", 8.50m);
        }

        private void btnCroissant_Click(object sender, EventArgs e)
        {
            AgregarProducto("Croissant Mixto", 12.00m);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("No hay productos en la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí iría la lógica de guardar en Base de Datos MySQL
            // Por ahora, simulamos el éxito
            decimal totalPagar = carrito.Sum(x => x.Subtotal);
            string codigoTurno = $"A-{contadorTurno.ToString("D2")}"; // Genera A-01, A-02...

            MessageBox.Show($"¡Venta Registrada!\n\nTotal Cobrado: S/ {totalPagar:N2}\nTURNO GENERADO: {codigoTurno}\n\nEnviando a Cocina...",
                            "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar para el siguiente cliente
            carrito.Clear();
            ActualizarVista();
            contadorTurno++;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedido.CurrentRow != null)
            {
                // Obtener el objeto seleccionado
                var itemSeleccionado = (DetalleVenta)dgvPedido.CurrentRow.DataBoundItem;
                carrito.Remove(itemSeleccionado);
                ActualizarVista();
            }
        }

    }
}