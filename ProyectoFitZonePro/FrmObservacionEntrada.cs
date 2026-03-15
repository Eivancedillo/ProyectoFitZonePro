using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace ProyectoFitZonePro
{
    public partial class FrmObservacionEntrada : Form
    {
        ManejadorInventarios mi;
        Entradas entradas = new Entradas(0,"","");
        DetalleEntrada detalle = new DetalleEntrada();
        public FrmObservacionEntrada()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            mi.GuardarEntrada(new Entradas(0,"",TxtObservacion.Text));
            foreach (var item in FrmEntradasInventario.de)
            {
                mi.GuardarDetalleEntrada(new DetalleEntrada(0, 0,item.FkIdProduto,item.Cantidad,item.Precio_Unitario));
            }
            MessageBox.Show("Entrada Guardada Correctamente");
            this.DialogResult = DialogResult.OK;
            FrmEntradasInventario.de.Clear();
            Close();
        }
    }
}
