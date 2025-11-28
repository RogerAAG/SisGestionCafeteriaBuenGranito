using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmLogin : Form
    {
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
        public FrmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private bool ValidarUsuario(string usuario, string clave)
        {
            // Por ahora usuario fijo. Luego aquí puedes validar contra una BD.
            // Ejemplo simple:
            return usuario == "admin" && clave == "1234";
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            UsuarioLogica logica = new UsuarioLogica();
            var usuario = logica.Autenticar(dni, pass);

            if (usuario != null)
            {
                // YA NO ABRIMOS LOS FORMS DIRECTOS AQUI
                // En su lugar, abrimos el Menú Principal y le pasamos el usuario

                FrmMenuPrincipal menu = new FrmMenuPrincipal(usuario);
                this.Hide(); // Ocultamos el login
                menu.Show(); // Mostramos el menú
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro();
            registro.ShowDialog(); // ShowDialog bloquea el login hasta que cierres el registro
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            if (txtDni.Text == "DNI")
            {
                txtDni.Text = "";
                txtDni.ForeColor = Color.Brown;
            }
        }
        private void txtDni_Leave(object sender, EventArgs e)
        {
            if(txtDni.Text == "")
            {
                txtDni.Text = "DNI";
                txtDni.ForeColor = Color.SandyBrown;
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Brown;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = Color.SandyBrown;
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
