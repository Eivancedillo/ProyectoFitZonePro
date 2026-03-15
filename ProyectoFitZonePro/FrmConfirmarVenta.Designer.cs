namespace ProyectoFitZonePro
{
    partial class FrmConfirmarVenta
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
            this.CmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbSocios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbMetodoPago
            // 
            this.CmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMetodoPago.FormattingEnabled = true;
            this.CmbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia"});
            this.CmbMetodoPago.Location = new System.Drawing.Point(137, 83);
            this.CmbMetodoPago.Name = "CmbMetodoPago";
            this.CmbMetodoPago.Size = new System.Drawing.Size(247, 28);
            this.CmbMetodoPago.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Metodo de Pago:";
            // 
            // CmbSocios
            // 
            this.CmbSocios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSocios.FormattingEnabled = true;
            this.CmbSocios.Location = new System.Drawing.Point(70, 27);
            this.CmbSocios.Name = "CmbSocios";
            this.CmbSocios.Size = new System.Drawing.Size(314, 28);
            this.CmbSocios.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cliente:";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(16, 188);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(93, 43);
            this.BtnAceptar.TabIndex = 15;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(291, 188);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(93, 43);
            this.BtnCancelar.TabIndex = 16;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmConfirmarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 268);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.CmbMetodoPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbSocios);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConfirmarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfirmarVenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbMetodoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbSocios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
    }
}