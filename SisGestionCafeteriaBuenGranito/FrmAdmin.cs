using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; // Necesario para exportar
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisGestionCafeteriaBuenGranito
{
    public partial class FrmAdmin : Form
    {
        AdminLogica logica = new AdminLogica();
        public FrmAdmin()
        {
            InitializeComponent();
        }
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

        
    }
}
