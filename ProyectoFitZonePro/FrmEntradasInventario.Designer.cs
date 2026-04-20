namespace ProyectoFitZonePro
{
    partial class FrmEntradasInventario
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
            this.DtgProductos = new System.Windows.Forms.DataGridView();
            this.DtgEntrada = new System.Windows.Forms.DataGridView();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnVerEntradas = new System.Windows.Forms.Button();
            this.PSom2 = new System.Windows.Forms.Panel();
            this.Pdel2 = new System.Windows.Forms.Panel();
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.BtnRealizarEntrada = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntrada)).BeginInit();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgProductos
            // 
            this.DtgProductos.AllowUserToAddRows = false;
            this.DtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProductos.Location = new System.Drawing.Point(20, 63);
            this.DtgProductos.Name = "DtgProductos";
            this.DtgProductos.ReadOnly = true;
            this.DtgProductos.Size = new System.Drawing.Size(280, 335);
            this.DtgProductos.TabIndex = 0;
            this.DtgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellClick);
            this.DtgProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellEnter);
            // 
            // DtgEntrada
            // 
            this.DtgEntrada.AllowUserToAddRows = false;
            this.DtgEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEntrada.Location = new System.Drawing.Point(20, 20);
            this.DtgEntrada.Name = "DtgEntrada";
            this.DtgEntrada.Size = new System.Drawing.Size(445, 378);
            this.DtgEntrada.TabIndex = 1;
            this.DtgEntrada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEntrada_CellClick);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBusqueda.Location = new System.Drawing.Point(20, 20);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(280, 26);
            this.TxtBusqueda.TabIndex = 3;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblEstado.Location = new System.Drawing.Point(12, 30);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(266, 16);
            this.LblEstado.TabIndex = 24;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Vista de ventas";
            // 
            // BtnVerEntradas
            // 
            this.BtnVerEntradas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnVerEntradas.FlatAppearance.BorderSize = 0;
            this.BtnVerEntradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerEntradas.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnVerEntradas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnVerEntradas.Location = new System.Drawing.Point(379, 509);
            this.BtnVerEntradas.Name = "BtnVerEntradas";
            this.BtnVerEntradas.Size = new System.Drawing.Size(228, 70);
            this.BtnVerEntradas.TabIndex = 22;
            this.BtnVerEntradas.Text = "Ver entradas";
            this.BtnVerEntradas.UseVisualStyleBackColor = false;
            this.BtnVerEntradas.Click += new System.EventHandler(this.BtnVerEntradas_Click);
            // 
            // PSom2
            // 
            this.PSom2.Controls.Add(this.Pdel2);
            this.PSom2.Location = new System.Drawing.Point(379, 64);
            this.PSom2.Name = "PSom2";
            this.PSom2.Size = new System.Drawing.Size(493, 425);
            this.PSom2.TabIndex = 21;
            // 
            // Pdel2
            // 
            this.Pdel2.Controls.Add(this.DtgEntrada);
            this.Pdel2.Location = new System.Drawing.Point(4, 4);
            this.Pdel2.Name = "Pdel2";
            this.Pdel2.Size = new System.Drawing.Size(485, 417);
            this.Pdel2.TabIndex = 9;
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(26, 64);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(329, 425);
            this.PSom.TabIndex = 20;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.TxtBusqueda);
            this.Pdel.Controls.Add(this.DtgProductos);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(321, 417);
            this.Pdel.TabIndex = 9;
            // 
            // BtnRealizarEntrada
            // 
            this.BtnRealizarEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnRealizarEntrada.FlatAppearance.BorderSize = 0;
            this.BtnRealizarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRealizarEntrada.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnRealizarEntrada.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnRealizarEntrada.Location = new System.Drawing.Point(26, 509);
            this.BtnRealizarEntrada.Name = "BtnRealizarEntrada";
            this.BtnRealizarEntrada.Size = new System.Drawing.Size(228, 70);
            this.BtnRealizarEntrada.TabIndex = 22;
            this.BtnRealizarEntrada.Text = "Realizar entrada";
            this.BtnRealizarEntrada.UseVisualStyleBackColor = false;
            this.BtnRealizarEntrada.Click += new System.EventHandler(this.BtnRealizarEntrada_Click);
            // 
            // FrmEntradasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnRealizarEntrada);
            this.Controls.Add(this.BtnVerEntradas);
            this.Controls.Add(this.PSom2);
            this.Controls.Add(this.PSom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmEntradasInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEntradasInventario";
            this.Load += new System.EventHandler(this.FrmEntradasInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntrada)).EndInit();
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.Pdel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgProductos;
        private System.Windows.Forms.DataGridView DtgEntrada;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnVerEntradas;
        private System.Windows.Forms.Panel PSom2;
        private System.Windows.Forms.Panel Pdel2;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Button BtnRealizarEntrada;
    }
}