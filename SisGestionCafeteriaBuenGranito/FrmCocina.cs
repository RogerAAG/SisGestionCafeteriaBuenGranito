using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmCocina : Form
    {
        private CocinaLogica logica = new CocinaLogica();
        private Timer timerRefresco = new Timer();
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
        public FrmCocina(string nombreCompleto)
        {
            InitializeComponent();
            ConfigurarDiseño();
            lblUsuarioActual.Text = "Cocinero: " + nombreCompleto;
            ConfigurarTimer();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        public FrmCocina() : this("Chef Prueba") { }
        private void ConfigurarDiseño()
        {
            // Asegúrate de tener un FlowLayoutPanel llamado 'flowLayoutPanelPedidos' en el diseño
            // Si no lo tienes, agrégalo desde el cuadro de herramientas
            this.flowLayoutPanelPedidos.AutoScroll = true;
            this.Text = "KDS - Sistema de Cocina";
        }
        private void ConfigurarTimer()
        {
            timerRefresco.Interval = 5000; // Refrescar cada 5 segundos
            timerRefresco.Tick += TimerRefresco_Tick;
            timerRefresco.Start();
        }
        private void TimerRefresco_Tick(object sender, EventArgs e)
        {
            CargarComandas();
        }
        // CARGA Y PINTADO DE TARJETAS (RF-07)
        private void CargarComandas()
        {
            var pedidos = logica.ObtenerComandasPendientes();

            // Optimización simple: Si la cantidad de pedidos no cambió, no repintamos (evita parpadeo)
            if (pedidos.Count == flowLayoutPanelPedidos.Controls.Count) return;

            flowLayoutPanelPedidos.SuspendLayout(); // Congelar pantalla
            flowLayoutPanelPedidos.Controls.Clear();

            foreach (var pedido in pedidos)
            {
                Panel tarjeta = CrearTarjetaVisual(pedido);
                flowLayoutPanelPedidos.Controls.Add(tarjeta);
            }

            flowLayoutPanelPedidos.ResumeLayout(); // Descongelar
        }

        // DISEÑO DE LA TARJETA (Idéntico a tu informe visual)
        private Panel CrearTarjetaVisual(CocinaLogica.PedidoCocina pedido)
        {
            Panel pnl = new Panel
            {
                Size = new Size(250, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Encabezado Turno
            Label lblTurno = new Label
            {
                Text = $"TURNO: {pedido.NumeroTurno}",
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.Orange, // Color característico del informe
                ForeColor = Color.White
            };

            // Lista de Productos
            ListBox lstItems = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11),
                BorderStyle = BorderStyle.None,
                SelectionMode = SelectionMode.None
            };
            foreach (var item in pedido.Productos)
            {
                lstItems.Items.Add(item);
            }

            // Botón "Marcar Listo" (RF-08)
            Button btnListo = new Button
            {
                Text = "MARCAR LISTO",
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Tag = pedido.IdPedido // Guardamos el ID oculto en el botón
            };
            btnListo.Click += BtnListo_Click;

            pnl.Controls.Add(lstItems);
            pnl.Controls.Add(btnListo);
            pnl.Controls.Add(lblTurno);

            return pnl;
        }

        private Panel CrearTarjetaPedido(PedidoConfirmado pedido)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(250, 300); // Tamaño de la tarjeta
            pnl.BackColor = Color.LightYellow;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Margin = new Padding(10);

            // 1. Título (Turno)
            Label lblTurno = new Label();
            lblTurno.Text = $"TURNO: {pedido.NumeroTurno}";
            lblTurno.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTurno.Dock = DockStyle.Top;
            lblTurno.TextAlign = ContentAlignment.MiddleCenter;
            lblTurno.Height = 40;
            lblTurno.BackColor = Color.Orange;
            lblTurno.ForeColor = Color.White;

            // 2. Lista de productos
            ListBox lstProductos = new ListBox();
            lstProductos.Dock = DockStyle.Fill;
            lstProductos.Font = new Font("Consolas", 10);
            foreach (var item in pedido.Items)
            {
                lstProductos.Items.Add($"{item.Cantidad} x {item.Producto}");
            }

            // 3. Botón "Listo" (RF-05)
            Button btnListo = new Button();
            btnListo.Text = "MARCAR LISTO";
            btnListo.Dock = DockStyle.Bottom;
            btnListo.Height = 40;
            btnListo.BackColor = Color.Green;
            btnListo.ForeColor = Color.White;
            btnListo.Font = new Font("Arial", 10, FontStyle.Bold);

            // El truco: Guardamos el Turno en el botón para saber qué borrar luego
            btnListo.Tag = pedido.NumeroTurno;
            btnListo.Click += BtnListo_Click; // Conectamos el evento

            // Agregamos controles al panel
            pnl.Controls.Add(lstProductos);
            pnl.Controls.Add(btnListo);
            pnl.Controls.Add(lblTurno);

            return pnl;
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idPedido = (int)btn.Tag;

            if (logica.MarcarPedidoListo(idPedido))
            {
                // Forzamos recarga inmediata para que desaparezca
                flowLayoutPanelPedidos.Controls.Clear();
                CargarComandas();
            }
        }
        private void FrmCocina_Load(object sender, EventArgs e)
        {
            CargarComandas();
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
