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
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.PSom2 = new System.Windows.Forms.Panel();
            this.Pdel2 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).BeginInit();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(76, 51);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(391, 26);
            this.DtpFecha.TabIndex = 5;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // DtgDetalleEntrada
            // 
            this.DtgDetalleEntrada.AllowUserToAddRows = false;
            this.DtgDetalleEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetalleEntrada.Location = new System.Drawing.Point(18, 20);
            this.DtgDetalleEntrada.Name = "DtgDetalleEntrada";
            this.DtgDetalleEntrada.ReadOnly = true;
            this.DtgDetalleEntrada.RowHeadersWidth = 51;
            this.DtgDetalleEntrada.Size = new System.Drawing.Size(366, 365);
            this.DtgDetalleEntrada.TabIndex = 4;
            // 
            // DtgEntradas
            // 
            this.DtgEntradas.AllowUserToAddRows = false;
            this.DtgEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEntradas.Location = new System.Drawing.Point(15, 23);
            this.DtgEntradas.Name = "DtgEntradas";
            this.DtgEntradas.ReadOnly = true;
            this.DtgEntradas.RowHeadersWidth = 51;
            this.DtgEntradas.Size = new System.Drawing.Size(366, 365);
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
            this.LblTotalVenta.Location = new System.Drawing.Point(469, 530);
            this.LblTotalVenta.Name = "LblTotalVenta";
            this.LblTotalVenta.Size = new System.Drawing.Size(370, 20);
            this.LblTotalVenta.TabIndex = 8;
            this.LblTotalVenta.Text = ".....";
            this.LblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(16, 91);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(408, 425);
            this.PSom.TabIndex = 17;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.DtgEntradas);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(400, 417);
            this.Pdel.TabIndex = 9;
            // 
            // PSom2
            // 
            this.PSom2.Controls.Add(this.Pdel2);
            this.PSom2.Location = new System.Drawing.Point(451, 91);
            this.PSom2.Name = "PSom2";
            this.PSom2.Size = new System.Drawing.Size(408, 425);
            this.PSom2.TabIndex = 18;
            // 
            // Pdel2
            // 
            this.Pdel2.Controls.Add(this.DtgDetalleEntrada);
            this.Pdel2.Location = new System.Drawing.Point(4, 4);
            this.Pdel2.Name = "Pdel2";
            this.Pdel2.Size = new System.Drawing.Size(400, 417);
            this.Pdel2.TabIndex = 9;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(769, 12);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(86, 25);
            this.BtnCancelar.TabIndex = 23;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmVerEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 573);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.PSom2);
            this.Controls.Add(this.PSom);
            this.Controls.Add(this.LblTotalVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEntradas";
            this.Load += new System.EventHandler(this.FrmVerEntradas_Load);
            this.Shown += new System.EventHandler(this.FrmVerEntradas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).EndInit();
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.DataGridView DtgDetalleEntrada;
        private System.Windows.Forms.DataGridView DtgEntradas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalVenta;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Panel PSom2;
        private System.Windows.Forms.Panel Pdel2;
        private System.Windows.Forms.Button BtnCancelar;
    }
}