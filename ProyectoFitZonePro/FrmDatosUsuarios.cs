using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosUsuarios : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturador;
        private DPFP.Processing.Enrollment Enrolador;
        private DPFP.Template PlantillaHuella;
        private ManejadorUsuarios mu;
        private bool huellaYaRegistrada = false;
        public FrmDatosUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();

            // Si el IdUsuario es diferente de 0, es porque le dimos en Editar
            if (FrmUsuarios.usuario.IdUsuario != 0)
            {
                TxtNombre.Text = FrmUsuarios.usuario.Nombre;
                TxtCURP.Text = FrmUsuarios.usuario.CURP;
                TxtTelefono.Text = FrmUsuarios.usuario.Telefono;
                TxtEmail.Text = FrmUsuarios.usuario.Email;
                DtpFechaNacimiento.Value = Convert.ToDateTime(FrmUsuarios.usuario.FechaNacimiento);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtCURP.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                MessageBox.Show("No dejes los campos clave vacíos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaNac = DtpFechaNacimiento.Value.ToString("yyyy-MM-dd");

            // 2. Lógica para NUEVO USUARIO (IdUsuario == 0)
            if (FrmUsuarios.usuario.IdUsuario == 0)
            {
                // ¡VALIDACIÓN CRUCIAL! No podemos crear el usuario si no hay huella en memoria
                if (PlantillaHuella == null)
                {
                    MessageBox.Show("Debes registrar la huella (4 toques) antes de guardar al nuevo socio.", "Falta huella", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertimos la plantilla capturada por el sensor a un arreglo de bytes para MySQL
                byte[] huellaBytes = PlantillaHuella.Bytes;

                // Llamamos al nuevo método del manejador que creamos
                bool exito = mu.RegistrarUsuarioConHuella(
                    TxtNombre.Text,
                    TxtCURP.Text,
                    TxtTelefono.Text,
                    TxtEmail.Text,
                    fechaNac,
                    huellaBytes
                );

                if (exito)
                {
                    MessageBox.Show("Usuario y huella registrados con éxito.", "¡A darle duro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            // 3. Lógica para EDITAR USUARIO
            else
            {
                mu.EditarUsuario(new Usuarios(FrmUsuarios.usuario.IdUsuario, TxtNombre.Text, TxtCURP.Text, TxtTelefono.Text, TxtEmail.Text, fechaNac, "Activo", ""));
                if (PlantillaHuella != null)
                {
                    byte[] nuevaHuellaBytes = PlantillaHuella.Bytes;
                    mu.ActualizarSoloHuella(FrmUsuarios.usuario.IdUsuario, nuevaHuellaBytes);
                }

                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosUsuarios_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAceptar.Width, BtnAceptar.Height), radioBorde);

            BtnAceptar.Region = new Region(rutaBoton1);
            BtnCancelar.Region = new Region(rutaBoton1);

            IniciarLector();
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

        protected virtual void IniciarLector()
        {
            try
            {
                Capturador = new DPFP.Capture.Capture();
                if (Capturador != null)
                    Capturador.EventHandler = this;
                Enrolador = new DPFP.Processing.Enrollment();

                CambiarTextoUI("Toca el sensor 4 veces para registrar la huella.");

                Capturador.StartCapture();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo iniciar el lector de huellas: " + ex.Message, "Error de Hardware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarTextoUI(string texto)
        {
            if (LblEstatusHuella.InvokeRequired)
            {
                LblEstatusHuella.Invoke(new MethodInvoker(delegate { LblEstatusHuella.Text = texto; }));
            }
            else
            {
                LblEstatusHuella.Text = texto;
            }
        }

        protected void ProcesarToque(DPFP.Sample Sample)
        {
            if (huellaYaRegistrada) return;

            DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet caracteristicas = new DPFP.FeatureSet();

            extractor.CreateFeatureSet(Sample, DPFP.Processing.DataPurpose.Enrollment, ref feedback, ref caracteristicas);

            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                try
                {
                    Enrolador.AddFeatures(caracteristicas);
                }
                finally
                {
                    CambiarTextoUI($"Toque el Sensor. Faltan {Enrolador.FeaturesNeeded} toques.");

                    switch (Enrolador.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            // ¡BLOQUEO DE SEGURIDAD ACTIVADO!
                            huellaYaRegistrada = true;

                            PlantillaHuella = Enrolador.Template;
                            CambiarTextoUI("¡Huella bloqueada y lista para guardar!");

                            // Apagamos el lector de inmediato para que el foquito azul se apague
                            if (Capturador != null)
                            {
                                Capturador.StopCapture();
                                Capturador.EventHandler = null; // Le quitamos el contrato de eventos para que quede sordo
                            }
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            Enrolador.Clear();
                            if (Capturador != null) Capturador.StopCapture();
                            huellaYaRegistrada = false;
                            CambiarTextoUI("La huella falló. Vuelve a empezar.");
                            IniciarLector();
                            break;
                    }
                }
            }
            else
            {
                CambiarTextoUI("Lectura de mala calidad. Pon el dedo firme.");
            }
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber) { }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber) { }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber) { }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber) { }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback) { }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            ProcesarToque(Sample);
        }

        private void ApagarLectorCompleto()
        {
            if (Capturador != null)
            {
                try
                {
                    Capturador.StopCapture(); // Apaga la luz
                    Capturador.EventHandler = null; // Lo deja sordo
                    Capturador.Dispose(); // ¡ESTO ES LO IMPORTANTE! Libera el USB por completo
                    Capturador = null; // Lo borra de la memoria
                }
                catch
                {
                    // Si hay un error al intentar apagarlo, aquí SÍ lo ignoramos calladitos
                }
            }
        }

        private void FrmDatosUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApagarLectorCompleto();
        }
    }
}