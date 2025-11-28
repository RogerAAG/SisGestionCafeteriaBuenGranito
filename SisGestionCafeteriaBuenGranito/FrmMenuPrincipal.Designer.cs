namespace SisGestionCafeteriaBuenGranito
{
    partial class FrmMenuPrincipal
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
            this.btnIrCaja = new System.Windows.Forms.Button();
            this.btnIrAdmin = new System.Windows.Forms.Button();
            this.btnIrCocina = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIrCaja
            // 
            this.btnIrCaja.Location = new System.Drawing.Point(84, 101);
            this.btnIrCaja.Name = "btnIrCaja";
            this.btnIrCaja.Size = new System.Drawing.Size(137, 60);
            this.btnIrCaja.TabIndex = 0;
            this.btnIrCaja.Text = "IrCaja";
            this.btnIrCaja.UseVisualStyleBackColor = true;
            this.btnIrCaja.Click += new System.EventHandler(this.btnIrCaja_Click);
            // 
            // btnIrAdmin
            // 
            this.btnIrAdmin.Location = new System.Drawing.Point(84, 265);
            this.btnIrAdmin.Name = "btnIrAdmin";
            this.btnIrAdmin.Size = new System.Drawing.Size(137, 60);
            this.btnIrAdmin.TabIndex = 1;
            this.btnIrAdmin.Text = "IrAdmin";
            this.btnIrAdmin.UseVisualStyleBackColor = true;
            this.btnIrAdmin.Click += new System.EventHandler(this.btnIrAdmin_Click);
            // 
            // btnIrCocina
            // 
            this.btnIrCocina.Location = new System.Drawing.Point(84, 183);
            this.btnIrCocina.Name = "btnIrCocina";
            this.btnIrCocina.Size = new System.Drawing.Size(137, 60);
            this.btnIrCocina.TabIndex = 2;
            this.btnIrCocina.Text = "IrCocina";
            this.btnIrCocina.UseVisualStyleBackColor = true;
            this.btnIrCocina.Click += new System.EventHandler(this.btnIrCocina_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(84, 41);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenida.TabIndex = 3;
            this.lblBienvenida.Text = "label1";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(84, 343);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(137, 60);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "CerrarSesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 435);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnIrCocina);
            this.Controls.Add(this.btnIrAdmin);
            this.Controls.Add(this.btnIrCaja);
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenuPrincipal_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIrCaja;
        private System.Windows.Forms.Button btnIrAdmin;
        private System.Windows.Forms.Button btnIrCocina;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}