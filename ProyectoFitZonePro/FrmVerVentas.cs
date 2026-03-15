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
    public partial class FrmVerVentas : Form
    {
        ManejadorVentas mv;
        int fila = 0 , columna = 0;
        public FrmVerVentas()
        {
            InitializeComponent();
            mv = new ManejadorVentas();
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            string fechaFiltrada = DtpFecha.Value.ToString("yyyy-MM-dd");
            mv.VerVentas($"select * from v_ventas where `Fecha de la Venta`  = '{fechaFiltrada}'",DtgVentas,"tbl_ventas");
        }

        private void DtgVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if(columna == 4)
            {
                int idVenta = Convert.ToInt32(DtgVentas.Rows[fila].Cells["idVenta"].Value);
                mv.VerDetalleVenta($"select * from v_detalleVentas where idVenta = {idVenta}", DtgDetalleVenta, "tbl_detalleVentas");
                double total = mv.CalcularTotal(DtgDetalleVenta);
                LblTotalVenta.Text = $"Total de la Venta: {total:C2}";
            }
        }

        private void DtgVentas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }
    }
}
