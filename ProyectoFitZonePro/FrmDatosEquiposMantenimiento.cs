using Manejadores;
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
    public partial class FrmDatosEquiposMantenimiento : Form
    {
        private ManejadorEquipos me;

        public FrmDatosEquiposMantenimiento()
        {
            InitializeComponent();
            me = new ManejadorEquipos();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}