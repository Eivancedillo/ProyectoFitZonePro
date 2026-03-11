namespace ProyectoFitZonePro
{
    partial class FrmUsuarios
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
            this.DtgDatos = new System.Windows.Forms.DataGridView();
            this.BtnCrear = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.PnlTodos = new System.Windows.Forms.Panel();
            this.PnlActivos = new System.Windows.Forms.Panel();
            this.PnlInactivos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgDatos
            // 
            this.DtgDatos.AllowUserToAddRows = false;
            this.DtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDatos.Location = new System.Drawing.Point(52, 168);
            this.DtgDatos.Name = "DtgDatos";
            this.DtgDatos.ReadOnly = true;
            this.DtgDatos.RowHeadersWidth = 51;
            this.DtgDatos.RowTemplate.Height = 24;
            this.DtgDatos.Size = new System.Drawing.Size(820, 281);
            this.DtgDatos.TabIndex = 2;
            this.DtgDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatos_CellClick);
            // 
            // BtnCrear
            // 
            this.BtnCrear.Location = new System.Drawing.Point(954, 47);
            this.BtnCrear.Name = "BtnCrear";
            this.BtnCrear.Size = new System.Drawing.Size(117, 62);
            this.BtnCrear.TabIndex = 3;
            this.BtnCrear.Text = "Crear";
            this.BtnCrear.UseVisualStyleBackColor = true;
            this.BtnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(559, 132);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(313, 30);
            this.TxtBuscar.TabIndex = 4;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // PnlTodos
            // 
            this.PnlTodos.Location = new System.Drawing.Point(52, 127);
            this.PnlTodos.Name = "PnlTodos";
            this.PnlTodos.Size = new System.Drawing.Size(127, 35);
            this.PnlTodos.TabIndex = 5;
            // 
            // PnlActivos
            // 
            this.PnlActivos.Location = new System.Drawing.Point(185, 127);
            this.PnlActivos.Name = "PnlActivos";
            this.PnlActivos.Size = new System.Drawing.Size(127, 35);
            this.PnlActivos.TabIndex = 6;
            // 
            // PnlInactivos
            // 
            this.PnlInactivos.Location = new System.Drawing.Point(318, 127);
            this.PnlInactivos.Name = "PnlInactivos";
            this.PnlInactivos.Size = new System.Drawing.Size(127, 35);
            this.PnlInactivos.TabIndex = 6;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.PnlInactivos);
            this.Controls.Add(this.PnlActivos);
            this.Controls.Add(this.PnlTodos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.BtnCrear);
            this.Controls.Add(this.DtgDatos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUsuarios";
            this.Text = "FrmUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgDatos;
        private System.Windows.Forms.Button BtnCrear;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Panel PnlTodos;
        private System.Windows.Forms.Panel PnlActivos;
        private System.Windows.Forms.Panel PnlInactivos;
    }
}