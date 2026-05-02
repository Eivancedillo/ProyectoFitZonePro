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
    public partial class FrmInventario : Form
    {
        ManejadorInventarios mi;
        public FrmInventario()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
            this.Shown += FrmInventario_Shown;
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

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);

            Pdel.Region = new Region(rutaPanel3);
            PSom.Region = new Region(rutaPanel4);

            Pdel.BackColor = Color.White;
            PSom.BackColor = Color.FromArgb(20, Color.Black);
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

        private void FrmInventario_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }
    }
}
