namespace ProyectoFitZonePro
{
    partial class FrmCorteCaja
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
            this.LblMuestra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblMuestra
            // 
            this.LblMuestra.Location = new System.Drawing.Point(12, 9);
            this.LblMuestra.Name = "LblMuestra";
            this.LblMuestra.Size = new System.Drawing.Size(455, 154);
            this.LblMuestra.TabIndex = 0;
            this.LblMuestra.Text = "label1";
            this.LblMuestra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 172);
            this.Controls.Add(this.LblMuestra);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCorteCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCorteCaja";
            this.Load += new System.EventHandler(this.FrmCorteCaja_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMuestra;
    }
}