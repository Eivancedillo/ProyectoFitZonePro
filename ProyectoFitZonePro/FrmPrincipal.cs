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
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void BtnAsistencias_Click(object sender, EventArgs e)
        {
            FrmAsistencias asistencias = new FrmAsistencias();
            asistencias.MdiParent = this;
            asistencias.Show();
        }

        private void BtnMembresias_Click(object sender, EventArgs e)
        {
            FrmMembresias membresias = new FrmMembresias();
            membresias.MdiParent = this;
            membresias.Show();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }

        private void BtnMiembros_Click(object sender, EventArgs e)
        {
            FrmSocios miembros = new FrmSocios();
            miembros.MdiParent = this;
            miembros.Show();
        }

        private void BtnTienda_Click(object sender, EventArgs e)
        {
            FrmTienda tienda = new FrmTienda();
            tienda.MdiParent = this;
            tienda.Show();
        }

        private void BtnEquipos_Click(object sender, EventArgs e)
        {
            FrmEquipos equipos = new FrmEquipos();
            equipos.MdiParent = this;
            equipos.Show();
        }

        private void BtnTrabajadores_Click(object sender, EventArgs e)
        {
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
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.ShowDialog();
            this.Close();
        }
    }
}