namespace ProyectoFitZonePro
{
    partial class FrmDatosTrabajadores
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
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtNumero = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.CmbPermisos = new System.Windows.Forms.ComboBox();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.ChkVer = new System.Windows.Forms.CheckBox();
            this.ChkCrear = new System.Windows.Forms.CheckBox();
            this.ChkEditar = new System.Windows.Forms.CheckBox();
            this.ChkEliminar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(269, 313);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(149, 72);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(96, 313);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(63, 205);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(210, 30);
            this.TxtEmail.TabIndex = 10;
            // 
            // TxtNumero
            // 
            this.TxtNumero.Location = new System.Drawing.Point(63, 145);
            this.TxtNumero.Name = "TxtNumero";
            this.TxtNumero.Size = new System.Drawing.Size(210, 30);
            this.TxtNumero.TabIndex = 9;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(356, 71);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(210, 30);
            this.TxtPassword.TabIndex = 8;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(63, 71);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(210, 30);
            this.TxtNombre.TabIndex = 7;
            // 
            // CmbPermisos
            // 
            this.CmbPermisos.FormattingEnabled = true;
            this.CmbPermisos.Location = new System.Drawing.Point(356, 145);
            this.CmbPermisos.Name = "CmbPermisos";
            this.CmbPermisos.Size = new System.Drawing.Size(192, 33);
            this.CmbPermisos.TabIndex = 14;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(599, 140);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(104, 35);
            this.BtnEditar.TabIndex = 19;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // ChkVer
            // 
            this.ChkVer.AutoSize = true;
            this.ChkVer.Location = new System.Drawing.Point(356, 207);
            this.ChkVer.Name = "ChkVer";
            this.ChkVer.Size = new System.Drawing.Size(131, 29);
            this.ChkVer.TabIndex = 20;
            this.ChkVer.Text = "checkBox1";
            this.ChkVer.UseVisualStyleBackColor = true;
            // 
            // ChkCrear
            // 
            this.ChkCrear.AutoSize = true;
            this.ChkCrear.Location = new System.Drawing.Point(505, 207);
            this.ChkCrear.Name = "ChkCrear";
            this.ChkCrear.Size = new System.Drawing.Size(131, 29);
            this.ChkCrear.TabIndex = 21;
            this.ChkCrear.Text = "checkBox2";
            this.ChkCrear.UseVisualStyleBackColor = true;
            // 
            // ChkEditar
            // 
            this.ChkEditar.AutoSize = true;
            this.ChkEditar.Location = new System.Drawing.Point(654, 207);
            this.ChkEditar.Name = "ChkEditar";
            this.ChkEditar.Size = new System.Drawing.Size(131, 29);
            this.ChkEditar.TabIndex = 22;
            this.ChkEditar.Text = "checkBox3";
            this.ChkEditar.UseVisualStyleBackColor = true;
            // 
            // ChkEliminar
            // 
            this.ChkEliminar.AutoSize = true;
            this.ChkEliminar.Location = new System.Drawing.Point(803, 207);
            this.ChkEliminar.Name = "ChkEliminar";
            this.ChkEliminar.Size = new System.Drawing.Size(131, 29);
            this.ChkEliminar.TabIndex = 23;
            this.ChkEliminar.Text = "checkBox4";
            this.ChkEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmDatosTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.ChkEliminar);
            this.Controls.Add(this.ChkEditar);
            this.Controls.Add(this.ChkCrear);
            this.Controls.Add(this.ChkVer);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.CmbPermisos);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtNumero);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDatosTrabajadores";
            this.Text = "FrmDatosTrabajadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtNumero;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.ComboBox CmbPermisos;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.CheckBox ChkVer;
        private System.Windows.Forms.CheckBox ChkCrear;
        private System.Windows.Forms.CheckBox ChkEditar;
        private System.Windows.Forms.CheckBox ChkEliminar;
    }
}