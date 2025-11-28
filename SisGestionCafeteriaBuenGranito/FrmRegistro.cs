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
    public partial class FrmRegistro : Form
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
        public FrmRegistro()
        {
            InitializeComponent();
            CargarRoles();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
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
        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
            
        private void FrmRegistro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
