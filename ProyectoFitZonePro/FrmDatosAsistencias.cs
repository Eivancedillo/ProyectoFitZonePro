using DPFP;
using DPFP.Capture;
using Manejadores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosAsistencias : Form, DPFP.Capture.EventHandler
    {
        private ManejadorAsistencias ma;
        private DPFP.Capture.Capture Capturador;
        private DPFP.Verification.Verification Verificador; 
        private Dictionary<int, DPFP.Template> HuellasEnMemoria;
        public FrmDatosAsistencias()
        {
            InitializeComponent();
            ma = new ManejadorAsistencias();
            ResetearPantalla();
        }

        private void ResetearPantalla()
        {
            TxtNombre.Clear();
            TxtMembresia.Clear();
            TxtVigencia.Clear();
            LblEstado.Text = "Esperando huella...";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosAsistencias_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnCancelar.Width, BtnCancelar.Height), radioBorde);
            BtnCancelar.Region = new Region(rutaBoton1);

            try
            {
                HuellasEnMemoria = ma.ObtenerHuellasBD();
                IniciarLector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public void OnFingerGone(object Capture, string ReaderSerialNumber) { }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber) { }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber) { }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber) { }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback) { }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            ProcesarHuellaEscaneada(Sample);
        }

        private void FrmDatosAsistencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Capturador != null) Capturador.StopCapture();
        }

        private void IniciarLector()
        {
            try
            {
                Capturador = new DPFP.Capture.Capture();
                if (Capturador != null) Capturador.EventHandler = this;

                Verificador = new DPFP.Verification.Verification();

                Capturador.StartCapture();
                LblEstado.Text = $"Lector listo. {HuellasEnMemoria.Count} huellas cargadas.";
            }
            catch { MessageBox.Show("Error al iniciar lector."); }
        }

        private void ProcesarHuellaEscaneada(DPFP.Sample Sample)
        {
            DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet caracteristicas = new DPFP.FeatureSet();

            extractor.CreateFeatureSet(Sample, DPFP.Processing.DataPurpose.Verification, ref feedback, ref caracteristicas);

            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                bool huellaEncontrada = false;
                int idUsuarioEncontrado = 0;

                foreach (var huellaDB in HuellasEnMemoria)
                {
                    DPFP.Verification.Verification.Result resultadoVerificacion = new DPFP.Verification.Verification.Result();
                    Verificador.Verify(caracteristicas, huellaDB.Value, ref resultadoVerificacion);

                    if (resultadoVerificacion.Verified)
                    {
                        huellaEncontrada = true;
                        idUsuarioEncontrado = huellaDB.Key;
                        break;
                    }
                }

                this.Invoke(new MethodInvoker(delegate
                {
                    if (huellaEncontrada)
                    {
                        ActualizarPantallaPorHuella(idUsuarioEncontrado);
                    }
                    else
                    {
                        LblEstado.Text = "HUELLA NO RECONOCIDA";
                        MessageBox.Show("Esa huella no existe en el sistema.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetearPantalla();
                    }
                }));
            }
        }

        private void ActualizarPantallaPorHuella(int idUsuario)
        {
            string[] resultado = ma.ProcesarAcceso(idUsuario);

            string estatus = resultado[0];
            string mensaje = resultado[1];

            if (resultado.Length > 2)
            {
                TxtNombre.Text = resultado[2];
                TxtMembresia.Text = resultado[3];
                TxtVigencia.Text = resultado[4];
            }

            if (estatus == "ERROR" || estatus == "DENEGADO")
            {
                LblEstado.Text = estatus;
                MessageBox.Show(mensaje, "Alerta de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LblEstado.Text = mensaje;
                MessageBox.Show(mensaje, estatus, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetearPantalla();
        }
    }
}