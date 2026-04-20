namespace ProyectoFitZonePro
{
    partial class FrmInventario
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
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.DtgInventario = new System.Windows.Forms.DataGridView();
            this.PSom = new System.Windows.Forms.Panel();
            this.Pdel = new System.Windows.Forms.Panel();
            this.LblEstado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgInventario)).BeginInit();
            this.PSom.SuspendLayout();
            this.Pdel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBusqueda.Location = new System.Drawing.Point(20, 28);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(547, 26);
            this.TxtBusqueda.TabIndex = 1;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // DtgInventario
            // 
            this.DtgInventario.AllowUserToAddRows = false;
            this.DtgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgInventario.Location = new System.Drawing.Point(20, 84);
            this.DtgInventario.Name = "DtgInventario";
            this.DtgInventario.ReadOnly = true;
            this.DtgInventario.Size = new System.Drawing.Size(759, 357);
            this.DtgInventario.TabIndex = 2;
            // 
            // PSom
            // 
            this.PSom.Controls.Add(this.Pdel);
            this.PSom.Location = new System.Drawing.Point(40, 103);
            this.PSom.Name = "PSom";
            this.PSom.Size = new System.Drawing.Size(809, 467);
            this.PSom.TabIndex = 18;
            // 
            // Pdel
            // 
            this.Pdel.Controls.Add(this.DtgInventario);
            this.Pdel.Controls.Add(this.TxtBusqueda);
            this.Pdel.Location = new System.Drawing.Point(4, 4);
            this.Pdel.Name = "Pdel";
            this.Pdel.Size = new System.Drawing.Size(801, 459);
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
            this.LblEstado.TabIndex = 20;
            this.LblEstado.Text = "FitZone Pro sistema de administración";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Vista de ventas";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 611);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PSom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventario";
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgInventario)).EndInit();
            this.PSom.ResumeLayout(false);
            this.Pdel.ResumeLayout(false);
            this.Pdel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.DataGridView DtgInventario;
        private System.Windows.Forms.Panel PSom;
        private System.Windows.Forms.Panel Pdel;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.Label label3;
    }
}