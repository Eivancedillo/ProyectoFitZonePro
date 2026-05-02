namespace Manejadores
{
    partial class FrmAgregarProducto
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtDesc = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtgProductos = new System.Windows.Forms.DataGridView();
            this.PSom2 = new System.Windows.Forms.Panel();
            this.Pdel2 = new System.Windows.Forms.Panel();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.LblEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).BeginInit();
            this.PSom2.SuspendLayout();
            this.Pdel2.SuspendLayout();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(116, 22);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(268, 26);
            this.TxtNombre.TabIndex = 5;
            // 
            // TxtDesc
            // 
            this.TxtDesc.Location = new System.Drawing.Point(116, 73);
            this.TxtDesc.Multiline = true;
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(268, 186);
            this.TxtDesc.TabIndex = 6;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(116, 284);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(268, 26);
            this.TxtPrecio.TabIndex = 7;
            this.TxtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnAgregar.FlatAppearance.BorderSize = 0;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAgregar.Location = new System.Drawing.Point(31, 344);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(53, 46);
            this.BtnAgregar.TabIndex = 8;
            this.BtnAgregar.Text = "+";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnEliminar.Location = new System.Drawing.Point(90, 344);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(53, 46);
            this.BtnEliminar.TabIndex = 9;
            this.BtnEliminar.Text = "-";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // DtgProductos
            // 
            this.DtgProductos.AllowUserToAddRows = false;
            this.DtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProductos.Location = new System.Drawing.Point(19, 27);
            this.DtgProductos.Name = "DtgProductos";
            this.DtgProductos.ReadOnly = true;
            this.DtgProductos.Size = new System.Drawing.Size(366, 365);
            this.DtgProductos.TabIndex = 4;
            this.DtgProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProductos_CellClick);
            // 
            // PSom2
            // 
            this.PSom2.Controls.Add(this.Pdel2);
            this.PSom2.Location = new System.Drawing.Point(454, 93);
            this.PSom2.Name = "PSom2";
            this.PSom2.Size = new System.Drawing.Size(408, 425);
            this.PSom2.TabIndex = 17;
            // 
            // Pdel2
            // 
            this.Pdel2.Controls.Add(this.BtnActualizar);
            this.Pdel2.Controls.Add(this.TxtDesc);
            this.Pdel2.Controls.Add(this.BtnEliminar);
            this.Pdel2.Controls.Add(this.label1);
            this.Pdel2.Controls.Add(this.BtnAgregar);
            this.Pdel2.Controls.Add(this.label2);
            this.Pdel2.Controls.Add(this.TxtPrecio);
            this.Pdel2.Controls.Add(this.label3);
            this.Pdel2.Controls.Add(this.TxtNombre);
            this.Pdel2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pdel2.Location = new System.Drawing.Point(4, 4);
            this.Pdel2.Name = "Pdel2";
            this.Pdel2.Size = new System.Drawing.Size(400, 417);
            this.Pdel2.TabIndex = 9;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnActualizar.FlatAppearance.BorderSize = 0;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnActualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnActualizar.Location = new System.Drawing.Point(189, 344);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(195, 46);
            this.BtnActualizar.TabIndex = 18;
            this.BtnActualizar.Text = "Actualizar Producto";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(26, 93);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(408, 425);
            this.PSom.TabIndex = 16;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.DtgProductos);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(400, 417);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "Vista de ventas";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(776, 30);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(86, 25);
            this.BtnCancelar.TabIndex = 22;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PSom2);
            this.Controls.Add(this.PSom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarProducto";
            this.Load += new System.EventHandler(this.FrmAgregarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgProductos)).EndInit();
            this.PSom2.ResumeLayout(false);
            this.Pdel2.ResumeLayout(false);
            this.Pdel2.PerformLayout();
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtDesc;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgProductos;
        private System.Windows.Forms.Panel PSom2;
        private System.Windows.Forms.Panel Pdel2;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnCancelar;
    }
}