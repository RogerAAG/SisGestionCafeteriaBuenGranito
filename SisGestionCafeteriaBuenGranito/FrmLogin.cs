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
        public FrmLogin()
        {
            InitializeComponent();
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]// Dll para manipular la interfaz de usuario
        private extern static void ReleaseCapture();// Función para liberar la captura
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]// Dll para manipular la interfaz de usuario
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
