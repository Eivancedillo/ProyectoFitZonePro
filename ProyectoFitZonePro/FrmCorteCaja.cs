using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace ProyectoFitZonePro
{
    public partial class FrmCorteCaja : Form
    {
        ManejadorVentas mv;
        public FrmCorteCaja()
        {
            InitializeComponent();
            mv = new ManejadorVentas();
        }

        private void FrmCorteCaja_Load(object sender, EventArgs e)
        {
            string hoy = DateTime.Now.ToString("yyyy-MM-dd");
            string query = $"SELECT * FROM v_corteCajaTienda WHERE Fecha = '{hoy}'";
            DataTable dt = mv.ObtenerDatos(query);

            if (dt.Rows.Count > 0)
            {
                string ventas = dt.Rows[0]["VentasTotales"].ToString();
                string dinero = Convert.ToDouble(dt.Rows[0]["DineroCaja"]).ToString("C2");

                LblMuestra.Text = $"CORTE DEL DÍA: {hoy}\n\n" +
                              $"Ventas: {ventas}\n" +
                              $"Total en Caja: {dinero}";
            }
            else
            {
                LblMuestra.Text = $"CORTE DEL DÍA: {hoy}\n\n" +
                              "No hay ventas registradas todavía.";
            }
        }
    }
}
