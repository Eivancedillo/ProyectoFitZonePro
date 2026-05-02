namespace ProyectoFitZonePro
{
    partial class FrmVerVentas
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
            this.DtgVentas = new System.Windows.Forms.DataGridView();
            this.DtgDetalleVenta = new System.Windows.Forms.DataGridView();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTotalVenta = new System.Windows.Forms.Label();
            this.PSom2 = new System.Windows.Forms.Panel();
            this.Pdel2 = new System.Windows.Forms.Panel();
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.LblEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleVenta)).BeginInit();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgVentas
            // 
            this.DtgVentas.AllowUserToAddRows = false;
            this.DtgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgVentas.Location = new System.Drawing.Point(19, 27);
            this.DtgVentas.Name = "DtgVentas";
            this.DtgVentas.ReadOnly = true;
            this.DtgVentas.Size = new System.Drawing.Size(366, 385);
            this.DtgVentas.TabIndex = 0;
            this.DtgVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgVentas_CellClick);
            this.DtgVentas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgVentas_CellEnter);
            // 
            // DtgDetalleVenta
            // 
            this.DtgDetalleVenta.AllowUserToAddRows = false;
            this.DtgDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetalleVenta.Location = new System.Drawing.Point(19, 27);
            this.DtgDetalleVenta.Name = "DtgDetalleVenta";
            this.DtgDetalleVenta.ReadOnly = true;
            this.DtgDetalleVenta.Size = new System.Drawing.Size(366, 352);
            this.DtgDetalleVenta.TabIndex = 1;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(92, 79);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(342, 26);
            this.DtpFecha.TabIndex = 2;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha:";
            // 
            // LblTotalVenta
            // 
            this.LblTotalVenta.Location = new System.Drawing.Point(19, 401);
            this.LblTotalVenta.Name = "LblTotalVenta";
            this.LblTotalVenta.Size = new System.Drawing.Size(366, 21);
            this.LblTotalVenta.TabIndex = 8;
            this.LblTotalVenta.Text = ".....";
            this.LblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PSom2
            // 
            this.PSom2.Controls.Add(this.Pdel2);
            this.PSom2.Location = new System.Drawing.Point(454, 124);
            this.PSom2.Name = "PSom2";
            this.PSom2.Size = new System.Drawing.Size(408, 446);
            this.PSom2.TabIndex = 17;
            // 
            // Pdel2
            // 
            this.Pdel2.Controls.Add(this.DtgDetalleVenta);
            this.Pdel2.Controls.Add(this.LblTotalVenta);
            this.Pdel2.Location = new System.Drawing.Point(4, 4);
            this.Pdel2.Name = "Pdel2";
            this.Pdel2.Size = new System.Drawing.Size(400, 438);
            this.Pdel2.TabIndex = 9;
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(26, 124);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(408, 446);
            this.PSom.TabIndex = 16;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.DtgVentas);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(400, 438);
            this.Pdel.TabIndex = 9;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblEstado.Location = new System.Drawing.Point(12, 30);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(266, 16);
            this.LblEstado.TabIndex = 21;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Vista de ventas";
            // 
            // FrmVerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PSom2);
            this.Controls.Add(this.PSom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerVentas";
            this.Load += new System.EventHandler(this.FrmVerVentas_Load);
            this.Shown += new System.EventHandler(this.FrmVerVentas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleVenta)).EndInit();
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgVentas;
        private System.Windows.Forms.DataGridView DtgDetalleVenta;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalVenta;
        private System.Windows.Forms.Panel PSom2;
        private System.Windows.Forms.Panel Pdel2;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label label3;
    }
}