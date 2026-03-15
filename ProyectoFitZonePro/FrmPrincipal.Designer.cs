namespace ProyectoFitZonePro
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnDashboard = new System.Windows.Forms.ToolStripButton();
            this.BtnAsistencias = new System.Windows.Forms.ToolStripButton();
            this.BtnMembresias = new System.Windows.Forms.ToolStripButton();
            this.BtnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.BtnMiembros = new System.Windows.Forms.ToolStripButton();
            this.BtnTienda = new System.Windows.Forms.ToolStripSplitButton();
            this.realizarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnEquipos = new System.Windows.Forms.ToolStripButton();
            this.BtnTrabajadores = new System.Windows.Forms.ToolStripButton();
            this.BtnSalir = new System.Windows.Forms.ToolStripButton();
            this.BtnCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnDashboard,
            this.BtnAsistencias,
            this.BtnMembresias,
            this.BtnUsuarios,
            this.BtnMiembros,
            this.BtnTienda,
            this.BtnEquipos,
            this.BtnTrabajadores,
            this.BtnSalir,
            this.BtnCerrarSesion});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(168, 703);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("BtnDashboard.Image")));
            this.BtnDashboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.Size = new System.Drawing.Size(165, 24);
            this.BtnDashboard.Text = "BtnDashboard";
            this.BtnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // BtnAsistencias
            // 
            this.BtnAsistencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAsistencias.Image = ((System.Drawing.Image)(resources.GetObject("BtnAsistencias.Image")));
            this.BtnAsistencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAsistencias.Name = "BtnAsistencias";
            this.BtnAsistencias.Size = new System.Drawing.Size(165, 24);
            this.BtnAsistencias.Text = "BtnAsistencias";
            this.BtnAsistencias.Click += new System.EventHandler(this.BtnAsistencias_Click);
            // 
            // BtnMembresias
            // 
            this.BtnMembresias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnMembresias.Image = ((System.Drawing.Image)(resources.GetObject("BtnMembresias.Image")));
            this.BtnMembresias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMembresias.Name = "BtnMembresias";
            this.BtnMembresias.Size = new System.Drawing.Size(165, 24);
            this.BtnMembresias.Text = "BtnMembresias";
            this.BtnMembresias.Click += new System.EventHandler(this.BtnMembresias_Click);
            // 
            // BtnUsuarios
            // 
            this.BtnUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsuarios.Image")));
            this.BtnUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUsuarios.Name = "BtnUsuarios";
            this.BtnUsuarios.Size = new System.Drawing.Size(165, 24);
            this.BtnUsuarios.Text = "BtnUsuarios";
            this.BtnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);
            // 
            // BtnMiembros
            // 
            this.BtnMiembros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnMiembros.Image = ((System.Drawing.Image)(resources.GetObject("BtnMiembros.Image")));
            this.BtnMiembros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMiembros.Name = "BtnMiembros";
            this.BtnMiembros.Size = new System.Drawing.Size(165, 24);
            this.BtnMiembros.Text = "BtnMiembros";
            this.BtnMiembros.Click += new System.EventHandler(this.BtnMiembros_Click);
            // 
            // BtnTienda
            // 
            this.BtnTienda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarVentaToolStripMenuItem,
            this.verVentasToolStripMenuItem,
            this.entradaDeInventarioToolStripMenuItem,
            this.inventarioToolStripMenuItem});
            this.BtnTienda.Name = "BtnTienda";
            this.BtnTienda.Size = new System.Drawing.Size(165, 19);
            this.BtnTienda.Text = "BtnTienda";
            // 
            // realizarVentaToolStripMenuItem
            // 
            this.realizarVentaToolStripMenuItem.Name = "realizarVentaToolStripMenuItem";
            this.realizarVentaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.realizarVentaToolStripMenuItem.Text = "Realizar Venta";
            this.realizarVentaToolStripMenuItem.Click += new System.EventHandler(this.realizarVentaToolStripMenuItem_Click);
            // 
            // verVentasToolStripMenuItem
            // 
            this.verVentasToolStripMenuItem.Name = "verVentasToolStripMenuItem";
            this.verVentasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.verVentasToolStripMenuItem.Text = "Ver ventas";
            // 
            // entradaDeInventarioToolStripMenuItem
            // 
            this.entradaDeInventarioToolStripMenuItem.Name = "entradaDeInventarioToolStripMenuItem";
            this.entradaDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.entradaDeInventarioToolStripMenuItem.Text = "Entrada de Inventario";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // BtnEquipos
            // 
            this.BtnEquipos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEquipos.Image = ((System.Drawing.Image)(resources.GetObject("BtnEquipos.Image")));
            this.BtnEquipos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEquipos.Name = "BtnEquipos";
            this.BtnEquipos.Size = new System.Drawing.Size(165, 24);
            this.BtnEquipos.Text = "BtnEquipos";
            this.BtnEquipos.Click += new System.EventHandler(this.BtnEquipos_Click);
            // 
            // BtnTrabajadores
            // 
            this.BtnTrabajadores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnTrabajadores.Image = ((System.Drawing.Image)(resources.GetObject("BtnTrabajadores.Image")));
            this.BtnTrabajadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTrabajadores.Name = "BtnTrabajadores";
            this.BtnTrabajadores.Size = new System.Drawing.Size(165, 24);
            this.BtnTrabajadores.Text = "BtnTrabajadores";
            this.BtnTrabajadores.Click += new System.EventHandler(this.BtnTrabajadores_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Image")));
            this.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(165, 24);
            this.BtnSalir.Text = "BtnSalir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrarSesion.Image")));
            this.BtnCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(165, 24);
            this.BtnCerrarSesion.Text = "BtnCerrarSesion";
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnDashboard;
        private System.Windows.Forms.ToolStripButton BtnAsistencias;
        private System.Windows.Forms.ToolStripButton BtnMembresias;
        private System.Windows.Forms.ToolStripButton BtnUsuarios;
        private System.Windows.Forms.ToolStripButton BtnMiembros;
        private System.Windows.Forms.ToolStripButton BtnEquipos;
        private System.Windows.Forms.ToolStripButton BtnTrabajadores;
        private System.Windows.Forms.ToolStripButton BtnSalir;
        private System.Windows.Forms.ToolStripButton BtnCerrarSesion;
        private System.Windows.Forms.ToolStripSplitButton BtnTienda;
        private System.Windows.Forms.ToolStripMenuItem realizarVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaDeInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
    }
}