using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosUsuarios : Form
    {
        private ManejadorUsuarios mu;

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
            // Validamos que no dejen en blanco los campos clave
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtCURP.Text) || string.IsNullOrWhiteSpace(TxtTelefono.Text))
            {
                MessageBox.Show("Por favor, complete al menos el Nombre, CURP y Teléfono.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaNac = DtpFechaNacimiento.Value.ToString("yyyy-MM-dd");

            if (FrmUsuarios.usuario.IdUsuario == 0)
            {
                // Modo Crear
                mu.CrearUsuario(new Usuarios(0, TxtNombre.Text, TxtCURP.Text, TxtTelefono.Text, TxtEmail.Text, fechaNac, "Activo", ""));
                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Modo Editar
                mu.EditarUsuario(new Usuarios(FrmUsuarios.usuario.IdUsuario, TxtNombre.Text, TxtCURP.Text, TxtTelefono.Text, TxtEmail.Text, fechaNac, "Activo", ""));
                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
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