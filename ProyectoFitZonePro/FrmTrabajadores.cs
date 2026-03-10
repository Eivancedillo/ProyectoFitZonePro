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
    public partial class FrmTrabajadores : Form
    {
        private ManejadorTrabajadores mt;

        public FrmTrabajadores()
        {
            InitializeComponent();
            mt = new ManejadorTrabajadores();
        }
    }
}