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

            // Llamamos a la lógica que creamos
            UsuarioLogica logica = new UsuarioLogica();
            var usuario = logica.Autenticar(dni, pass);

            if (usuario != null)
            {
                MessageBox.Show($"¡Bienvenido, {usuario.Nombre}!", "Acceso Correcto");

                // ESCONDER LOGIN Y ABRIR FORMULARIO SEGÚN ROL
                this.Hide();

                if (usuario.IdRol == 1) // Administrador
                {
                    new FrmAdmin().Show();
                }
                else if (usuario.IdRol == 2) // Vendedor/Cajero
                {
                    new FrmCaja().Show();
                }
                else if (usuario.IdRol == 3) // Cocinero
                {
                    new FrmCocina().Show();
                }
            }
            else
            {
                MessageBox.Show("DNI o Contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            FrmRegistro registro = new FrmRegistro();
            registro.ShowDialog(); // ShowDialog bloquea el login hasta que cierres el registro
        }
    }
}
