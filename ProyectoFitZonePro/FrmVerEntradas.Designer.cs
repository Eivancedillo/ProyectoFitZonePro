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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.LblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).BeginInit();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpFecha
            // 
            this.DtpFecha.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Location = new System.Drawing.Point(83, 91);
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
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
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
            this.PSom.Location = new System.Drawing.Point(23, 131);
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
            this.PSom2.Location = new System.Drawing.Point(458, 131);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 611);
            this.panel1.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.LblEstado);
            this.panel3.Controls.Add(this.BtnCancelar);
            this.panel3.Controls.Add(this.DtpFecha);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.PSom2);
            this.panel3.Controls.Add(this.PSom);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(891, 607);
            this.panel3.TabIndex = 7;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancelar.Location = new System.Drawing.Point(665, 25);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(195, 46);
            this.BtnCancelar.TabIndex = 18;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel7.Location = new System.Drawing.Point(5, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(895, 611);
            this.panel7.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Vista de ventas";
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblEstado.Location = new System.Drawing.Point(9, 30);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(266, 16);
            this.LblEstado.TabIndex = 23;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // FrmVerEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(901, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.LblTotalVenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerEntradas";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.FrmVerEntradas_Load);
            this.Shown += new System.EventHandler(this.FrmVerEntradas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetalleEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntradas)).EndInit();
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblEstado;
    }
}