using Entidades;
using Manejadores;
using System;
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
    }
}