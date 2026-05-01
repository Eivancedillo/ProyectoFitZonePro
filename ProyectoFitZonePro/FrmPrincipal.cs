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
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

        private const int WM_SETREDRAW = 11;

        public FrmPrincipal()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            toolStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
            LblUsuario.Text = Sesion.Nombre;
            foreach (Control control in this.Controls)
            {
                // Buscamos la "sábana" oculta de Windows (MdiClient)
                if (control is MdiClient client)
                {
                    // La pintamos con el color de tu tema oscuro
                    client.BackColor = Color.White;

                    // Rompemos el ciclo porque solo hay un MdiClient
                    break;
                }
            }
        }

        private void AbrirFormularioHijo(Form nuevoFormulario, ToolStripItem botonMenu)
        {
            // Evita recargar si el formulario ya está abierto
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.GetType() == nuevoFormulario.GetType())
            {
                return;
            }

            // 1. Congelamos la pantalla
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);

            try
            {
                // 2. Cerramos lo anterior
                CerrarFormulariosAbiertos();

                // 3. Configuramos y mostramos el nuevo
                nuevoFormulario.MdiParent = this;
                nuevoFormulario.Dock = DockStyle.Fill;
                nuevoFormulario.Show();

                // 4. Actualizamos visualmente el menú
                ActivarBotonMenu(botonMenu);
            }
            finally
            {
                // 5. Descongelamos y forzamos el redibujado limpio
                SendMessage(this.Handle, WM_SETREDRAW, true, 0);
                this.Refresh();
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Dashboard", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para ver el Dashboard.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmDashboard(), BtnDashboard);
        }

        private void BtnAsistencias_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Asistencias", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a las Asistencias.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmAsistencias(), BtnAsistencias);
        }

        private void BtnMembresias_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Membresias", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a las Membresías.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmMembresias(), BtnMembresias);
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Usuarios", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Usuarios.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmUsuarios(), BtnUsuarios);
        }

        private void BtnMiembros_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Socios", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Socios.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmSocios(), BtnMiembros);
        }

        private void BtnEquipos_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Equipos", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a los Equipos.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmEquipos(), BtnEquipos);
        }

        private void BtnTrabajadores_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Trabajadores", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! Esta área es solo para Administradores.", "Seguridad Máxima", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AbrirFormularioHijo(new FrmTrabajadores(), BtnTrabajadores);
        }

        private void realizarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Tienda", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder al módulo de Tienda.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmRealizarVenta(), realizarVentaToolStripMenuItem);
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Tienda", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para ver el historial de ventas.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmVerVentas(), verVentasToolStripMenuItem);
        }

        private void entradaDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Tienda", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder al Inventario.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmEntradasInventario(), entradaDeInventarioToolStripMenuItem);
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Tienda", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder al Inventario.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AbrirFormularioHijo(new FrmInventario(), inventarioToolStripMenuItem);
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

        private void CerrarFormulariosAbiertos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void ActivarBotonMenu(ToolStripItem botonSeleccionado)
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton boton)
                {
                    boton.Checked = (boton == botonSeleccionado);
                }
                else if (item is ToolStripSplitButton splitButton)
                {
                    foreach (ToolStripItem subItem in splitButton.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem subMenuBoton)
                        {
                            subMenuBoton.Checked = (subMenuBoton == botonSeleccionado);
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

            public override Color ToolStripDropDownBackground => Color.FromArgb(16, 24, 40);

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