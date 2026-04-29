namespace ProyectoFitZonePro
{
    partial class FrmMembresias
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
            this.BtnCrear = new System.Windows.Forms.Button();
            this.DtgDatos = new System.Windows.Forms.DataGridView();
            this.PTop4 = new System.Windows.Forms.Panel();
            this.PTop1 = new System.Windows.Forms.Panel();
            this.LblBeneficiosTop1 = new System.Windows.Forms.Label();
            this.LblMensualTop1 = new System.Windows.Forms.Label();
            this.LblNombreTop1 = new System.Windows.Forms.Label();
            this.PTop5 = new System.Windows.Forms.Panel();
            this.PTop2 = new System.Windows.Forms.Panel();
            this.LblBeneficiosTop2 = new System.Windows.Forms.Label();
            this.LblNombreTop2 = new System.Windows.Forms.Label();
            this.PTop6 = new System.Windows.Forms.Panel();
            this.PTop3 = new System.Windows.Forms.Panel();
            this.LblBeneficiosTop3 = new System.Windows.Forms.Label();
            this.LblNombreTop3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblEstado = new System.Windows.Forms.Label();
            this.Ps1 = new System.Windows.Forms.Panel();
            this.Ps2 = new System.Windows.Forms.Panel();
            this.Ps3 = new System.Windows.Forms.Panel();
            this.LblSemestralTop1 = new System.Windows.Forms.Label();
            this.LblAnualTop1 = new System.Windows.Forms.Label();
            this.LblAnualTop2 = new System.Windows.Forms.Label();
            this.LblSemestralTop2 = new System.Windows.Forms.Label();
            this.LblMensualTop2 = new System.Windows.Forms.Label();
            this.LblAnualTop3 = new System.Windows.Forms.Label();
            this.LblSemestralTop3 = new System.Windows.Forms.Label();
            this.LblMensualTop3 = new System.Windows.Forms.Label();
            this.PnlContenedorBeneficios1 = new System.Windows.Forms.Panel();
            this.PnlContenedorBeneficios = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlContenedorBeneficio3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).BeginInit();
            this.PTop4.SuspendLayout();
            this.PTop1.SuspendLayout();
            this.PTop5.SuspendLayout();
            this.PTop2.SuspendLayout();
            this.PTop6.SuspendLayout();
            this.PTop3.SuspendLayout();
            this.Ps1.SuspendLayout();
            this.Ps2.SuspendLayout();
            this.Ps3.SuspendLayout();
            this.PnlContenedorBeneficios1.SuspendLayout();
            this.PnlContenedorBeneficios.SuspendLayout();
            this.PnlContenedorBeneficio3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCrear
            // 
            this.BtnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.BtnCrear.FlatAppearance.BorderSize = 0;
            this.BtnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrear.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCrear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCrear.Location = new System.Drawing.Point(596, 12);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(253, 34);
            this.BtnCrear.TabIndex = 0;
            this.BtnCrear.Text = "Crear nuevo plan";
            this.BtnCrear.UseVisualStyleBackColor = false;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // DtgDatos
            // 
            this.DtgDatos.AllowUserToAddRows = false;
            this.DtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDatos.Location = new System.Drawing.Point(40, 383);
            this.DtgDatos.Name = "DtgDatos";
            this.DtgDatos.ReadOnly = true;
            this.DtgDatos.RowHeadersWidth = 51;
            this.DtgDatos.RowTemplate.Height = 24;
            this.DtgDatos.Size = new System.Drawing.Size(808, 216);
            this.DtgDatos.TabIndex = 1;
            this.DtgDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatos_CellClick);
            // 
            // PTop4
            // 
            this.PTop4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.PTop4.Controls.Add(this.PTop1);
            this.PTop4.Location = new System.Drawing.Point(3, 3);
            this.PTop4.Name = "PTop4";
            this.PTop4.Size = new System.Drawing.Size(234, 295);
            this.PTop4.TabIndex = 2;
            // 
            // PTop1
            // 
            this.PTop1.BackColor = System.Drawing.Color.White;
            this.PTop1.Controls.Add(this.PnlContenedorBeneficios1);
            this.PTop1.Controls.Add(this.LblAnualTop1);
            this.PTop1.Controls.Add(this.LblSemestralTop1);
            this.PTop1.Controls.Add(this.LblMensualTop1);
            this.PTop1.Controls.Add(this.LblNombreTop1);
            this.PTop1.Location = new System.Drawing.Point(3, 3);
            this.PTop1.Name = "PTop1";
            this.PTop1.Size = new System.Drawing.Size(228, 289);
            this.PTop1.TabIndex = 3;
            // 
            // LblBeneficiosTop1
            // 
            this.LblBeneficiosTop1.AutoEllipsis = true;
            this.LblBeneficiosTop1.AutoSize = true;
            this.LblBeneficiosTop1.Location = new System.Drawing.Point(0, 0);
            this.LblBeneficiosTop1.Name = "LblBeneficiosTop1";
            this.LblBeneficiosTop1.Size = new System.Drawing.Size(100, 25);
            this.LblBeneficiosTop1.TabIndex = 2;
            this.LblBeneficiosTop1.Text = "beneficios";
            // 
            // LblMensualTop1
            // 
            this.LblMensualTop1.AutoSize = true;
            this.LblMensualTop1.Location = new System.Drawing.Point(3, 58);
            this.LblMensualTop1.Name = "LblMensualTop1";
            this.LblMensualTop1.Size = new System.Drawing.Size(150, 25);
            this.LblMensualTop1.TabIndex = 1;
            this.LblMensualTop1.Text = "preciosMensual";
            // 
            // LblNombreTop1
            // 
            this.LblNombreTop1.AutoSize = true;
            this.LblNombreTop1.Location = new System.Drawing.Point(1, 21);
            this.LblNombreTop1.Name = "LblNombreTop1";
            this.LblNombreTop1.Size = new System.Drawing.Size(78, 25);
            this.LblNombreTop1.TabIndex = 0;
            this.LblNombreTop1.Text = "nombre";
            // 
            // PTop5
            // 
            this.PTop5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.PTop5.Controls.Add(this.PTop2);
            this.PTop5.Location = new System.Drawing.Point(3, 3);
            this.PTop5.Name = "PTop5";
            this.PTop5.Size = new System.Drawing.Size(234, 295);
            this.PTop5.TabIndex = 3;
            // 
            // PTop2
            // 
            this.PTop2.BackColor = System.Drawing.Color.White;
            this.PTop2.Controls.Add(this.PnlContenedorBeneficios);
            this.PTop2.Controls.Add(this.LblAnualTop2);
            this.PTop2.Controls.Add(this.LblBeneficiosTop2);
            this.PTop2.Controls.Add(this.LblSemestralTop2);
            this.PTop2.Controls.Add(this.LblNombreTop2);
            this.PTop2.Controls.Add(this.LblMensualTop2);
            this.PTop2.Location = new System.Drawing.Point(3, 3);
            this.PTop2.Name = "PTop2";
            this.PTop2.Size = new System.Drawing.Size(228, 289);
            this.PTop2.TabIndex = 6;
            // 
            // LblBeneficiosTop2
            // 
            this.LblBeneficiosTop2.AutoEllipsis = true;
            this.LblBeneficiosTop2.Location = new System.Drawing.Point(3, 170);
            this.LblBeneficiosTop2.Name = "LblBeneficiosTop2";
            this.LblBeneficiosTop2.Size = new System.Drawing.Size(211, 100);
            this.LblBeneficiosTop2.TabIndex = 5;
            this.LblBeneficiosTop2.Text = "xxx";
            // 
            // LblNombreTop2
            // 
            this.LblNombreTop2.AutoSize = true;
            this.LblNombreTop2.Location = new System.Drawing.Point(3, 21);
            this.LblNombreTop2.Name = "LblNombreTop2";
            this.LblNombreTop2.Size = new System.Drawing.Size(42, 25);
            this.LblNombreTop2.TabIndex = 3;
            this.LblNombreTop2.Text = "xxx";
            // 
            // PTop6
            // 
            this.PTop6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(166)))), ((int)(((byte)(121)))));
            this.PTop6.Controls.Add(this.PTop3);
            this.PTop6.Location = new System.Drawing.Point(3, 3);
            this.PTop6.Name = "PTop6";
            this.PTop6.Size = new System.Drawing.Size(234, 295);
            this.PTop6.TabIndex = 3;
            // 
            // PTop3
            // 
            this.PTop3.BackColor = System.Drawing.Color.White;
            this.PTop3.Controls.Add(this.PnlContenedorBeneficio3);
            this.PTop3.Controls.Add(this.LblAnualTop3);
            this.PTop3.Controls.Add(this.LblBeneficiosTop3);
            this.PTop3.Controls.Add(this.LblSemestralTop3);
            this.PTop3.Controls.Add(this.LblNombreTop3);
            this.PTop3.Controls.Add(this.LblMensualTop3);
            this.PTop3.Location = new System.Drawing.Point(3, 3);
            this.PTop3.Name = "PTop3";
            this.PTop3.Size = new System.Drawing.Size(228, 289);
            this.PTop3.TabIndex = 9;
            // 
            // LblBeneficiosTop3
            // 
            this.LblBeneficiosTop3.AutoEllipsis = true;
            this.LblBeneficiosTop3.Location = new System.Drawing.Point(3, 170);
            this.LblBeneficiosTop3.Name = "LblBeneficiosTop3";
            this.LblBeneficiosTop3.Size = new System.Drawing.Size(222, 100);
            this.LblBeneficiosTop3.TabIndex = 8;
            this.LblBeneficiosTop3.Text = "xxx";
            // 
            // LblNombreTop3
            // 
            this.LblNombreTop3.AutoSize = true;
            this.LblNombreTop3.Location = new System.Drawing.Point(3, 21);
            this.LblNombreTop3.Name = "LblNombreTop3";
            this.LblNombreTop3.Size = new System.Drawing.Size(42, 25);
            this.LblNombreTop3.TabIndex = 6;
            this.LblNombreTop3.Text = "xxx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vista de membresias";
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEstado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblEstado.Location = new System.Drawing.Point(12, 30);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(342, 20);
            this.LblEstado.TabIndex = 5;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // Ps1
            // 
            this.Ps1.Controls.Add(this.PTop4);
            this.Ps1.Location = new System.Drawing.Point(40, 63);
            this.Ps1.Name = "Ps1";
            this.Ps1.Size = new System.Drawing.Size(240, 301);
            this.Ps1.TabIndex = 6;
            // 
            // Ps2
            // 
            this.Ps2.Controls.Add(this.PTop5);
            this.Ps2.Location = new System.Drawing.Point(324, 63);
            this.Ps2.Name = "Ps2";
            this.Ps2.Size = new System.Drawing.Size(240, 301);
            this.Ps2.TabIndex = 7;
            // 
            // Ps3
            // 
            this.Ps3.Controls.Add(this.PTop6);
            this.Ps3.Location = new System.Drawing.Point(608, 63);
            this.Ps3.Name = "Ps3";
            this.Ps3.Size = new System.Drawing.Size(240, 301);
            this.Ps3.TabIndex = 8;
            // 
            // LblSemestralTop1
            // 
            this.LblSemestralTop1.AutoSize = true;
            this.LblSemestralTop1.Location = new System.Drawing.Point(3, 93);
            this.LblSemestralTop1.Name = "LblSemestralTop1";
            this.LblSemestralTop1.Size = new System.Drawing.Size(163, 25);
            this.LblSemestralTop1.TabIndex = 3;
            this.LblSemestralTop1.Text = "preciosSemestral";
            // 
            // LblAnualTop1
            // 
            this.LblAnualTop1.AutoSize = true;
            this.LblAnualTop1.Location = new System.Drawing.Point(3, 127);
            this.LblAnualTop1.Name = "LblAnualTop1";
            this.LblAnualTop1.Size = new System.Drawing.Size(126, 25);
            this.LblAnualTop1.TabIndex = 4;
            this.LblAnualTop1.Text = "preciosAnual";
            // 
            // LblAnualTop2
            // 
            this.LblAnualTop2.AutoSize = true;
            this.LblAnualTop2.Location = new System.Drawing.Point(3, 127);
            this.LblAnualTop2.Name = "LblAnualTop2";
            this.LblAnualTop2.Size = new System.Drawing.Size(126, 25);
            this.LblAnualTop2.TabIndex = 7;
            this.LblAnualTop2.Text = "preciosAnual";
            // 
            // LblSemestralTop2
            // 
            this.LblSemestralTop2.AutoSize = true;
            this.LblSemestralTop2.Location = new System.Drawing.Point(3, 93);
            this.LblSemestralTop2.Name = "LblSemestralTop2";
            this.LblSemestralTop2.Size = new System.Drawing.Size(163, 25);
            this.LblSemestralTop2.TabIndex = 6;
            this.LblSemestralTop2.Text = "preciosSemestral";
            // 
            // LblMensualTop2
            // 
            this.LblMensualTop2.AutoSize = true;
            this.LblMensualTop2.Location = new System.Drawing.Point(3, 58);
            this.LblMensualTop2.Name = "LblMensualTop2";
            this.LblMensualTop2.Size = new System.Drawing.Size(150, 25);
            this.LblMensualTop2.TabIndex = 5;
            this.LblMensualTop2.Text = "preciosMensual";
            // 
            // LblAnualTop3
            // 
            this.LblAnualTop3.AutoSize = true;
            this.LblAnualTop3.Location = new System.Drawing.Point(3, 127);
            this.LblAnualTop3.Name = "LblAnualTop3";
            this.LblAnualTop3.Size = new System.Drawing.Size(126, 25);
            this.LblAnualTop3.TabIndex = 10;
            this.LblAnualTop3.Text = "preciosAnual";
            // 
            // LblSemestralTop3
            // 
            this.LblSemestralTop3.AutoSize = true;
            this.LblSemestralTop3.Location = new System.Drawing.Point(3, 93);
            this.LblSemestralTop3.Name = "LblSemestralTop3";
            this.LblSemestralTop3.Size = new System.Drawing.Size(163, 25);
            this.LblSemestralTop3.TabIndex = 9;
            this.LblSemestralTop3.Text = "preciosSemestral";
            // 
            // LblMensualTop3
            // 
            this.LblMensualTop3.AutoSize = true;
            this.LblMensualTop3.Location = new System.Drawing.Point(3, 58);
            this.LblMensualTop3.Name = "LblMensualTop3";
            this.LblMensualTop3.Size = new System.Drawing.Size(150, 25);
            this.LblMensualTop3.TabIndex = 8;
            this.LblMensualTop3.Text = "preciosMensual";
            // 
            // PnlContenedorBeneficios1
            // 
            this.PnlContenedorBeneficios1.AutoScroll = true;
            this.PnlContenedorBeneficios1.BackColor = System.Drawing.Color.Transparent;
            this.PnlContenedorBeneficios1.Controls.Add(this.LblBeneficiosTop1);
            this.PnlContenedorBeneficios1.Location = new System.Drawing.Point(6, 170);
            this.PnlContenedorBeneficios1.Name = "PnlContenedorBeneficios1";
            this.PnlContenedorBeneficios1.Size = new System.Drawing.Size(219, 100);
            this.PnlContenedorBeneficios1.TabIndex = 9;
            // 
            // PnlContenedorBeneficios
            // 
            this.PnlContenedorBeneficios.AutoScroll = true;
            this.PnlContenedorBeneficios.BackColor = System.Drawing.Color.Transparent;
            this.PnlContenedorBeneficios.Controls.Add(this.label1);
            this.PnlContenedorBeneficios.Location = new System.Drawing.Point(3, 170);
            this.PnlContenedorBeneficios.Name = "PnlContenedorBeneficios";
            this.PnlContenedorBeneficios.Size = new System.Drawing.Size(219, 100);
            this.PnlContenedorBeneficios.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "beneficios";
            // 
            // PnlContenedorBeneficio3
            // 
            this.PnlContenedorBeneficio3.AutoScroll = true;
            this.PnlContenedorBeneficio3.BackColor = System.Drawing.Color.Transparent;
            this.PnlContenedorBeneficio3.Controls.Add(this.label2);
            this.PnlContenedorBeneficio3.Location = new System.Drawing.Point(3, 170);
            this.PnlContenedorBeneficio3.Name = "PnlContenedorBeneficio3";
            this.PnlContenedorBeneficio3.Size = new System.Drawing.Size(219, 100);
            this.PnlContenedorBeneficio3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "beneficios";
            // 
            // FrmMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.Ps3);
            this.Controls.Add(this.Ps2);
            this.Controls.Add(this.Ps1);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtgDatos);
            this.Controls.Add(this.BtnCrear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMembresias";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmMembresias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).EndInit();
            this.PTop4.ResumeLayout(false);
            this.PTop1.ResumeLayout(false);
            this.PTop1.PerformLayout();
            this.PTop5.ResumeLayout(false);
            this.PTop2.ResumeLayout(false);
            this.PTop2.PerformLayout();
            this.PTop6.ResumeLayout(false);
            this.PTop3.ResumeLayout(false);
            this.PTop3.PerformLayout();
            this.Ps1.ResumeLayout(false);
            this.Ps2.ResumeLayout(false);
            this.Ps3.ResumeLayout(false);
            this.PnlContenedorBeneficios1.ResumeLayout(false);
            this.PnlContenedorBeneficios1.PerformLayout();
            this.PnlContenedorBeneficios.ResumeLayout(false);
            this.PnlContenedorBeneficios.PerformLayout();
            this.PnlContenedorBeneficio3.ResumeLayout(false);
            this.PnlContenedorBeneficio3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.DataGridView DtgDatos;
        private System.Windows.Forms.Panel PTop4;
        private System.Windows.Forms.Panel PTop5;
        private System.Windows.Forms.Panel PTop6;
        private System.Windows.Forms.Label LblBeneficiosTop1;
        private System.Windows.Forms.Label LblMensualTop1;
        private System.Windows.Forms.Label LblNombreTop1;
        private System.Windows.Forms.Label LblBeneficiosTop2;
        private System.Windows.Forms.Label LblNombreTop2;
        private System.Windows.Forms.Label LblBeneficiosTop3;
        private System.Windows.Forms.Label LblNombreTop3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Panel Ps1;
        private System.Windows.Forms.Panel Ps2;
        private System.Windows.Forms.Panel Ps3;
        private System.Windows.Forms.Panel PTop1;
        private System.Windows.Forms.Panel PTop2;
        private System.Windows.Forms.Panel PTop3;
        private System.Windows.Forms.Label LblAnualTop1;
        private System.Windows.Forms.Label LblSemestralTop1;
        private System.Windows.Forms.Label LblAnualTop2;
        private System.Windows.Forms.Label LblSemestralTop2;
        private System.Windows.Forms.Label LblMensualTop2;
        private System.Windows.Forms.Label LblAnualTop3;
        private System.Windows.Forms.Label LblSemestralTop3;
        private System.Windows.Forms.Label LblMensualTop3;
        private System.Windows.Forms.Panel PnlContenedorBeneficios1;
        private System.Windows.Forms.Panel PnlContenedorBeneficios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlContenedorBeneficio3;
        private System.Windows.Forms.Label label2;
    }
}