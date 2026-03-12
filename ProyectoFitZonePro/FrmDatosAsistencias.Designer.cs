namespace ProyectoFitZonePro
{
    partial class FrmDatosAsistencias
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
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.TxtVigencia = new System.Windows.Forms.TextBox();
            this.TxtMembresia = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtIdSocio = new System.Windows.Forms.TextBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(187, 232);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(149, 72);
            this.BtnCerrar.TabIndex = 13;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // TxtVigencia
            // 
            this.TxtVigencia.Location = new System.Drawing.Point(275, 139);
            this.TxtVigencia.Name = "TxtVigencia";
            this.TxtVigencia.Size = new System.Drawing.Size(210, 30);
            this.TxtVigencia.TabIndex = 10;
            // 
            // TxtMembresia
            // 
            this.TxtMembresia.Location = new System.Drawing.Point(41, 139);
            this.TxtMembresia.Name = "TxtMembresia";
            this.TxtMembresia.Size = new System.Drawing.Size(210, 30);
            this.TxtMembresia.TabIndex = 9;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(275, 50);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(210, 30);
            this.TxtNombre.TabIndex = 8;
            // 
            // TxtIdSocio
            // 
            this.TxtIdSocio.Location = new System.Drawing.Point(41, 50);
            this.TxtIdSocio.Name = "TxtIdSocio";
            this.TxtIdSocio.Size = new System.Drawing.Size(210, 30);
            this.TxtIdSocio.TabIndex = 7;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Location = new System.Drawing.Point(140, 338);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(64, 25);
            this.LblEstado.TabIndex = 14;
            this.LblEstado.Text = "label1";
            // 
            // FrmDatosAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 453);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.TxtVigencia);
            this.Controls.Add(this.TxtMembresia);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtIdSocio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDatosAsistencias";
            this.Text = "FrmDatosAsistencias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.TextBox TxtVigencia;
        private System.Windows.Forms.TextBox TxtMembresia;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtIdSocio;
        private System.Windows.Forms.Label LblEstado;
    }
}