namespace SisGestionCafeteriaBuenGranito
{
    partial class FrmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardarProducto = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtNomUser = new System.Windows.Forms.TextBox();
            this.txtApeUser = new System.Windows.Forms.TextBox();
            this.txtDniUser = new System.Windows.Forms.TextBox();
            this.cmbRolUser = new System.Windows.Forms.ComboBox();
            this.chkUserActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardarUser = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.lblIdUserSeleccionado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 446);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblIdProducto);
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnGuardarProducto);
            this.tabPage1.Controls.Add(this.chkActivo);
            this.tabPage1.Controls.Add(this.cmbCategoria);
            this.tabPage1.Controls.Add(this.txtPrecio);
            this.tabPage1.Controls.Add(this.txtNombreProducto);
            this.tabPage1.Controls.Add(this.dgvProductos);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(819, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gestión de Catálogo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(590, 32);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(0, 17);
            this.lblIdProducto.TabIndex = 8;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(566, 203);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 46);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardarProducto
            // 
            this.btnGuardarProducto.Location = new System.Drawing.Point(566, 317);
            this.btnGuardarProducto.Name = "btnGuardarProducto";
            this.btnGuardarProducto.Size = new System.Drawing.Size(180, 46);
            this.btnGuardarProducto.TabIndex = 6;
            this.btnGuardarProducto.Text = "GuardarProducto";
            this.btnGuardarProducto.UseVisualStyleBackColor = true;
            this.btnGuardarProducto.Click += new System.EventHandler(this.btnGuardarProducto_Click);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(613, 275);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(94, 21);
            this.chkActivo.TabIndex = 5;
            this.chkActivo.Text = "Disponible";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(542, 133);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(221, 25);
            this.cmbCategoria.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(542, 85);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(221, 23);
            this.txtPrecio.TabIndex = 3;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(542, 36);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(221, 23);
            this.txtNombreProducto.TabIndex = 2;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(8, 76);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(513, 335);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportar);
            this.tabPage2.Controls.Add(this.dgvReporte);
            this.tabPage2.Controls.Add(this.btnFiltrar);
            this.tabPage2.Controls.Add(this.dtpFin);
            this.tabPage2.Controls.Add(this.dtpInicio);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(819, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reporte de Ventas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(678, 331);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(123, 68);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(23, 79);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(640, 320);
            this.dgvReporte.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(472, 14);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(191, 51);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(239, 26);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 23);
            this.dtpFin.TabIndex = 1;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(6, 26);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 23);
            this.dtpInicio.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtNuevaClave);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.lblIdUserSeleccionado);
            this.tabPage3.Controls.Add(this.btnResetPass);
            this.tabPage3.Controls.Add(this.btnGuardarUser);
            this.tabPage3.Controls.Add(this.chkUserActivo);
            this.tabPage3.Controls.Add(this.cmbRolUser);
            this.tabPage3.Controls.Add(this.txtDniUser);
            this.tabPage3.Controls.Add(this.txtApeUser);
            this.tabPage3.Controls.Add(this.txtNomUser);
            this.tabPage3.Controls.Add(this.dgvUsuarios);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(819, 416);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Usuarios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(23, 30);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(297, 337);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // txtNomUser
            // 
            this.txtNomUser.Location = new System.Drawing.Point(366, 57);
            this.txtNomUser.Name = "txtNomUser";
            this.txtNomUser.Size = new System.Drawing.Size(160, 23);
            this.txtNomUser.TabIndex = 1;
            // 
            // txtApeUser
            // 
            this.txtApeUser.Location = new System.Drawing.Point(366, 101);
            this.txtApeUser.Name = "txtApeUser";
            this.txtApeUser.Size = new System.Drawing.Size(160, 23);
            this.txtApeUser.TabIndex = 2;
            // 
            // txtDniUser
            // 
            this.txtDniUser.Location = new System.Drawing.Point(366, 138);
            this.txtDniUser.Name = "txtDniUser";
            this.txtDniUser.Size = new System.Drawing.Size(160, 23);
            this.txtDniUser.TabIndex = 3;
            // 
            // cmbRolUser
            // 
            this.cmbRolUser.FormattingEnabled = true;
            this.cmbRolUser.Location = new System.Drawing.Point(366, 176);
            this.cmbRolUser.Name = "cmbRolUser";
            this.cmbRolUser.Size = new System.Drawing.Size(160, 25);
            this.cmbRolUser.TabIndex = 4;
            // 
            // chkUserActivo
            // 
            this.chkUserActivo.AutoSize = true;
            this.chkUserActivo.Location = new System.Drawing.Point(689, 30);
            this.chkUserActivo.Name = "chkUserActivo";
            this.chkUserActivo.Size = new System.Drawing.Size(122, 21);
            this.chkUserActivo.TabIndex = 5;
            this.chkUserActivo.Text = "Cuenta Activa";
            this.chkUserActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardarUser
            // 
            this.btnGuardarUser.Location = new System.Drawing.Point(667, 138);
            this.btnGuardarUser.Name = "btnGuardarUser";
            this.btnGuardarUser.Size = new System.Drawing.Size(135, 63);
            this.btnGuardarUser.TabIndex = 6;
            this.btnGuardarUser.Text = "Guardar Cambios";
            this.btnGuardarUser.UseVisualStyleBackColor = true;
            this.btnGuardarUser.Click += new System.EventHandler(this.btnGuardarUser_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.Location = new System.Drawing.Point(667, 350);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(135, 63);
            this.btnResetPass.TabIndex = 7;
            this.btnResetPass.Text = "Resetear Clave";
            this.btnResetPass.UseVisualStyleBackColor = true;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // lblIdUserSeleccionado
            // 
            this.lblIdUserSeleccionado.AutoSize = true;
            this.lblIdUserSeleccionado.Location = new System.Drawing.Point(363, 12);
            this.lblIdUserSeleccionado.Name = "lblIdUserSeleccionado";
            this.lblIdUserSeleccionado.Size = new System.Drawing.Size(15, 17);
            this.lblIdUserSeleccionado.TabIndex = 8;
            this.lblIdUserSeleccionado.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nueva Contraseña";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(667, 321);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Size = new System.Drawing.Size(135, 23);
            this.txtNuevaClave.TabIndex = 10;
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 446);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmAdmin";
            this.Text = "FrmAdmin";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkUserActivo;
        private System.Windows.Forms.ComboBox cmbRolUser;
        private System.Windows.Forms.TextBox txtDniUser;
        private System.Windows.Forms.TextBox txtApeUser;
        private System.Windows.Forms.TextBox txtNomUser;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblIdUserSeleccionado;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnGuardarUser;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label label1;
    }
}