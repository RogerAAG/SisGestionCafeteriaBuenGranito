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
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text;

            // Validación simple (por ahora hardcodeado, luego se puede conectar a BD)
            if (ValidarUsuario(usuario, clave))
            {
                // Login correcto
                MessageBox.Show("Bienvenido " + usuario, "Acceso concedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // oculto el login

                // Aquí luego usarás tu formulario principal, por ejemplo FrmPrincipal
                using (var frm = new FrmCaja())
                {
                    frm.ShowDialog(); // muestro la ventana principal
                }

                this.Close(); // cierro el login cuando se cierre el principal
            }
            else
            {
                // Login incorrecto
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
