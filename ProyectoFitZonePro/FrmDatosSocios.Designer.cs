namespace ProyectoFitZonePro
{
    partial class FrmDatosSocios
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.TxtMembresia = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtIdSocio = new System.Windows.Forms.TextBox();
            this.TxtCoso = new System.Windows.Forms.TextBox();
            this.TxtSeleccionarUsuario = new System.Windows.Forms.Button();
            this.BtnSeleccionarMembresia = new System.Windows.Forms.Button();
            this.CmbDuracion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(275, 306);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(149, 72);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(102, 306);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            // 
            // TxtMembresia
            // 
            this.TxtMembresia.Location = new System.Drawing.Point(307, 153);
            this.TxtMembresia.Name = "TxtMembresia";
            this.TxtMembresia.Size = new System.Drawing.Size(210, 30);
            this.TxtMembresia.TabIndex = 10;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(294, 76);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(210, 30);
            this.TxtNombre.TabIndex = 8;
            // 
            // TxtIdSocio
            // 
            this.TxtIdSocio.Location = new System.Drawing.Point(41, 76);
            this.TxtIdSocio.Name = "TxtIdSocio";
            this.TxtIdSocio.Size = new System.Drawing.Size(210, 30);
            this.TxtIdSocio.TabIndex = 7;
            // 
            // TxtCoso
            // 
            this.TxtCoso.Location = new System.Drawing.Point(41, 238);
            this.TxtCoso.Name = "TxtCoso";
            this.TxtCoso.Size = new System.Drawing.Size(210, 30);
            this.TxtCoso.TabIndex = 14;
            // 
            // TxtSeleccionarUsuario
            // 
            this.TxtSeleccionarUsuario.Location = new System.Drawing.Point(561, 73);
            this.TxtSeleccionarUsuario.Name = "TxtSeleccionarUsuario";
            this.TxtSeleccionarUsuario.Size = new System.Drawing.Size(119, 33);
            this.TxtSeleccionarUsuario.TabIndex = 15;
            this.TxtSeleccionarUsuario.Text = "Seleccionar";
            this.TxtSeleccionarUsuario.UseVisualStyleBackColor = true;
            // 
            // BtnSeleccionarMembresia
            // 
            this.BtnSeleccionarMembresia.Location = new System.Drawing.Point(561, 152);
            this.BtnSeleccionarMembresia.Name = "BtnSeleccionarMembresia";
            this.BtnSeleccionarMembresia.Size = new System.Drawing.Size(119, 33);
            this.BtnSeleccionarMembresia.TabIndex = 16;
            this.BtnSeleccionarMembresia.Text = "Seleccionar";
            this.BtnSeleccionarMembresia.UseVisualStyleBackColor = true;
            // 
            // CmbDuracion
            // 
            this.CmbDuracion.FormattingEnabled = true;
            this.CmbDuracion.Location = new System.Drawing.Point(41, 150);
            this.CmbDuracion.Name = "CmbDuracion";
            this.CmbDuracion.Size = new System.Drawing.Size(216, 33);
            this.CmbDuracion.TabIndex = 17;
            // 
            // FrmDatosSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.CmbDuracion);
            this.Controls.Add(this.BtnSeleccionarMembresia);
            this.Controls.Add(this.TxtSeleccionarUsuario);
            this.Controls.Add(this.TxtCoso);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtMembresia);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtIdSocio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDatosSocios";
            this.Text = "FrmDatosSocios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtMembresia;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtIdSocio;
        private System.Windows.Forms.TextBox TxtCoso;
        private System.Windows.Forms.Button TxtSeleccionarUsuario;
        private System.Windows.Forms.Button BtnSeleccionarMembresia;
        private System.Windows.Forms.ComboBox CmbDuracion;
    }
}