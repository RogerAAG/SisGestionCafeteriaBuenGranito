using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisGestionCafeteriaBuenGranito.UsuarioLogica;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmMenuPrincipal : Form
    {
        private UsuarioLogica.Usuario _usuarioActual;
        public FrmMenuPrincipal(UsuarioLogica.Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            ConfigurarPerfil();
        }
        private void ConfigurarPerfil()
        {
            lblBienvenida.Text = $"Hola, {_usuarioActual.Nombre}";

            // OPCIONAL: Puedes bloquear visualmente los botones aquí si prefieres
            // Ejemplo: si no es admin, btnIrAdmin.Enabled = false;
        }

        private void btnIrCaja_Click(object sender, EventArgs e)
        {
            // Permitir acceso a Cajeros (Rol 2) y Admins (Rol 1)
            if (_usuarioActual.IdRol == 2 || _usuarioActual.IdRol == 1)
            {
                // Pasamos el ID del usuario a la caja para registrar ventas
                FrmCaja caja = new FrmCaja(_usuarioActual.IdUsuario);
                caja.Show();
            }
            else
            {
                MessageBox.Show("Acceso denegado.\nNo tienes permisos de Vendedor.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIrCocina_Click(object sender, EventArgs e)
        {
            // Permitir acceso a Cocineros (Rol 3) y Admins (Rol 1)
            if (_usuarioActual.IdRol == 3 || _usuarioActual.IdRol == 1)
            {
                FrmCocina cocina = new FrmCocina();
                cocina.Show();
            }
            else
            {
                MessageBox.Show("Acceso denegado.\nSolo personal de Cocina puede acceder aquí.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIrAdmin_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN ESTRICTA: SOLO ADMIN (Rol 1)
            if (_usuarioActual.IdRol == 1)
            {
                FrmAdmin admin = new FrmAdmin();
                admin.Show();
            }
            else
            {
                MessageBox.Show("ACCESO RESTRINGIDO.\nSolo el Administrador puede ingresar a este módulo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            // El FrmLogin debería estar esperando (ShowDialog) o puedes abrir uno nuevo
            new FrmLogin().Show();
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
