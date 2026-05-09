using Manejadores;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosEquiposMantenimiento : Form
    {
        private ManejadorEquipos me;
        private int idMantenimientoPendiente = 0;

        public FrmDatosEquiposMantenimiento()
        {
            InitializeComponent();
            me = new ManejadorEquipos();

            // Cargar datos iniciales del equipo bloqueando su edición
            TxtNombre.Text = FrmEquipos.equipo.Nombre;
            TxtNombre.Enabled = false;

            TxtIdEquipo.Text = "M-" + FrmEquipos.equipo.IdEquipo.ToString("0000");
            TxtIdEquipo.Enabled = false;

            VerificarMantenimientoPendiente();
        }

        private void VerificarMantenimientoPendiente()
        {
            DataTable dtPendiente = me.ObtenerMantenimientoPendiente(FrmEquipos.equipo.IdEquipo);

            if (dtPendiente.Rows.Count > 0)
            {
                // Configurar ventana para finalizar un mantenimiento activo
                idMantenimientoPendiente = Convert.ToInt32(dtPendiente.Rows[0]["idMantenimiento"]);

                DtpFechaAdquisicion.Value = Convert.ToDateTime(dtPendiente.Rows[0]["fecha_mantenimiento"]);
                DtpFechaAdquisicion.Enabled = false;

                BtnAceptar.Enabled = false;
                BtnFinalizar.Enabled = true;
            }
            else
            {
                // Configurar ventana para programar uno nuevo
                BtnAceptar.Enabled = true;
                BtnFinalizar.Enabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string fechaFormateada = DtpFechaAdquisicion.Value.ToString("yyyy-MM-dd HH:mm:ss");

            me.CrearMantenimiento(FrmEquipos.equipo.IdEquipo, fechaFormateada);
            MessageBox.Show("Mantenimiento programado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (idMantenimientoPendiente > 0)
            {
                DialogResult rs = MessageBox.Show("¿Desea marcar este mantenimiento como finalizado con la fecha actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    me.FinalizarMantenimiento(idMantenimientoPendiente);
                    MessageBox.Show("Mantenimiento finalizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void FrmDatosEquiposMantenimiento_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAceptar.Width, BtnAceptar.Height), radioBorde);

            BtnAceptar.Region = new Region(rutaBoton1);
            BtnCancelar.Region = new Region(rutaBoton1);
            BtnFinalizar.Region = new Region(rutaBoton1);

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