using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmCocina : Form
    {
        public FrmCocina()
        {
            InitializeComponent();
        }
        private void CargarPedidos()
        {
            // Detenemos el pintado para que no parpadee
            flowLayoutPanelPedidos.SuspendLayout();

            // Limpiamos todo para volver a dibujar (método simple para prototipo)
            flowLayoutPanelPedidos.Controls.Clear();

            // Filtramos solo los que están "En Preparacion" (RF-04 y FIFO)
            var pedidosPendientes = RepositorioPedidos.ColaCocina
                                    .Where(x => x.Estado == "En Preparacion")
                                    .OrderBy(x => x.HoraPedido) // FIFO: El más viejo primero
                                    .ToList();

            foreach (var pedido in pedidosPendientes)
            {
                // Dibujamos una "Tarjeta" por cada pedido
                Panel tarjeta = CrearTarjetaPedido(pedido);
                flowLayoutPanelPedidos.Controls.Add(tarjeta);
            }

            flowLayoutPanelPedidos.ResumeLayout();
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
            string turno = btn.Tag.ToString();

            // Buscar el pedido en la "Base de Datos" y cambiar estado
            var pedido = RepositorioPedidos.ColaCocina.FirstOrDefault(p => p.NumeroTurno == turno);
            if (pedido != null)
            {
                pedido.Estado = "Listo"; // Esto hará que desaparezca de la cocina en el próximo Tick
                // Aquí podrías disparar un sonido o actualizar la Pantalla de Cliente
            }

            // Forzar recarga inmediata visual
            CargarPedidos();
        }
        private void FrmCocina_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }
    }
}
