using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmCaja : Form
    {
        private int _idUsuarioActual;
        private CajaLogica logica = new CajaLogica();
        private List<CajaLogica.ItemCarrito> carrito = new List<CajaLogica.ItemCarrito>();

        // CONSTRUCTOR PRINCIPAL: Recibe el ID del usuario logueado
        public FrmCaja(int idUsuario)
        {
            InitializeComponent();
            _idUsuarioActual = idUsuario;
            ConfigurarDiseño();
        }

        // CONSTRUCTOR POR DEFECTO: Llama al principal con un ID genérico (Para que no falle el diseñador)
        public FrmCaja() : this(1) { }

        private void ConfigurarDiseño()
        {
            dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.ReadOnly = true;
            lstResultados.Visible = false;
        }
        // ---------------------------------------------------------
        // 1. LÓGICA DE AGREGAR PRODUCTOS (Botones + Buscador)
        // ---------------------------------------------------------
        private void AgregarAlCarrito(CajaLogica.ItemCarrito producto)
        {
            var itemEnCarrito = carrito.FirstOrDefault(x => x.IdProducto == producto.IdProducto);

            if (itemEnCarrito != null)
                itemEnCarrito.Cantidad++;
            else
                carrito.Add(producto);

            ActualizarVista();

            // Limpiar búsqueda
            txtBuscar.Clear();
            lstResultados.Visible = false;
        }
        // --- MÉTODOS AUXILIARES ---

        private void ActualizarVista()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = carrito;

            if (dgvPedido.Columns["IdProducto"] != null) dgvPedido.Columns["IdProducto"].Visible = false;

            decimal total = carrito.Sum(x => x.Subtotal);
            lblTotal.Text = $"S/ {total:N2}";

            CalcularVuelto(); // Recalcular vuelto si cambia el total
        }
        private void CalcularVuelto()
        {
            decimal total = carrito.Sum(x => x.Subtotal);
            if (decimal.TryParse(txtMontoRecibido.Text, out decimal recibido))
            {
                decimal vuelto = recibido - total;
                lblVuelto.Text = $"Vuelto: S/ {vuelto:N2}";
                if (vuelto < 0) lblVuelto.ForeColor = Color.Red;
                else lblVuelto.ForeColor = Color.Green;
            }
        }

        // Este método conecta tus botones con la lógica
        private void BtnProducto_Click(string nombreExactoEnBD)
        {
            // Usamos la lógica para buscar el precio REAL en la base de datos
            var productoEncontrado = logica.BuscarProducto(nombreExactoEnBD);

            if (productoEncontrado != null)
            {
                AgregarAlCarrito(productoEncontrado);
            }
            else
            {
                MessageBox.Show($"Error: El producto '{nombreExactoEnBD}' no existe en la Base de Datos o está inactivo.", "Producto no encontrado");
            }
        }

        // --- BOTONES DE PRODUCTOS ---
        // Mantengo tus botones individuales tal como los creaste

        private void btnCafe_MouseClick(object sender, MouseEventArgs e)
        {
            BtnProducto_Click("Café Americano");
        }

        private void btnCroissant_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Croissant Mixto");
        }

        private void btnAmericano_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Café Americano");
        }

        private void btnCapuchino_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Capuchino");
        }

        private void btnLatte_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Latte");
        }

        private void btnMocaccino_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Mocaccino");
        }

        private void btnChocolateCaliente_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Chocolate Caliente");
        }

        private void btnInfusion_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Infusion");
        }

        private void btnJugo_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Jugo");
        }

        private void btnFrapuccino_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Frapuccino");
        }

        private void btnIcedCoffee_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Iced Coffee");
        }

        private void btnAguaMineral_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Aagua Mineral");
        }

        private void btnGaseosa_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Gaseosa");
        }

        private void btnSandwichPollo_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Sandwich de Pollo");
        }

        private void btnEmpanada_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Empanada");
        }

        private void btnMuffin_Click(object sender, EventArgs e)
        {
            BtnProducto_Click("Muffin");
        }

        // --- BOTONES DE CONTROL ---

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0) return;

            decimal total = carrito.Sum(x => x.Subtotal);
            decimal recibido = 0;
            decimal.TryParse(txtMontoRecibido.Text, out recibido);

            // Validación de Pago (RF-04)
            if (recibido < total)
            {
                MessageBox.Show($"Monto insuficiente. Faltan S/ {(total - recibido):N2}", "Error de Pago");
                return;
            }

            if (logica.RegistrarVenta(_idUsuarioActual, carrito, total, out string turno))
            {
                MessageBox.Show($"¡Venta Exitosa!\n\nTURNO: {turno}\nVuelto: S/ {(recibido - total):N2}", "Ticket Generado");
                carrito.Clear();
                txtMontoRecibido.Clear();
                ActualizarVista();
            }
            else
            {
                MessageBox.Show("Error de base de datos.", "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedido.CurrentRow != null)
            {
                var item = (CajaLogica.ItemCarrito)dgvPedido.CurrentRow.DataBoundItem;
                carrito.Remove(item);
                ActualizarVista();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length < 2)
            {
                lstResultados.Visible = false;
                return;
            }

            var resultados = logica.BuscarProductosPorCoincidencia(txtBuscar.Text);

            if (resultados.Count > 0)
            {
                lstResultados.DataSource = null;
                lstResultados.DataSource = resultados;
                lstResultados.DisplayMember = "Nombre"; // Qué mostrar en la lista
                lstResultados.Visible = true;
                lstResultados.BringToFront(); // Que salga encima de todo
            }
        }

        private void lstResultados_Click(object sender, EventArgs e)
        {
            if (lstResultados.SelectedItem != null)
            {
                var seleccion = (CajaLogica.ItemCarrito)lstResultados.SelectedItem;
                AgregarAlCarrito(seleccion);
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar toda la orden?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                carrito.Clear();
                txtMontoRecibido.Clear();
                ActualizarVista();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el usuario se cambia a la pestaña de entregas (índice 1)
            if (tabControl1.SelectedIndex == 1)
            {
                CargarPedidosListos();
            }
        }
        private void CargarPedidosListos()
        {
            dgvEntregas.DataSource = logica.ObtenerPedidosParaEntrega();
        }

        private void btnRefrescarEntregas_Click(object sender, EventArgs e)
        {
            CargarPedidosListos();
        }

        private void btnEntregarPedido_Click(object sender, EventArgs e)
        {
            if (dgvEntregas.CurrentRow != null)
            {
                int idPedido = Convert.ToInt32(dgvEntregas.CurrentRow.Cells["IdPedido"].Value);
                string turno = dgvEntregas.CurrentRow.Cells["NumeroTurno"].Value.ToString();

                if (MessageBox.Show($"¿Confirmar entrega del Turno {turno}?", "Entregar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (logica.ConfirmarEntrega(idPedido))
                    {
                        MessageBox.Show("Pedido entregado y ciclo cerrado.", "Éxito");
                        CargarPedidosListos(); // Refrescar lista
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pedido de la lista.", "Atención");
            }
        }
    }
}