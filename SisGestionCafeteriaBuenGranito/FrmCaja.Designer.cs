namespace SisGestionCafeteriaBuenGranito
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
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblMontodePago = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.btnAbrirCocina = new System.Windows.Forms.Button();
            this.btnMuffin = new System.Windows.Forms.Button();
            this.btnEmpanada = new System.Windows.Forms.Button();
            this.btnMocaccino = new System.Windows.Forms.Button();
            this.btnSandwichPollo = new System.Windows.Forms.Button();
            this.btnGaseosa = new System.Windows.Forms.Button();
            this.btnAguaMineral = new System.Windows.Forms.Button();
            this.btnIcedCoffee = new System.Windows.Forms.Button();
            this.btnFrapuccino = new System.Windows.Forms.Button();
            this.btnJugo = new System.Windows.Forms.Button();
            this.btnInfusion = new System.Windows.Forms.Button();
            this.btnChocolateCaliente = new System.Windows.Forms.Button();
            this.btnLatte = new System.Windows.Forms.Button();
            this.btnCapuchino = new System.Windows.Forms.Button();
            this.btnAmericano = new System.Windows.Forms.Button();
            this.btnCroissant = new System.Windows.Forms.Button();
            this.btnCafe = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lstResultados = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedido
            // 
            this.dgvPedido.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(208)))));
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(19, 13);
            this.dgvPedido.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new System.Drawing.Size(406, 299);
            this.dgvPedido.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Location = new System.Drawing.Point(153, 330);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 38);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "S/. 00.00";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Location = new System.Drawing.Point(160, 385);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(141, 43);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Crear Pedido";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(12, 325);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(133, 43);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar Producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.pnl1.Controls.Add(this.lblVuelto);
            this.pnl1.Controls.Add(this.lblMontodePago);
            this.pnl1.Controls.Add(this.btnCancelar);
            this.pnl1.Controls.Add(this.txtMontoRecibido);
            this.pnl1.Controls.Add(this.btnAbrirCocina);
            this.pnl1.Controls.Add(this.btnEliminar);
            this.pnl1.Controls.Add(this.btnCobrar);
            this.pnl1.Controls.Add(this.lblTotal);
            this.pnl1.Controls.Add(this.dgvPedido);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl1.Location = new System.Drawing.Point(495, 0);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(438, 554);
            this.pnl1.TabIndex = 6;
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVuelto.Location = new System.Drawing.Point(143, 488);
            this.lblVuelto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(158, 25);
            this.lblVuelto.TabIndex = 10;
            this.lblVuelto.Text = "Vuelto: S/ 0.00";
            // 
            // lblMontodePago
            // 
            this.lblMontodePago.AutoSize = true;
            this.lblMontodePago.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontodePago.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMontodePago.Location = new System.Drawing.Point(64, 445);
            this.lblMontodePago.Name = "lblMontodePago";
            this.lblMontodePago.Size = new System.Drawing.Size(90, 21);
            this.lblMontodePago.TabIndex = 9;
            this.lblMontodePago.Text = "Paga con:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(309, 325);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 43);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Location = new System.Drawing.Point(160, 447);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(141, 21);
            this.txtMontoRecibido.TabIndex = 7;
            this.txtMontoRecibido.TextChanged += new System.EventHandler(this.txtMontoRecibido_TextChanged);
            // 
            // btnAbrirCocina
            // 
            this.btnAbrirCocina.FlatAppearance.BorderSize = 0;
            this.btnAbrirCocina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCocina.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCocina.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAbrirCocina.Location = new System.Drawing.Point(371, 514);
            this.btnAbrirCocina.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirCocina.Name = "btnAbrirCocina";
            this.btnAbrirCocina.Size = new System.Drawing.Size(63, 27);
            this.btnAbrirCocina.TabIndex = 6;
            this.btnAbrirCocina.Text = "Cocina";
            this.btnAbrirCocina.UseVisualStyleBackColor = true;
            this.btnAbrirCocina.Click += new System.EventHandler(this.btnAbrirCocina_Click);
            // 
            // btnMuffin
            // 
            this.btnMuffin.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_22_21_PM;
            this.btnMuffin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMuffin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuffin.Location = new System.Drawing.Point(17, 302);
            this.btnMuffin.Margin = new System.Windows.Forms.Padding(4);
            this.btnMuffin.Name = "btnMuffin";
            this.btnMuffin.Size = new System.Drawing.Size(88, 88);
            this.btnMuffin.TabIndex = 20;
            this.btnMuffin.UseVisualStyleBackColor = true;
            this.btnMuffin.Click += new System.EventHandler(this.btnMuffin_Click);
            // 
            // btnEmpanada
            // 
            this.btnEmpanada.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_15_36_PM;
            this.btnEmpanada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmpanada.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpanada.Location = new System.Drawing.Point(399, 12);
            this.btnEmpanada.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpanada.Name = "btnEmpanada";
            this.btnEmpanada.Size = new System.Drawing.Size(88, 88);
            this.btnEmpanada.TabIndex = 19;
            this.btnEmpanada.UseVisualStyleBackColor = true;
            this.btnEmpanada.Click += new System.EventHandler(this.btnEmpanada_Click);
            // 
            // btnMocaccino
            // 
            this.btnMocaccino.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_30_29_PM;
            this.btnMocaccino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMocaccino.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMocaccino.Location = new System.Drawing.Point(112, 109);
            this.btnMocaccino.Margin = new System.Windows.Forms.Padding(4);
            this.btnMocaccino.Name = "btnMocaccino";
            this.btnMocaccino.Size = new System.Drawing.Size(88, 89);
            this.btnMocaccino.TabIndex = 18;
            this.btnMocaccino.UseVisualStyleBackColor = true;
            this.btnMocaccino.Click += new System.EventHandler(this.btnMocaccino_Click);
            // 
            // btnSandwichPollo
            // 
            this.btnSandwichPollo.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_06_31_PM;
            this.btnSandwichPollo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSandwichPollo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSandwichPollo.Location = new System.Drawing.Point(401, 208);
            this.btnSandwichPollo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSandwichPollo.Name = "btnSandwichPollo";
            this.btnSandwichPollo.Size = new System.Drawing.Size(86, 88);
            this.btnSandwichPollo.TabIndex = 17;
            this.btnSandwichPollo.UseVisualStyleBackColor = true;
            this.btnSandwichPollo.Click += new System.EventHandler(this.btnSandwichPollo_Click);
            // 
            // btnGaseosa
            // 
            this.btnGaseosa.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_05_04_PM;
            this.btnGaseosa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGaseosa.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaseosa.Location = new System.Drawing.Point(305, 206);
            this.btnGaseosa.Margin = new System.Windows.Forms.Padding(4);
            this.btnGaseosa.Name = "btnGaseosa";
            this.btnGaseosa.Size = new System.Drawing.Size(87, 88);
            this.btnGaseosa.TabIndex = 16;
            this.btnGaseosa.UseVisualStyleBackColor = true;
            this.btnGaseosa.Click += new System.EventHandler(this.btnGaseosa_Click);
            // 
            // btnAguaMineral
            // 
            this.btnAguaMineral.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_03_00_PM;
            this.btnAguaMineral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAguaMineral.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAguaMineral.Location = new System.Drawing.Point(209, 208);
            this.btnAguaMineral.Margin = new System.Windows.Forms.Padding(4);
            this.btnAguaMineral.Name = "btnAguaMineral";
            this.btnAguaMineral.Size = new System.Drawing.Size(88, 88);
            this.btnAguaMineral.TabIndex = 15;
            this.btnAguaMineral.UseVisualStyleBackColor = true;
            this.btnAguaMineral.Click += new System.EventHandler(this.btnAguaMineral_Click);
            // 
            // btnIcedCoffee
            // 
            this.btnIcedCoffee.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_01_39_PM;
            this.btnIcedCoffee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcedCoffee.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIcedCoffee.Location = new System.Drawing.Point(304, 109);
            this.btnIcedCoffee.Margin = new System.Windows.Forms.Padding(4);
            this.btnIcedCoffee.Name = "btnIcedCoffee";
            this.btnIcedCoffee.Size = new System.Drawing.Size(87, 87);
            this.btnIcedCoffee.TabIndex = 14;
            this.btnIcedCoffee.UseVisualStyleBackColor = true;
            this.btnIcedCoffee.Click += new System.EventHandler(this.btnIcedCoffee_Click);
            // 
            // btnFrapuccino
            // 
            this.btnFrapuccino.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_00_25_PM;
            this.btnFrapuccino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFrapuccino.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFrapuccino.Location = new System.Drawing.Point(14, 206);
            this.btnFrapuccino.Margin = new System.Windows.Forms.Padding(4);
            this.btnFrapuccino.Name = "btnFrapuccino";
            this.btnFrapuccino.Size = new System.Drawing.Size(87, 88);
            this.btnFrapuccino.TabIndex = 13;
            this.btnFrapuccino.UseVisualStyleBackColor = true;
            this.btnFrapuccino.Click += new System.EventHandler(this.btnFrapuccino_Click);
            // 
            // btnJugo
            // 
            this.btnJugo.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_58_50_PM;
            this.btnJugo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJugo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugo.Location = new System.Drawing.Point(113, 208);
            this.btnJugo.Margin = new System.Windows.Forms.Padding(4);
            this.btnJugo.Name = "btnJugo";
            this.btnJugo.Size = new System.Drawing.Size(87, 88);
            this.btnJugo.TabIndex = 12;
            this.btnJugo.UseVisualStyleBackColor = true;
            this.btnJugo.Click += new System.EventHandler(this.btnJugo_Click);
            // 
            // btnInfusion
            // 
            this.btnInfusion.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_48_00_PM;
            this.btnInfusion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfusion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfusion.Location = new System.Drawing.Point(209, 109);
            this.btnInfusion.Margin = new System.Windows.Forms.Padding(4);
            this.btnInfusion.Name = "btnInfusion";
            this.btnInfusion.Size = new System.Drawing.Size(87, 88);
            this.btnInfusion.TabIndex = 11;
            this.btnInfusion.UseVisualStyleBackColor = true;
            this.btnInfusion.Click += new System.EventHandler(this.btnInfusion_Click);
            // 
            // btnChocolateCaliente
            // 
            this.btnChocolateCaliente.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_44_55_PM;
            this.btnChocolateCaliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChocolateCaliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChocolateCaliente.Location = new System.Drawing.Point(13, 110);
            this.btnChocolateCaliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnChocolateCaliente.Name = "btnChocolateCaliente";
            this.btnChocolateCaliente.Size = new System.Drawing.Size(88, 88);
            this.btnChocolateCaliente.TabIndex = 10;
            this.btnChocolateCaliente.UseVisualStyleBackColor = true;
            this.btnChocolateCaliente.Click += new System.EventHandler(this.btnChocolateCaliente_Click);
            // 
            // btnLatte
            // 
            this.btnLatte.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_30_02_PM;
            this.btnLatte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLatte.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLatte.Location = new System.Drawing.Point(304, 12);
            this.btnLatte.Margin = new System.Windows.Forms.Padding(4);
            this.btnLatte.Name = "btnLatte";
            this.btnLatte.Size = new System.Drawing.Size(87, 89);
            this.btnLatte.TabIndex = 9;
            this.btnLatte.UseVisualStyleBackColor = true;
            this.btnLatte.Click += new System.EventHandler(this.btnLatte_Click);
            // 
            // btnCapuchino
            // 
            this.btnCapuchino.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_30_15_PM;
            this.btnCapuchino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapuchino.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapuchino.Location = new System.Drawing.Point(209, 12);
            this.btnCapuchino.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapuchino.Name = "btnCapuchino";
            this.btnCapuchino.Size = new System.Drawing.Size(87, 89);
            this.btnCapuchino.TabIndex = 8;
            this.btnCapuchino.UseVisualStyleBackColor = true;
            this.btnCapuchino.Click += new System.EventHandler(this.btnCapuchino_Click);
            // 
            // btnAmericano
            // 
            this.btnAmericano.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_29_47_PM;
            this.btnAmericano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAmericano.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmericano.Location = new System.Drawing.Point(113, 12);
            this.btnAmericano.Margin = new System.Windows.Forms.Padding(4);
            this.btnAmericano.Name = "btnAmericano";
            this.btnAmericano.Size = new System.Drawing.Size(87, 89);
            this.btnAmericano.TabIndex = 7;
            this.btnAmericano.UseVisualStyleBackColor = true;
            this.btnAmericano.Click += new System.EventHandler(this.btnAmericano_Click);
            // 
            // btnCroissant
            // 
            this.btnCroissant.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_10_07_44_PM;
            this.btnCroissant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCroissant.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCroissant.Location = new System.Drawing.Point(400, 108);
            this.btnCroissant.Margin = new System.Windows.Forms.Padding(4);
            this.btnCroissant.Name = "btnCroissant";
            this.btnCroissant.Size = new System.Drawing.Size(87, 88);
            this.btnCroissant.TabIndex = 3;
            this.btnCroissant.UseVisualStyleBackColor = true;
            this.btnCroissant.Click += new System.EventHandler(this.btnCroissant_Click);
            // 
            // btnCafe
            // 
            this.btnCafe.BackgroundImage = global::SisGestionCafeteriaBuenGranito.Properties.Resources.WhatsApp_Image_2025_11_25_at_9_29_32_PM;
            this.btnCafe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCafe.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCafe.Location = new System.Drawing.Point(13, 13);
            this.btnCafe.Margin = new System.Windows.Forms.Padding(4);
            this.btnCafe.Name = "btnCafe";
            this.btnCafe.Size = new System.Drawing.Size(88, 89);
            this.btnCafe.TabIndex = 2;
            this.btnCafe.UseVisualStyleBackColor = true;
            this.btnCafe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCafe_MouseClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(122, 313);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(211, 31);
            this.txtBuscar.TabIndex = 21;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lstResultados
            // 
            this.lstResultados.FormattingEnabled = true;
            this.lstResultados.ItemHeight = 16;
            this.lstResultados.Location = new System.Drawing.Point(122, 350);
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.Size = new System.Drawing.Size(365, 180);
            this.lstResultados.TabIndex = 22;
            this.lstResultados.Click += new System.EventHandler(this.lstResultados_Click);
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.lstResultados);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnMuffin);
            this.Controls.Add(this.btnEmpanada);
            this.Controls.Add(this.btnMocaccino);
            this.Controls.Add(this.btnSandwichPollo);
            this.Controls.Add(this.btnGaseosa);
            this.Controls.Add(this.btnChocolateCaliente);
            this.Controls.Add(this.btnAguaMineral);
            this.Controls.Add(this.btnIcedCoffee);
            this.Controls.Add(this.btnFrapuccino);
            this.Controls.Add(this.btnJugo);
            this.Controls.Add(this.btnInfusion);
            this.Controls.Add(this.btnLatte);
            this.Controls.Add(this.btnCapuchino);
            this.Controls.Add(this.btnAmericano);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.btnCroissant);
            this.Controls.Add(this.btnCafe);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCaja";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "El Buen Granito";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCafe;
        private System.Windows.Forms.Button btnCroissant;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Button btnAmericano;
        private System.Windows.Forms.Button btnCapuchino;
        private System.Windows.Forms.Button btnLatte;
        private System.Windows.Forms.Button btnChocolateCaliente;
        private System.Windows.Forms.Button btnInfusion;
        private System.Windows.Forms.Button btnJugo;
        private System.Windows.Forms.Button btnFrapuccino;
        private System.Windows.Forms.Button btnIcedCoffee;
        private System.Windows.Forms.Button btnAguaMineral;
        private System.Windows.Forms.Button btnGaseosa;
        private System.Windows.Forms.Button btnSandwichPollo;
        private System.Windows.Forms.Button btnMocaccino;
        private System.Windows.Forms.Button btnEmpanada;
        private System.Windows.Forms.Button btnMuffin;
        private System.Windows.Forms.Button btnAbrirCocina;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ListBox lstResultados;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtMontoRecibido;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label lblMontodePago;
    }
}

