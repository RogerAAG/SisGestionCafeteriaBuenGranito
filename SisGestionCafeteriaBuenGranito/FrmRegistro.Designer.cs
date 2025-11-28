namespace SisGestionCafeteriaBuenGranito
{
    partial class FrmRegistro
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrarApp = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarApp)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(103, 120);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 27);
            this.txtNombre.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(103, 281);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(188, 27);
            this.txtPassword.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(103, 171);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(188, 27);
            this.txtApellido.TabIndex = 2;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(103, 227);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(188, 27);
            this.txtDni.TabIndex = 3;
            // 
            // cmbRol
            // 
            this.cmbRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(103, 333);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(188, 29);
            this.cmbRol.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(154)))), ((int)(((byte)(107)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(103, 385);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(188, 38);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblNombre.Location = new System.Drawing.Point(25, 125);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 18);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(25, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label2.Location = new System.Drawing.Point(59, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label3.Location = new System.Drawing.Point(3, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label4.Location = new System.Drawing.Point(59, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rol:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OldLace;
            this.label5.Location = new System.Drawing.Point(60, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "REGISTRO DE USUARIO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(54)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnCerrarApp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 90);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisGestionCafeteriaBuenGranito.Properties.Resources.Signing_A_Document;
            this.pictureBox1.Location = new System.Drawing.Point(25, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Image = global::SisGestionCafeteriaBuenGranito.Properties.Resources.Minimize_Window_claro;
            this.btnMinimizar.Location = new System.Drawing.Point(314, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 14;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrarApp
            // 
            this.btnCerrarApp.Image = global::SisGestionCafeteriaBuenGranito.Properties.Resources.Close_Window_claro;
            this.btnCerrarApp.Location = new System.Drawing.Point(344, 12);
            this.btnCerrarApp.Name = "btnCerrarApp";
            this.btnCerrarApp.Size = new System.Drawing.Size(24, 25);
            this.btnCerrarApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrarApp.TabIndex = 13;
            this.btnCerrarApp.TabStop = false;
            this.btnCerrarApp.Click += new System.EventHandler(this.btnCerrarApp_Click);
            // 
            // FrmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(377, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistro";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistro";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmRegistro_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnCerrarApp;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}