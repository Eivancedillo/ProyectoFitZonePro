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
using Entidades;

namespace ProyectoFitZonePro
{
    public partial class FrmConfirmarVenta : Form
    {
        ManejadorProductos mp;
        Ventas venta = new Ventas(0,0,"","");
        public FrmConfirmarVenta()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            mp.LlenarUsarios(CmbSocios);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            mp.GuardarVenta(new Ventas(0, Convert.ToInt32(CmbSocios.SelectedValue),"", CmbMetodoPago.SelectedItem.ToString()));
            foreach (var item in FrmRealizarVenta.carrito)
            {
                mp.GuardarDetalleVenta(item.FkIdProducto,item.Cantidad,item.Precio);
            }
            MessageBox.Show("Venta realizada con exito");
            this.DialogResult = DialogResult.OK;
            FrmRealizarVenta.carrito.Clear();
            Close();
        }
    }
}
