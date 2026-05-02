namespace ProyectoFitZonePro
{
    partial class FrmRealizarVenta
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
            this.DtgCarrito = new System.Windows.Forms.DataGridView();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.LblTotalVenta = new System.Windows.Forms.Label();
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.PSom2 = new System.Windows.Forms.Panel();
            this.Pdel2 = new System.Windows.Forms.Panel();
            this.LblEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCorteCaja = new System.Windows.Forms.Button();
            this.BtnAgregarProducto = new System.Windows.Forms.Button();
            this.BtnFinalizarVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgCarrito)).BeginInit();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgProductos
            // 
            this.DtgProductos.AllowUserToAddRows = false;
            this.DtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProductos.Location = new System.Drawing.Point(16, 66);
            this.DtgProductos.Name = "DtgProductos";
            this.DtgProductos.ReadOnly = true;
            this.DtgProductos.Size = new System.Drawing.Size(369, 341);
            this.DtgProductos.TabIndex = 0;
            this.DtgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellClick);
            this.DtgProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellEnter);
            // 
            // DtgCarrito
            // 
            this.DtgCarrito.AllowUserToAddRows = false;
            this.DtgCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgCarrito.Location = new System.Drawing.Point(16, 22);
            this.DtgCarrito.Name = "DtgCarrito";
            this.DtgCarrito.ReadOnly = true;
            this.DtgCarrito.Size = new System.Drawing.Size(369, 348);
            this.DtgCarrito.TabIndex = 1;
            this.DtgCarrito.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgCarrito_CellClick);
            this.DtgCarrito.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgCarrito_CellEndEdit);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBusqueda.Location = new System.Drawing.Point(24, 22);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(353, 26);
            this.TxtBusqueda.TabIndex = 5;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // LblTotalVenta
            // 
            this.LblTotalVenta.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalVenta.Location = new System.Drawing.Point(24, 381);
            this.LblTotalVenta.Name = "LblTotalVenta";
            this.LblTotalVenta.Size = new System.Drawing.Size(353, 26);
            this.LblTotalVenta.TabIndex = 7;
            this.LblTotalVenta.Text = "Total de la venta";
            this.LblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(26, 64);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(408, 425);
            this.PSom.TabIndex = 14;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.DtgProductos);
            this.Pdel.Controls.Add(this.TxtBusqueda);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(400, 417);
            this.Pdel.TabIndex = 9;
            // 
            // PSom2
            // 
            this.PSom2.Controls.Add(this.Pdel2);
            this.PSom2.Location = new System.Drawing.Point(454, 64);
            this.PSom2.Name = "PSom2";
            this.PSom2.Size = new System.Drawing.Size(408, 425);
            this.PSom2.TabIndex = 15;
            // 
            // Pdel2
            // 
            this.Pdel2.Controls.Add(this.DtgCarrito);
            this.Pdel2.Controls.Add(this.LblTotalVenta);
            this.Pdel2.Location = new System.Drawing.Point(4, 4);
            this.Pdel2.Name = "Pdel2";
            this.Pdel2.Size = new System.Drawing.Size(400, 417);
            this.Pdel2.TabIndex = 9;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblEstado.Location = new System.Drawing.Point(12, 30);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(266, 16);
            this.LblEstado.TabIndex = 19;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Vista de ventas";
            // 
            // BtnCorteCaja
            // 
            this.BtnCorteCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnCorteCaja.FlatAppearance.BorderSize = 0;
            this.BtnCorteCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCorteCaja.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCorteCaja.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCorteCaja.Location = new System.Drawing.Point(26, 516);
            this.BtnCorteCaja.Name = "BtnCorteCaja";
            this.BtnCorteCaja.Size = new System.Drawing.Size(228, 70);
            this.BtnCorteCaja.TabIndex = 17;
            this.BtnCorteCaja.Text = "Corte de caja";
            this.BtnCorteCaja.UseVisualStyleBackColor = false;
            this.BtnCorteCaja.Click += new System.EventHandler(this.BtnCorteCaja_Click);
            // 
            // BtnAgregarProducto
            // 
            this.BtnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProducto.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnAgregarProducto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAgregarProducto.Location = new System.Drawing.Point(330, 516);
            this.BtnAgregarProducto.Name = "BtnAgregarProducto";
            this.BtnAgregarProducto.Size = new System.Drawing.Size(228, 70);
            this.BtnAgregarProducto.TabIndex = 17;
            this.BtnAgregarProducto.Text = "Agregar producto";
            this.BtnAgregarProducto.UseVisualStyleBackColor = false;
            this.BtnAgregarProducto.Click += new System.EventHandler(this.BtnAgregarProducto_Click);
            // 
            // BtnFinalizarVenta
            // 
            this.BtnFinalizarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnFinalizarVenta.FlatAppearance.BorderSize = 0;
            this.BtnFinalizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFinalizarVenta.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnFinalizarVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnFinalizarVenta.Location = new System.Drawing.Point(634, 516);
            this.BtnFinalizarVenta.Name = "BtnFinalizarVenta";
            this.BtnFinalizarVenta.Size = new System.Drawing.Size(228, 70);
            this.BtnFinalizarVenta.TabIndex = 17;
            this.BtnFinalizarVenta.Text = "Finalizar venta";
            this.BtnFinalizarVenta.UseVisualStyleBackColor = false;
            this.BtnFinalizarVenta.Click += new System.EventHandler(this.BtnFinalizarVenta_Click);
            // 
            // FrmRealizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnFinalizarVenta);
            this.Controls.Add(this.BtnAgregarProducto);
            this.Controls.Add(this.BtnCorteCaja);
            this.Controls.Add(this.PSom2);
            this.Controls.Add(this.PSom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRealizarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "895, 611";
            this.Load += new System.EventHandler(this.FrmRealizarVenta_Load);
            this.Shown += new System.EventHandler(this.FrmRealizarVenta_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgCarrito)).EndInit();
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.Pdel.PerformLayout();
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgProductos;
        private System.Windows.Forms.DataGridView DtgCarrito;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label LblTotalVenta;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Panel PSom2;
        private System.Windows.Forms.Panel Pdel2;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCorteCaja;
        private System.Windows.Forms.Button BtnAgregarProducto;
        private System.Windows.Forms.Button BtnFinalizarVenta;
    }
}