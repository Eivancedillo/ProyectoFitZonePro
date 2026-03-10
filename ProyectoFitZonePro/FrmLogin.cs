using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace ProyectoFitZonePro
{
    public partial class FrmLogin : Form
    {
        private ManejadorLogin Ml;

        public FrmLogin()
        {
            InitializeComponent();
            Ml = new ManejadorLogin();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            FrmPrincipal fp = new FrmPrincipal();
            fp.Show();
            this.Hide();
        }
    }
}