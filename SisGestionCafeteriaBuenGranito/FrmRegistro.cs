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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void CargarRoles()
        {
            // Llenamos el combo manualmente para simplificar
            cmbRol.Items.Add("Administrador"); // Índice 0
            cmbRol.Items.Add("Vendedor");      // Índice 1
            cmbRol.Items.Add("Cocinero");      // Índice 2
            cmbRol.SelectedIndex = 1; // Por defecto Vendedor
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("DNI y Contraseña son obligatorios.");
                return;
            }

            // Convertir la selección del Combo a ID de Base de Datos
            // Admin=1, Vendedor=2, Cocina=3
            // Como el Combo empieza en índice 0, sumamos 1.
            int idRol = cmbRol.SelectedIndex + 1;

            // Guardar en Base de Datos
            UsuarioLogica logica = new UsuarioLogica();
            bool exito = logica.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtDni.Text, txtPassword.Text, idRol);

            if (exito)
            {
                MessageBox.Show("Usuario registrado con éxito. Ahora puede iniciar sesión.");
                this.Close(); // Cerrar formulario de registro
            }
            else
            {
                MessageBox.Show("Error al registrar. Es posible que el DNI ya exista.");
            }
        
        }
    }
}
