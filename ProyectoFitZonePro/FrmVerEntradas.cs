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
    public partial class FrmVerEntradas : Form
    {
        ManejadorInventarios mi;
        int fila = 0, columna = 0;
        public FrmVerEntradas()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
            this.Shown += FrmVerEntradas_Shown;
        }

        private void DtgEntradas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        private void DtgEntradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (columna == 3)
            {
                int idEntrada = Convert.ToInt32(DtgEntradas.Rows[fila].Cells["idEntrada"].Value);
                mi.VerDetalleEntrada($"select * from v_detalleEntrada where idEntrada = {idEntrada}", DtgDetalleEntrada, "tbl_detalleEntrada");
                double total = mi.CalcularTotal(DtgDetalleEntrada);
                LblTotalVenta.Text = $"Total de la Entrada: {total:C2}";
            }
        }

        private void FrmVerEntradas_Shown(object sender, EventArgs e)
        {
            string fechaDeHoy = DateTime.Now.ToString("yyyy-MM-dd");
            mi.VerEntradas($"select * from v_entradas where `Fecha de la Entrada`  = '{fechaDeHoy}'", DtgEntradas, "tbl_entradas");
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            string fechaFiltrada = DtpFecha.Value.ToString("yyyy-MM-dd");
            mi.VerEntradas($"select * from v_entradas where `Fecha de la Entrada`  = '{fechaFiltrada}'", DtgEntradas, "tbl_entradas");
        }
    }
}
