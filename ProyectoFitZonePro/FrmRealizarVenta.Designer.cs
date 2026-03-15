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
            this.BtnCorteCaja = new System.Windows.Forms.Button();
            this.BtnAgregarProducto = new System.Windows.Forms.Button();
            this.BtnFinalizarVenta = new System.Windows.Forms.Button();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgProductos
            // 
            this.DtgProductos.AllowUserToAddRows = false;
            this.DtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProductos.Location = new System.Drawing.Point(12, 82);
            this.DtgProductos.Name = "DtgProductos";
            this.DtgProductos.Size = new System.Drawing.Size(521, 455);
            this.DtgProductos.TabIndex = 0;
            this.DtgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellClick);
            this.DtgProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellEnter);
            // 
            // DtgCarrito
            // 
            this.DtgCarrito.AllowUserToAddRows = false;
            this.DtgCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgCarrito.Location = new System.Drawing.Point(553, 82);
            this.DtgCarrito.Name = "DtgCarrito";
            this.DtgCarrito.Size = new System.Drawing.Size(584, 455);
            this.DtgCarrito.TabIndex = 1;
            // 
            // BtnCorteCaja
            // 
            this.BtnCorteCaja.Location = new System.Drawing.Point(12, 587);
            this.BtnCorteCaja.Name = "BtnCorteCaja";
            this.BtnCorteCaja.Size = new System.Drawing.Size(228, 70);
            this.BtnCorteCaja.TabIndex = 2;
            this.BtnCorteCaja.Text = "Corte de Caja";
            this.BtnCorteCaja.UseVisualStyleBackColor = true;
            this.BtnCorteCaja.Click += new System.EventHandler(this.BtnCorteCaja_Click);
            // 
            // BtnAgregarProducto
            // 
            this.BtnAgregarProducto.Location = new System.Drawing.Point(424, 587);
            this.BtnAgregarProducto.Name = "BtnAgregarProducto";
            this.BtnAgregarProducto.Size = new System.Drawing.Size(228, 70);
            this.BtnAgregarProducto.TabIndex = 3;
            this.BtnAgregarProducto.Text = "Agregar Producto";
            this.BtnAgregarProducto.UseVisualStyleBackColor = true;
            this.BtnAgregarProducto.Click += new System.EventHandler(this.BtnAgregarProducto_Click);
            // 
            // BtnFinalizarVenta
            // 
            this.BtnFinalizarVenta.Location = new System.Drawing.Point(909, 587);
            this.BtnFinalizarVenta.Name = "BtnFinalizarVenta";
            this.BtnFinalizarVenta.Size = new System.Drawing.Size(228, 70);
            this.BtnFinalizarVenta.TabIndex = 4;
            this.BtnFinalizarVenta.Text = "Finalizar Venta";
            this.BtnFinalizarVenta.UseVisualStyleBackColor = true;
            this.BtnFinalizarVenta.Click += new System.EventHandler(this.BtnFinalizarVenta_Click);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(86, 51);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(447, 26);
            this.TxtBusqueda.TabIndex = 5;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Producto:";
            // 
            // FrmRealizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.BtnFinalizarVenta);
            this.Controls.Add(this.BtnAgregarProducto);
            this.Controls.Add(this.BtnCorteCaja);
            this.Controls.Add(this.DtgCarrito);
            this.Controls.Add(this.DtgProductos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRealizarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRealizarVenta";
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgProductos;
        private System.Windows.Forms.DataGridView DtgCarrito;
        private System.Windows.Forms.Button BtnCorteCaja;
        private System.Windows.Forms.Button BtnAgregarProducto;
        private System.Windows.Forms.Button BtnFinalizarVenta;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label label1;
    }
}