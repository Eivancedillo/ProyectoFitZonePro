using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void FrmVerVentas_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);

            Pdel.Region = new Region(rutaPanel3);
            PSom.Region = new Region(rutaPanel4);
            Pdel2.Region = new Region(rutaPanel3);
            PSom2.Region = new Region(rutaPanel4);

            Pdel.BackColor = Color.White;
            Pdel2.BackColor = Color.White;
            PSom.BackColor = Color.FromArgb(20, Color.Black);
            PSom2.BackColor = Color.FromArgb(20, Color.Black);
        }
        private GraphicsPath CrearRutaRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath ruta = new GraphicsPath();
            int diametro = radio * 2;

            // Dibujamos los 4 arcos de las esquinas
            ruta.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90); // Arriba Izquierda
            ruta.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90); // Arriba Derecha
            ruta.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90); // Abajo Derecha
            ruta.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90); // Abajo Izquierda

            ruta.CloseFigure(); // Cerramos la figura uniendo los arcos
            return ruta;
        }

        private void DtgVentas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }
    }
}
