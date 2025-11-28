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
using static SisGestionCafeteriaBuenGranito.UsuarioLogica;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmMenuPrincipal : Form
    {
        private UsuarioLogica.Usuario _usuarioActual;
        private bool esCierreSesion = false;
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
        public FrmMenuPrincipal(UsuarioLogica.Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            ConfigurarPerfil();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        private void ConfigurarPerfil()
        {
            lblBienvenida.Text = $"Bienvenid@, {_usuarioActual.Nombre}";

            // OPCIONAL: Puedes bloquear visualmente los botones aquí si prefieres
            // Ejemplo: si no es admin, btnIrAdmin.Enabled = false;
        }

        private void btnIrCaja_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.IdRol == 2 || _usuarioActual.IdRol == 1)
            {
                string nombreCompleto = $"{_usuarioActual.Nombre} {_usuarioActual.Apellido}";
                FrmCaja caja = new FrmCaja(_usuarioActual.IdUsuario, nombreCompleto);

                // --- TRUCO DE NAVEGACIÓN ---
                this.Hide(); // 1. Nos escondemos
                caja.FormClosed += (s, args) => this.Show(); // 2. Cuando la Caja se cierre, reaparecemos
                caja.Show();
                // ---------------------------
            }
            else
            {
                MessageBox.Show("Acceso denegado.\nNo tienes permisos de Vendedor.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIrCocina_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.IdRol == 3 || _usuarioActual.IdRol == 1)
            {
                string nombreCompleto = $"{_usuarioActual.Nombre} {_usuarioActual.Apellido}";

                // Instanciamos el formulario de Cocina
                FrmCocina cocina = new FrmCocina(nombreCompleto);

                // --- TRUCO DE NAVEGACIÓN ---
                this.Hide(); // 1. Ocultamos el Menú Principal

                // 2. Le decimos: "Cuando cierren la cocina, vuelve a aparecer tú"
                cocina.FormClosed += (s, args) => this.Show();

                cocina.Show(); // 3. Mostramos la Cocina
                               // ---------------------------
            }
            else
            {
                MessageBox.Show("Acceso denegado.\nSolo personal de Cocina puede acceder aquí.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIrAdmin_Click(object sender, EventArgs e)
        {
            if (_usuarioActual.IdRol == 1)
            {
                string nombreCompleto = $"{_usuarioActual.Nombre} {_usuarioActual.Apellido}";
                FrmAdmin admin = new FrmAdmin(nombreCompleto);

                // --- TRUCO DE NAVEGACIÓN ---
                this.Hide();
                admin.FormClosed += (s, args) => this.Show();
                admin.Show();
                // ---------------------------
            }
            else
            {
                MessageBox.Show("ACCESO RESTRINGIDO.\nSolo el Administrador puede ingresar a este módulo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            esCierreSesion = true;
            this.Close(); 
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (esCierreSesion)
            {
                // Si la bandera está arriba, abrimos el Login y NO matamos la app
                FrmLogin login = new FrmLogin();
                login.Show();
            }
            else
            {
                // Si cerraron con la X o el botón Salir, matamos todo
                Application.Exit();
            }
        }

        private void FrmMenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            esCierreSesion = false; 
            Application.Exit(); 
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
