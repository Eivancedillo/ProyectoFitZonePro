namespace ProyectoFitZonePro
{
    partial class FrmVerEntradas
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
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.DtgDetalleEntrada = new System.Windows.Forms.DataGridView();
            this.DtgEntradas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTotalVenta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(69, 50);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(391, 26);
            this.DtpFecha.TabIndex = 5;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // DtgDetalleEntrada
            // 
            this.DtgDetalleEntrada.AllowUserToAddRows = false;
            this.DtgDetalleEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetalleEntrada.Location = new System.Drawing.Point(466, 85);
            this.DtgDetalleEntrada.Name = "DtgDetalleEntrada";
            this.DtgDetalleEntrada.ReadOnly = true;
            this.DtgDetalleEntrada.Size = new System.Drawing.Size(630, 436);
            this.DtgDetalleEntrada.TabIndex = 4;
            // 
            // DtgEntradas
            // 
            this.DtgEntradas.AllowUserToAddRows = false;
            this.DtgEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEntradas.Location = new System.Drawing.Point(12, 85);
            this.DtgEntradas.Name = "DtgEntradas";
            this.DtgEntradas.ReadOnly = true;
            this.DtgEntradas.Size = new System.Drawing.Size(448, 436);
            this.DtgEntradas.TabIndex = 3;
            this.DtgEntradas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEntradas_CellClick);
            this.DtgEntradas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEntradas_CellEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha:";
            // 
            // LblTotalVenta
            // 
            this.LblTotalVenta.Location = new System.Drawing.Point(462, 524);
            this.LblTotalVenta.Name = "LblTotalVenta";
            this.LblTotalVenta.Size = new System.Drawing.Size(634, 20);
            this.LblTotalVenta.TabIndex = 8;
            this.LblTotalVenta.Text = ".....";
            this.LblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmVerEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 657);
            this.Controls.Add(this.LblTotalVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.DtgDetalleEntrada);
            this.Controls.Add(this.DtgEntradas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEntradas";
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.DataGridView DtgDetalleEntrada;
        private System.Windows.Forms.DataGridView DtgEntradas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalVenta;
    }
}