namespace ProyectoFitZonePro
{
    partial class FrmBeneficios
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
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.DtgDatosExistentes = new System.Windows.Forms.DataGridView();
            this.DtgDatosAgregados = new System.Windows.Forms.DataGridView();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatosExistentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatosAgregados)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(63, 85);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(257, 30);
            this.TxtNombre.TabIndex = 0;
            // 
            // DtgDatosExistentes
            // 
            this.DtgDatosExistentes.AllowUserToAddRows = false;
            this.DtgDatosExistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDatosExistentes.Location = new System.Drawing.Point(63, 169);
            this.DtgDatosExistentes.Name = "DtgDatosExistentes";
            this.DtgDatosExistentes.ReadOnly = true;
            this.DtgDatosExistentes.RowHeadersWidth = 51;
            this.DtgDatosExistentes.RowTemplate.Height = 24;
            this.DtgDatosExistentes.Size = new System.Drawing.Size(310, 232);
            this.DtgDatosExistentes.TabIndex = 2;
            this.DtgDatosExistentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatosExistentes_CellClick);
            // 
            // DtgDatosAgregados
            // 
            this.DtgDatosAgregados.AllowUserToAddRows = false;
            this.DtgDatosAgregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDatosAgregados.Location = new System.Drawing.Point(491, 169);
            this.DtgDatosAgregados.Name = "DtgDatosAgregados";
            this.DtgDatosAgregados.ReadOnly = true;
            this.DtgDatosAgregados.RowHeadersWidth = 51;
            this.DtgDatosAgregados.RowTemplate.Height = 24;
            this.DtgDatosAgregados.Size = new System.Drawing.Size(310, 232);
            this.DtgDatosAgregados.TabIndex = 3;
            this.DtgDatosAgregados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatosAgregados_CellClick);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(343, 85);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(57, 31);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "+";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(271, 432);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(149, 72);
            this.BtnCancelar.TabIndex = 32;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(98, 432);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 31;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // FrmBeneficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 553);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.DtgDatosAgregados);
            this.Controls.Add(this.DtgDatosExistentes);
            this.Controls.Add(this.TxtNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmBeneficios";
            this.Text = "FrmBeneficios";
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatosExistentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatosAgregados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DataGridView DtgDatosExistentes;
        private System.Windows.Forms.DataGridView DtgDatosAgregados;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
    }
}