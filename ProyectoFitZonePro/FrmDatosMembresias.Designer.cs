namespace ProyectoFitZonePro
{
    partial class FrmDatosMembresias
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
            this.TxtCostoMensual = new System.Windows.Forms.TextBox();
            this.TxtCostoAnual = new System.Windows.Forms.TextBox();
            this.TxtCostoSemestral = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnAnadirBeneficios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(56, 68);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(218, 30);
            this.TxtNombre.TabIndex = 0;
            // 
            // TxtCostoMensual
            // 
            this.TxtCostoMensual.Location = new System.Drawing.Point(56, 138);
            this.TxtCostoMensual.Name = "TxtCostoMensual";
            this.TxtCostoMensual.Size = new System.Drawing.Size(218, 30);
            this.TxtCostoMensual.TabIndex = 1;
            // 
            // TxtCostoAnual
            // 
            this.TxtCostoAnual.Location = new System.Drawing.Point(56, 204);
            this.TxtCostoAnual.Name = "TxtCostoAnual";
            this.TxtCostoAnual.Size = new System.Drawing.Size(218, 30);
            this.TxtCostoAnual.TabIndex = 2;
            // 
            // TxtCostoSemestral
            // 
            this.TxtCostoSemestral.Location = new System.Drawing.Point(324, 138);
            this.TxtCostoSemestral.Name = "TxtCostoSemestral";
            this.TxtCostoSemestral.Size = new System.Drawing.Size(218, 30);
            this.TxtCostoSemestral.TabIndex = 3;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(298, 283);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(149, 72);
            this.BtnCancelar.TabIndex = 32;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(125, 283);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 31;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnAnadirBeneficios
            // 
            this.BtnAnadirBeneficios.Location = new System.Drawing.Point(324, 204);
            this.BtnAnadirBeneficios.Name = "BtnAnadirBeneficios";
            this.BtnAnadirBeneficios.Size = new System.Drawing.Size(189, 32);
            this.BtnAnadirBeneficios.TabIndex = 33;
            this.BtnAnadirBeneficios.Text = "Añadir beneficios";
            this.BtnAnadirBeneficios.UseVisualStyleBackColor = true;
            this.BtnAnadirBeneficios.Click += new System.EventHandler(this.BtnAnadirBeneficios_Click);
            // 
            // FrmDatosMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 489);
            this.Controls.Add(this.BtnAnadirBeneficios);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtCostoSemestral);
            this.Controls.Add(this.TxtCostoAnual);
            this.Controls.Add(this.TxtCostoMensual);
            this.Controls.Add(this.TxtNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDatosMembresias";
            this.Text = "FrmDatosMembresias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtCostoMensual;
        private System.Windows.Forms.TextBox TxtCostoAnual;
        private System.Windows.Forms.TextBox TxtCostoSemestral;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnAnadirBeneficios;
    }
}