using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosAsistencias : Form
    {
        private ManejadorAsistencias ma;

        public FrmDatosAsistencias()
        {
            InitializeComponent();
            ma = new ManejadorAsistencias();

            // Le amarramos el evento de la tecla "Enter" a tu TextBox
            TxtIdSocio.KeyPress += TxtIdSocio_KeyPress;

            // Limpiamos todo al abrir
            ResetearPantalla();
        }

        private void TxtIdSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // El número 13 es la tecla "Enter"
            if (e.KeyChar == (char)13)
            {
                e.Handled = true; // Para que no suene el "beep" de Windows

                if (string.IsNullOrWhiteSpace(TxtIdSocio.Text)) return;

                // Mandamos el texto al manejador para que haga todo el trabajo
                string[] resultado = ma.ProcesarAcceso(TxtIdSocio.Text);
                string estatus = resultado[0];
                string mensaje = resultado[1];

                // Llenamos los datos (si es que la BD nos devolvió nombre, paquete, etc.)
                if (resultado.Length > 2)
                {
                    TxtNombre.Text = resultado[2];
                    TxtMembresia.Text = resultado[3];
                    TxtVigencia.Text = resultado[4];
                }

                // Pintamos la interfaz según lo que pasó
                if (estatus == "ERROR" || estatus == "DENEGADO")
                {
                    LblEstado.Text = estatus;  // Descomenta esto si pusiste tu Label grandote
                    MessageBox.Show(mensaje, "Alerta de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // ENTRADA o SALIDA exitosa
                {
                    LblEstado.Text = mensaje; // Descomenta esto si pusiste tu Label grandote
                    MessageBox.Show(mensaje, estatus, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpiamos la cajita y la preparamos para la siguiente persona
                ResetearPantalla();
            }
        }

        private void ResetearPantalla()
        {
            TxtIdSocio.Clear();
            TxtNombre.Clear();
            TxtMembresia.Clear();
            TxtVigencia.Clear();
            TxtIdSocio.Focus(); // Mantiene el cursor aquí siempre
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosAsistencias_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnCancelar.Width, BtnCancelar.Height), radioBorde);

            BtnCancelar.Region = new Region(rutaBoton1);
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