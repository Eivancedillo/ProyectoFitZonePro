using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            toolStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Dashboard", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para ver el Dashboard.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmDashboard dashboard = new FrmDashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
            ActivarBotonMenu(BtnDashboard);
        }

        private void BtnAsistencias_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Asistencias", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a las Asistencias.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmAsistencias asistencias = new FrmAsistencias();
            asistencias.MdiParent = this;
            asistencias.Show();
            ActivarBotonMenu(BtnAsistencias);
        }

        private void BtnMembresias_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Membresias", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a las Membresías.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmMembresias membresias = new FrmMembresias();
            membresias.MdiParent = this;
            membresias.Show();
            ActivarBotonMenu(BtnMembresias);

        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Usuarios", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Usuarios.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
            ActivarBotonMenu(BtnUsuarios);
        }

        private void BtnMiembros_Click(object sender, EventArgs e)
        {
            // OJO: Aquí usamos "Socios" porque así lo guardamos en tu lista de módulos mágicos
            if (!Sesion.TienePermiso("Socios", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Socios.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmSocios miembros = new FrmSocios();
            miembros.MdiParent = this;
            miembros.Show();
            ActivarBotonMenu(BtnMiembros);
        }

        private void BtnEquipos_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Equipos", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Equipos.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmEquipos equipos = new FrmEquipos();
            equipos.MdiParent = this;
            equipos.Show();
            ActivarBotonMenu(BtnEquipos);
        }

        private void BtnTrabajadores_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Trabajadores", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! Esta área es solo para Administradores.", "Seguridad Máxima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmTrabajadores trabajadores = new FrmTrabajadores();
            trabajadores.MdiParent = this;
            trabajadores.Show();
            ActivarBotonMenu(BtnTrabajadores);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void realizarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRealizarVenta venta = new FrmRealizarVenta();
            venta.MdiParent = this;
            venta.Show();
            ActivarBotonMenu(realizarVentaToolStripMenuItem);
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerVentas verVentas = new FrmVerVentas();
            verVentas.MdiParent = this;
            verVentas.Show();
            ActivarBotonMenu(verVentasToolStripMenuItem);
        }

        private void entradaDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEntradasInventario entradas = new FrmEntradasInventario();
            entradas.MdiParent = this;
            entradas.Show();
            ActivarBotonMenu(entradaDeInventarioToolStripMenuItem);
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInventario inventario = new FrmInventario();
            inventario.MdiParent = this;
            inventario.Show();
            ActivarBotonMenu(inventarioToolStripMenuItem);
        }
        private void ActivarBotonMenu(ToolStripItem botonSeleccionado)
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton boton)
                {
                    if (boton == botonSeleccionado)
                        boton.Checked = true;
                    else
                        boton.Checked = false;
                }

                else if (item is ToolStripSplitButton splitButton)
                {
                    foreach (ToolStripItem subItem in splitButton.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem subMenuBoton)
                        {
                            if (subMenuBoton == botonSeleccionado)
                            {
                                subMenuBoton.Checked = true;
                            }
                            else
                                subMenuBoton.Checked = false;
                        }
                    }
                }
            }
        }
        public class MenuColorTable : ProfessionalColorTable
        {
            //(Checked)
            public override Color ButtonCheckedHighlight => Color.FromArgb(94, 166, 121);
            public override Color ButtonCheckedGradientBegin => Color.FromArgb(94, 166, 121);
            public override Color ButtonCheckedGradientMiddle => Color.FromArgb(94, 166, 121);
            public override Color ButtonCheckedGradientEnd => Color.FromArgb(94, 166, 121);

            //(Hover)
            public override Color ButtonSelectedHighlight => Color.FromArgb(55, 65, 75);
            public override Color ButtonSelectedGradientBegin => Color.FromArgb(55, 65, 75);
            public override Color ButtonSelectedGradientMiddle => Color.FromArgb(55, 65, 75);
            public override Color ButtonSelectedGradientEnd => Color.FromArgb(55, 65, 75);

            public override Color ButtonPressedHighlight => Color.FromArgb(255, 70, 84, 97);
            public override Color ButtonPressedGradientBegin => Color.FromArgb(255, 70, 84, 97);
            public override Color ButtonPressedGradientMiddle => Color.FromArgb(255, 70, 84, 97);
            public override Color ButtonPressedGradientEnd => Color.FromArgb(255, 70, 84, 97);

            public override Color ButtonCheckedHighlightBorder => Color.Transparent;
            public override Color ButtonSelectedHighlightBorder => Color.Transparent;
            public override Color ButtonPressedHighlightBorder => Color.Transparent;
            public override Color ButtonSelectedBorder => Color.Transparent;

            public override Color ToolStripDropDownBackground => Color.FromArgb(16, 24, 40); // Usa el color oscuro de tu sidebar

            public override Color MenuItemSelected => Color.FromArgb(55, 65, 75);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(55, 65, 75);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(55, 65, 75);
            public override Color MenuItemBorder => Color.Transparent;

            public override Color ImageMarginGradientBegin => Color.Transparent;
            public override Color ImageMarginGradientMiddle => Color.Transparent;
            public override Color ImageMarginGradientEnd => Color.Transparent;
 
            public override Color CheckBackground => Color.FromArgb(94, 166, 121);
            public override Color CheckSelectedBackground => Color.FromArgb(94, 166, 121);
            public override Color CheckPressedBackground => Color.FromArgb(94, 166, 121);
        }
    }
}