using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Necesario para exportar
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmAdmin : Form
    {
        private UsuarioLogica userLogica = new UsuarioLogica();
        AdminLogica logica = new AdminLogica();
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
        public FrmAdmin(string nombreCompleto)
        {
            InitializeComponent();
            lblUsuarioActual.Text = "Usuario: " + nombreCompleto;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        // Constructor vacío para el diseñador
        public FrmAdmin() : this("Admin Prueba") { }
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            CargarGrillaProductos(); // <--- ESTO ES LO IMPORTANTE

            // Configuraciones iniciales
            lblIdProducto.Text = "0";
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            chkActivo.Checked = true;
        }

        private void CargarGrillaProductos()
        {
            dgvProductos.DataSource = logica.ObtenerCatalogo();
        }
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = userLogica.ObtenerUsuarios();
        }
        private void CargarComboRoles()
        {
            if (cmbRolUser.Items.Count == 0)
            {
                cmbRolUser.Items.Add("Administrador"); // index 0 -> Rol 1
                cmbRolUser.Items.Add("Vendedor");      // index 1 -> Rol 2
                cmbRolUser.Items.Add("Cocinero");      // index 2 -> Rol 3
            }
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Nombre y Precio son obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            int id = int.Parse(lblIdProducto.Text); // 0 si es nuevo, ID si es edición

            bool exito = logica.GuardarProducto(id, txtNombreProducto.Text, precio, cmbCategoria.Text, chkActivo.Checked);

            if (exito)
            {
                MessageBox.Show("Producto guardado correctamente.");
                CargarGrillaProductos();
                btnLimpiar_Click(null, null); // Resetear campos
            }
            else
            {
                MessageBox.Show("Error al guardar.");
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
                lblIdProducto.Text = fila.Cells["IdProducto"].Value.ToString();
                txtNombreProducto.Text = fila.Cells["NombreProducto"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cmbCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblIdProducto.Text = "0";
            txtNombreProducto.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // RF-15: Filtrado por rango de fechas
            dgvReporte.DataSource = logica.ObtenerReporte(dtpInicio.Value, dtpFin.Value);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo Excel (CSV)|*.csv";
            sfd.FileName = "ReporteVentas_" + DateTime.Now.ToString("yyyyMMdd");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // 1. Escribir encabezados
                    string[] columnNames = new string[dgvReporte.Columns.Count];
                    for (int i = 0; i < dgvReporte.Columns.Count; i++)
                    {
                        columnNames[i] = dgvReporte.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", columnNames));

                    // 2. Escribir filas
                    foreach (DataGridViewRow row in dgvReporte.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] cells = new string[dgvReporte.Columns.Count];
                            for (int i = 0; i < dgvReporte.Columns.Count; i++)
                            {
                                // Manejo de nulos y comas dentro del texto
                                string valor = row.Cells[i].Value?.ToString() ?? "";
                                cells[i] = valor.Replace(",", " ");
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Reporte exportado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }
        private void FrmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Opcional: Volver al Login si cierran este form
            new FrmLogin().Show();
        }

        private void btnGuardarUser_Click(object sender, EventArgs e)
        {
            if (lblIdUserSeleccionado.Text == "0")
            {
                MessageBox.Show("Seleccione un usuario para editar.");
                return;
            }

            int id = int.Parse(lblIdUserSeleccionado.Text);
            int idRol = cmbRolUser.SelectedIndex + 1; // +1 porque BD empieza en 1

            bool exito = userLogica.EditarUsuario(id, txtNomUser.Text, txtApeUser.Text, txtDniUser.Text, idRol, chkUserActivo.Checked);

            if (exito)
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error al actualizar.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2) // Índice 2 es la pestaña "Usuarios"
            {
                CargarUsuarios();
                CargarComboRoles(); // Método simple para llenar el combo si no está lleno
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                lblIdUserSeleccionado.Text = row.Cells["IdUsuario"].Value.ToString();
                txtNomUser.Text = row.Cells["Nombre"].Value.ToString();
                txtApeUser.Text = row.Cells["Apellido"].Value.ToString();
                txtDniUser.Text = row.Cells["DNI"].Value.ToString();

                // Mapear nombre de rol a índice del combo
                string rol = row.Cells["NombreRol"].Value.ToString();
                if (rol == "Administrador") cmbRolUser.SelectedIndex = 0;
                if (rol == "Vendedor") cmbRolUser.SelectedIndex = 1;
                if (rol == "Cocinero") cmbRolUser.SelectedIndex = 2;

                chkUserActivo.Checked = Convert.ToBoolean(row.Cells["Activo"].Value);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado un usuario
            if (lblIdUserSeleccionado.Text == "0")
            {
                MessageBox.Show("Primero seleccione un usuario de la lista.");
                return;
            }

            // 2. Validar que haya escrito una contraseña nueva
            if (string.IsNullOrWhiteSpace(txtNuevaClave.Text))
            {
                MessageBox.Show("Por favor, escriba la nueva contraseña en el cuadro de texto.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaClave.Focus();
                return;
            }

            // 3. Confirmar acción (Opcional, pero recomendado)
            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de cambiar la contraseña al usuario seleccionado?", "Confirmar Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int id = int.Parse(lblIdUserSeleccionado.Text);
                string nuevaPass = txtNuevaClave.Text;

                // Llamamos a la lógica enviando lo que está en el TextBox
                if (userLogica.ResetearClave(id, nuevaPass))
                {
                    MessageBox.Show($"Contraseña actualizada correctamente.", "Éxito");
                    txtNuevaClave.Clear(); // Limpiamos el campo por seguridad
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.", "Error");
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizarVentana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
