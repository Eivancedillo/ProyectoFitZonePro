using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosEquipos : Form
    {
        private ManejadorEquipos me;

        public FrmDatosEquipos()
        {
            InitializeComponent();
            me = new ManejadorEquipos();

            // Si el IdEquipo es diferente de 0, significa que vamos a Editar, así que pre-llenamos los datos
            if (FrmEquipos.equipo.IdEquipo != 0)
            {
                TxtNombre.Text = FrmEquipos.equipo.Nombre;
                TxtCategoria.Text = FrmEquipos.equipo.Categoria;

                // Usamos Convert.ToDateTime que es un poco más seguro al convertir desde la tabla
                DtpFechaAdquisicion.Value = Convert.ToDateTime(FrmEquipos.equipo.FechaAdquisicion);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // string.IsNullOrWhiteSpace evita que el usuario guarde campos con puros espacios vacíos
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtCategoria.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos de texto.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaFormateada = DtpFechaAdquisicion.Value.ToString("yyyy-MM-dd");

            if (FrmEquipos.equipo.IdEquipo == 0)
            {
                // Modo Crear
                me.CrearEquipo(new Equipos(0, TxtNombre.Text, TxtCategoria.Text, fechaFormateada, "Activo"));
                MessageBox.Show("Equipo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Modo Editar
                me.EditarEquipo(new Equipos(FrmEquipos.equipo.IdEquipo, TxtNombre.Text, TxtCategoria.Text, fechaFormateada, "Activo"));
                MessageBox.Show("Equipo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosEquipos_Load(object sender, EventArgs e)
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