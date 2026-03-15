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
            ((System.ComponentModel.ISupportInitialize)(this.DtgVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgVentas
            // 
            this.DtgVentas.AllowUserToAddRows = false;
            this.DtgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgVentas.Location = new System.Drawing.Point(12, 83);
            this.DtgVentas.Name = "DtgVentas";
            this.DtgVentas.ReadOnly = true;
            this.DtgVentas.Size = new System.Drawing.Size(448, 436);
            this.DtgVentas.TabIndex = 0;
            this.DtgVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgVentas_CellClick);
            this.DtgVentas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgVentas_CellEnter);
            // 
            // DtgDetalleVenta
            // 
            this.DtgDetalleVenta.AllowUserToAddRows = false;
            this.DtgDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetalleVenta.Location = new System.Drawing.Point(466, 83);
            this.DtgDetalleVenta.Name = "DtgDetalleVenta";
            this.DtgDetalleVenta.ReadOnly = true;
            this.DtgDetalleVenta.Size = new System.Drawing.Size(630, 436);
            this.DtgDetalleVenta.TabIndex = 1;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(69, 48);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(391, 26);
            this.DtpFecha.TabIndex = 2;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha:";
            // 
            // FrmVerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 657);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.DtgDetalleVenta);
            this.Controls.Add(this.DtgVentas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerVentas";
            ((System.ComponentModel.ISupportInitialize)(this.DtgVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgVentas;
        private System.Windows.Forms.DataGridView DtgDetalleVenta;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label1;
    }
}