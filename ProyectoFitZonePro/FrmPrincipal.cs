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
        }

        private void BtnTienda_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Tienda", "ver"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para acceder a la Tienda.", "Área Restringida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            FrmTienda tienda = new FrmTienda();
            tienda.MdiParent = this;
            tienda.Show();
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
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // El Truco Nivel Dios: Reinicia el programa entero
                Application.Restart();
            }
        }
    }
}