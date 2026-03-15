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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.BtnRealizarEntrada = new System.Windows.Forms.Button();
            this.BtnVerEntradas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgProductos
            // 
            this.DtgProductos.AllowUserToAddRows = false;
            this.DtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProductos.Location = new System.Drawing.Point(12, 98);
            this.DtgProductos.Name = "DtgProductos";
            this.DtgProductos.ReadOnly = true;
            this.DtgProductos.Size = new System.Drawing.Size(455, 422);
            this.DtgProductos.TabIndex = 0;
            this.DtgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellClick);
            this.DtgProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellEnter);
            // 
            // DtgEntrada
            // 
            this.DtgEntrada.AllowUserToAddRows = false;
            this.DtgEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEntrada.Location = new System.Drawing.Point(473, 98);
            this.DtgEntrada.Name = "DtgEntrada";
            this.DtgEntrada.Size = new System.Drawing.Size(667, 422);
            this.DtgEntrada.TabIndex = 1;
            this.DtgEntrada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEntrada_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Producto:";
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(84, 66);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(383, 26);
            this.TxtBusqueda.TabIndex = 3;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // BtnRealizarEntrada
            // 
            this.BtnRealizarEntrada.Location = new System.Drawing.Point(16, 583);
            this.BtnRealizarEntrada.Name = "BtnRealizarEntrada";
            this.BtnRealizarEntrada.Size = new System.Drawing.Size(237, 63);
            this.BtnRealizarEntrada.TabIndex = 4;
            this.BtnRealizarEntrada.Text = "Realizar Entrada";
            this.BtnRealizarEntrada.UseVisualStyleBackColor = true;
            this.BtnRealizarEntrada.Click += new System.EventHandler(this.BtnRealizarEntrada_Click);
            // 
            // BtnVerEntradas
            // 
            this.BtnVerEntradas.Location = new System.Drawing.Point(473, 583);
            this.BtnVerEntradas.Name = "BtnVerEntradas";
            this.BtnVerEntradas.Size = new System.Drawing.Size(237, 63);
            this.BtnVerEntradas.TabIndex = 5;
            this.BtnVerEntradas.Text = "Ver Entradas";
            this.BtnVerEntradas.UseVisualStyleBackColor = true;
            this.BtnVerEntradas.Click += new System.EventHandler(this.BtnVerEntradas_Click);
            // 
            // FrmEntradasInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 679);
            this.Controls.Add(this.BtnVerEntradas);
            this.Controls.Add(this.BtnRealizarEntrada);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtgEntrada);
            this.Controls.Add(this.DtgProductos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmEntradasInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEntradasInventario";
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgProductos;
        private System.Windows.Forms.DataGridView DtgEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Button BtnRealizarEntrada;
        private System.Windows.Forms.Button BtnVerEntradas;
    }
}