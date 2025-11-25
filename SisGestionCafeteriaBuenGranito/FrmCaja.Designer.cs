namespace GranitoPOS
{
    partial class FrmCaja
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCafe = new System.Windows.Forms.Button();
            this.btnCroissant = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnl1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedido
            // 
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(24, 82);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new System.Drawing.Size(508, 345);
            this.dgvPedido.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Location = new System.Drawing.Point(46, 353);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 38);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "S/. 00.00";
            // 
            // btnCafe
            // 
            this.btnCafe.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCafe.Location = new System.Drawing.Point(24, 22);
            this.btnCafe.Name = "btnCafe";
            this.btnCafe.Size = new System.Drawing.Size(104, 35);
            this.btnCafe.TabIndex = 2;
            this.btnCafe.Text = "Café";
            this.btnCafe.UseVisualStyleBackColor = true;
            this.btnCafe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCafe_MouseClick);
            // 
            // btnCroissant
            // 
            this.btnCroissant.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCroissant.Location = new System.Drawing.Point(134, 22);
            this.btnCroissant.Name = "btnCroissant";
            this.btnCroissant.Size = new System.Drawing.Size(104, 35);
            this.btnCroissant.TabIndex = 3;
            this.btnCroissant.Text = "Croissant";
            this.btnCroissant.UseVisualStyleBackColor = true;
            this.btnCroissant.Click += new System.EventHandler(this.btnCroissant_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Location = new System.Drawing.Point(69, 289);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(104, 35);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(53, 222);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(137, 35);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar Producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.pnl1.Controls.Add(this.btnEliminar);
            this.pnl1.Controls.Add(this.btnCobrar);
            this.pnl1.Controls.Add(this.lblTotal);
            this.pnl1.Location = new System.Drawing.Point(564, 1);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(242, 445);
            this.pnl1.TabIndex = 6;
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.btnCroissant);
            this.Controls.Add(this.btnCafe);
            this.Controls.Add(this.dgvPedido);
            this.Name = "FrmCaja";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCafe;
        private System.Windows.Forms.Button btnCroissant;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnl1;
    }
}

