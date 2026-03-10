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
            this.RndVer = new System.Windows.Forms.RadioButton();
            this.RndCrear = new System.Windows.Forms.RadioButton();
            this.RndEliminar = new System.Windows.Forms.RadioButton();
            this.RndEditar = new System.Windows.Forms.RadioButton();
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
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(96, 313);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(149, 72);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
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
            // RndVer
            // 
            this.RndVer.AutoSize = true;
            this.RndVer.Location = new System.Drawing.Point(356, 206);
            this.RndVer.Name = "RndVer";
            this.RndVer.Size = new System.Drawing.Size(64, 29);
            this.RndVer.TabIndex = 15;
            this.RndVer.TabStop = true;
            this.RndVer.Text = "Ver";
            this.RndVer.UseVisualStyleBackColor = true;
            // 
            // RndCrear
            // 
            this.RndCrear.AutoSize = true;
            this.RndCrear.Location = new System.Drawing.Point(505, 206);
            this.RndCrear.Name = "RndCrear";
            this.RndCrear.Size = new System.Drawing.Size(82, 29);
            this.RndCrear.TabIndex = 16;
            this.RndCrear.TabStop = true;
            this.RndCrear.Text = "Crear";
            this.RndCrear.UseVisualStyleBackColor = true;
            // 
            // RndEliminar
            // 
            this.RndEliminar.AutoSize = true;
            this.RndEliminar.Location = new System.Drawing.Point(803, 206);
            this.RndEliminar.Name = "RndEliminar";
            this.RndEliminar.Size = new System.Drawing.Size(102, 29);
            this.RndEliminar.TabIndex = 18;
            this.RndEliminar.TabStop = true;
            this.RndEliminar.Text = "Eliminar";
            this.RndEliminar.UseVisualStyleBackColor = true;
            // 
            // RndEditar
            // 
            this.RndEditar.AutoSize = true;
            this.RndEditar.Location = new System.Drawing.Point(654, 206);
            this.RndEditar.Name = "RndEditar";
            this.RndEditar.Size = new System.Drawing.Size(83, 29);
            this.RndEditar.TabIndex = 17;
            this.RndEditar.TabStop = true;
            this.RndEditar.Text = "Editar";
            this.RndEditar.UseVisualStyleBackColor = true;
            // 
            // FrmDatosTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.RndEliminar);
            this.Controls.Add(this.RndEditar);
            this.Controls.Add(this.RndCrear);
            this.Controls.Add(this.RndVer);
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
        private System.Windows.Forms.RadioButton RndVer;
        private System.Windows.Forms.RadioButton RndCrear;
        private System.Windows.Forms.RadioButton RndEliminar;
        private System.Windows.Forms.RadioButton RndEditar;
    }
}