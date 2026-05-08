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
    public partial class FrmDashboard : Form
    {
        private ManejadorDashboard md;

        public FrmDashboard()
        {
            InitializeComponent();
            md = new ManejadorDashboard();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel1 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel2 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, PSom4.Width, PSom4.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel4.Width, Pdel4.Height), radioBorde);
            GraphicsPath rutaPanel5 = CrearRutaRedondeada(new Rectangle(0, 0, PSom5.Width, PSom5.Height), radioBorde);
            GraphicsPath rutaPanel6 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel5.Width, Pdel5.Height), radioBorde);


            Pdel.Region = new Region(rutaPanel1);
            Pdel2.Region = new Region(rutaPanel1);
            Pdel3.Region = new Region(rutaPanel1);
            Pdel4.Region = new Region(rutaPanel4);
            Pdel5.Region = new Region(rutaPanel6);

            PSom.Region = new Region(rutaPanel2);
            PSom2.Region = new Region(rutaPanel2);
            PSom3.Region = new Region(rutaPanel2);
            PSom4.Region = new Region(rutaPanel3);
            PSom5.Region = new Region(rutaPanel5);

            PSom.BackColor = Color.FromArgb(20, Color.Black);
            PSom2.BackColor = Color.FromArgb(20, Color.Black);
            PSom3.BackColor = Color.FromArgb(20, Color.Black);
            PSom4.BackColor = Color.FromArgb(20, Color.Black);
            PSom5.BackColor = Color.FromArgb(20, Color.Black);
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
    }
}