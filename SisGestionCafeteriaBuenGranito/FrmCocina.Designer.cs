namespace SisGestionCafeteriaBuenGranito
{
    partial class FrmCocina
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelPedidos = new System.Windows.Forms.FlowLayoutPanel();
            this.timerRefresco = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.panel1.Location = new System.Drawing.Point(2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 454);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanelPedidos
            // 
            this.flowLayoutPanelPedidos.AutoScroll = true;
            this.flowLayoutPanelPedidos.Location = new System.Drawing.Point(182, -1);
            this.flowLayoutPanelPedidos.Name = "flowLayoutPanelPedidos";
            this.flowLayoutPanelPedidos.Size = new System.Drawing.Size(620, 454);
            this.flowLayoutPanelPedidos.TabIndex = 1;
            // 
            // timerRefresco
            // 
            this.timerRefresco.Enabled = true;
            this.timerRefresco.Interval = 3000;
            // 
            // FrmCocina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanelPedidos);
            this.Name = "FrmCocina";
            this.Text = "Cocina";
            this.Load += new System.EventHandler(this.FrmCocina_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPedidos;
        private System.Windows.Forms.Timer timerRefresco;
    }
}