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
    public partial class FrmInventario : Form
    {
        ManejadorInventarios mi;
        public FrmInventario()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }
        private void ActualizarTabla()
        {
            string busqueda = TxtBusqueda.Text;
            mi.VerStock($"select * from v_inventario where Nombre like '%{busqueda}%'",DtgInventario, "tbl_productos");
        }
    }
}
