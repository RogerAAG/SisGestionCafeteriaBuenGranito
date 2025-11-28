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
    }
}
