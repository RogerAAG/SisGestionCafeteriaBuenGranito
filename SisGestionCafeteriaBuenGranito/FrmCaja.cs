using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Nota: Ya no necesitamos "using GranitoPOS" porque estamos en el mismo namespace

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmCaja : Form
    {
        public FrmCaja()
        {
            InitializeComponent();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.AllowUserToAddRows = false;
            dgvPedido.ReadOnly = true;
        }

        // --- MÉTODOS AUXILIARES ---

        private void ActualizarPantalla()
        {
            // 1. Refrescar la tabla usando la lista de la Lógica de Negocio
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = VentaActual.ListaProductos;

            // 2. Actualizar el Total (RF-02)
            lblTotal.Text = $"S/ {VentaActual.ObtenerTotal():N2}";
        }

        // Este método conecta tus botones con la lógica
        private void AgregarProducto(string nombre, decimal precio)
        {
            VentaActual.AgregarProducto(nombre, precio);
            ActualizarPantalla();
        }

        // --- BOTONES DE PRODUCTOS ---
        // Mantengo tus botones individuales tal como los creaste

        private void btnCafe_MouseClick(object sender, MouseEventArgs e)
        {
            AgregarProducto("Café Americano", 5.00m);
        }

        private void btnCroissant_Click(object sender, EventArgs e)
        {
            AgregarProducto("Croissant Mixto", 8.00m);
        }

        private void btnAmericano_Click(object sender, EventArgs e)
        {
            AgregarProducto("Café Americano", 6.00m);
        }

        private void btnCapuchino_Click(object sender, EventArgs e)
        {
            AgregarProducto("Capuchino", 8.50m);
        }

        private void btnLatte_Click(object sender, EventArgs e)
        {
            AgregarProducto("Café Latte", 9.00m);
        }

        private void btnMocaccino_Click(object sender, EventArgs e)
        {
            AgregarProducto("Mocaccino", 10.00m);
        }

        private void btnChocolateCaliente_Click(object sender, EventArgs e)
        {
            AgregarProducto("Chocolate Caliente", 9.50m);
        }

        private void btnInfusion_Click(object sender, EventArgs e)
        {
            AgregarProducto("Infusión", 4.00m);
        }

        private void btnJugo_Click(object sender, EventArgs e)
        {
            AgregarProducto("Jugo de Fruta", 7.00m);
        }

        private void btnFrapuccino_Click(object sender, EventArgs e)
        {
            AgregarProducto("Frapuccino", 12.00m);
        }

        private void btnIcedCoffee_Click(object sender, EventArgs e)
        {
            AgregarProducto("Iced Coffee", 8.00m);
        }

        private void btnAguaMineral_Click(object sender, EventArgs e)
        {
            AgregarProducto("Agua Mineral", 2.00m);
        }

        private void btnGaseosa_Click(object sender, EventArgs e)
        {
            AgregarProducto("Gaseosa", 3.00m);
        }

        private void btnSandwichPollo_Click(object sender, EventArgs e)
        {
            AgregarProducto("Sandwich de Pollo", 12.00m);
        }

        private void btnEmpanada_Click(object sender, EventArgs e)
        {
            AgregarProducto("Empanada", 5.00m);
        }

        private void btnMuffin_Click(object sender, EventArgs e)
        {
            AgregarProducto("Muffin", 4.50m);
        }

        // --- BOTONES DE CONTROL ---

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (VentaActual.ListaProductos.Count == 0) return;

            decimal totalPagar = VentaActual.ObtenerTotal();
            string codigoTurno = VentaActual.GenerarTurno();

            // --- NUEVO: GUARDAR EN LA LISTA COMPARTIDA PARA COCINA ---
            RepositorioPedidos.AgregarPedido(codigoTurno, VentaActual.ListaProductos);
            // ---------------------------------------------------------

            MessageBox.Show($"Turno {codigoTurno} enviado a cocina.", "Éxito");

            VentaActual.LimpiarVenta();
            ActualizarPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedido.CurrentRow != null)
            {
                // Obtenemos el objeto seleccionado de la grilla
                var itemSeleccionado = (DetallePedido)dgvPedido.CurrentRow.DataBoundItem;

                // Lo borramos de la lógica principal
                VentaActual.ListaProductos.Remove(itemSeleccionado);

                // Refrescamos
                ActualizarPantalla();
            }
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
        }

        private void btnAbrirCocina_Click(object sender, EventArgs e)
        {
            FrmCocina cocina = new FrmCocina();
            cocina.Show(); // Usa Show() y no ShowDialog() para poder usar ambos al mismo tiempo
        }
    }
}