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
            this.TxtCosto = new System.Windows.Forms.TextBox();
            this.BtnSeleccionarUsuario = new System.Windows.Forms.Button();
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
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(102, 306);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
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
            // TxtCosto
            // 
            this.TxtCosto.Location = new System.Drawing.Point(41, 238);
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(210, 30);
            this.TxtCosto.TabIndex = 14;
            // 
            // BtnSeleccionarUsuario
            // 
            this.BtnSeleccionarUsuario.Location = new System.Drawing.Point(561, 73);
            this.BtnSeleccionarUsuario.Name = "BtnSeleccionarUsuario";
            this.BtnSeleccionarUsuario.Size = new System.Drawing.Size(119, 33);
            this.BtnSeleccionarUsuario.TabIndex = 15;
            this.BtnSeleccionarUsuario.Text = "Seleccionar";
            this.BtnSeleccionarUsuario.UseVisualStyleBackColor = true;
            this.BtnSeleccionarUsuario.Click += new System.EventHandler(this.BtnSeleccionarUsuario_Click);
            // 
            // BtnSeleccionarMembresia
            // 
            this.BtnSeleccionarMembresia.Location = new System.Drawing.Point(561, 152);
            this.BtnSeleccionarMembresia.Name = "BtnSeleccionarMembresia";
            this.BtnSeleccionarMembresia.Size = new System.Drawing.Size(119, 33);
            this.BtnSeleccionarMembresia.TabIndex = 16;
            this.BtnSeleccionarMembresia.Text = "Seleccionar";
            this.BtnSeleccionarMembresia.UseVisualStyleBackColor = true;
            this.BtnSeleccionarMembresia.Click += new System.EventHandler(this.BtnSeleccionarMembresia_Click);
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
            this.Controls.Add(this.BtnSeleccionarUsuario);
            this.Controls.Add(this.TxtCosto);
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
        private System.Windows.Forms.TextBox TxtCosto;
        private System.Windows.Forms.Button BtnSeleccionarUsuario;
        private System.Windows.Forms.Button BtnSeleccionarMembresia;
        private System.Windows.Forms.ComboBox CmbDuracion;
    }
}