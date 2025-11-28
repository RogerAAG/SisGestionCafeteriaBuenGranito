using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmCaja : Form
    {
        private int _idUsuarioActual;
        private CajaLogica logica = new CajaLogica();
        private List<CajaLogica.ItemCarrito> carrito = new List<CajaLogica.ItemCarrito>();
        // 1. CÓDIGO PARA REDONDEAR BORDES (Llamada a DLL de Windows)
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        // 2. CÓDIGO PARA MOVER LA VENTANA SIN BARRA DE TÍTULO
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public FrmCaja(int idUsuario, string nombreCompleto)
        {
            InitializeComponent();
            _idUsuarioActual = idUsuario;
            lblUsuarioActual.Text = "Usuario: " + nombreCompleto;
            ConfigurarDiseño();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        public FrmCaja() : this(1, "Usuario Prueba") { }
        private void ConfigurarDiseño()
        {
            dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.ReadOnly = true;
            lstResultados.Visible = false;
        }
        private void AgregarAlCarrito(CajaLogica.ItemCarrito producto)
        {
            var itemEnCarrito = carrito.FirstOrDefault(x => x.IdProducto == producto.IdProducto);

            if (itemEnCarrito != null)
                itemEnCarrito.Cantidad++;
            else
                carrito.Add(producto);
            ActualizarVista();
            txtBuscar.Clear();
            lstResultados.Visible = false;
        }
        private void ActualizarVista()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = carrito;

            if (dgvPedido.Columns["IdProducto"] != null) dgvPedido.Columns["IdProducto"].Visible = false;

            decimal total = carrito.Sum(x => x.Subtotal);
            lblTotal.Text = $"S/ {total:N2}";

            CalcularVuelto();
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

        private void BtnProducto_Click(string nombreExactoEnBD)
        {
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

        private void btnCafe_MouseClick(object sender, MouseEventArgs e)
        {
            BtnProducto_Click("Espresso");
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
            BtnProducto_Click("Agua Mineral");
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

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0) return;

            decimal total = carrito.Sum(x => x.Subtotal);
            decimal recibido = 0;
            decimal.TryParse(txtMontoRecibido.Text, out recibido);

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
            cocina.Show();
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
                lstResultados.DisplayMember = "Nombre";
                lstResultados.Visible = true;
                lstResultados.BringToFront();
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
                        CargarPedidosListos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pedido de la lista.", "Atención");
            }
        }
    
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}