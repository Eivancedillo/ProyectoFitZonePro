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
    public partial class FrmDatosEquipos : Form
    {
        private ManejadorEquipos me;

        public FrmDatosEquipos()
        {
            InitializeComponent();
            me = new ManejadorEquipos();
        }
    }
}