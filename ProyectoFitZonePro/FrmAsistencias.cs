using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmAsistencias : Form
    {
        private ManejadorAsistencias ma;

        public FrmAsistencias()
        {
            InitializeComponent();
            ma = new ManejadorAsistencias();
            this.Shown += FrmAsistencias_Shown;
        }

        private void FrmAsistencias_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            // Filtramos para que solo salgan las asistencias de HOY
            string consulta = $"SELECT * FROM v_vista_asistencias WHERE FechaCorte = CURDATE() AND Cliente LIKE '%{TxtBuscar.Text}%'";
            ma.Mostrar(consulta, DtgDatos, "Asistencias");
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Asistencias", "crear"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para abrir el registro de asistencias.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Rebotado
            }

            // Este botón abrirá la pantalla de recepción (El escáner)
            FrmDatosAsistencias frmReceptor = new FrmDatosAsistencias();
            frmReceptor.ShowDialog();
            ActualizarTabla(); // Cuando cierre, se actualiza la tabla
        }

        private void FrmAsistencias_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnCrear.Width, BtnCrear.Height), radioBorde);

            Pdel.Region = new Region(rutaPanel3);
            PSom.Region = new Region(rutaPanel4);
            BtnCrear.Region = new Region(rutaBoton1);

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
    }
}