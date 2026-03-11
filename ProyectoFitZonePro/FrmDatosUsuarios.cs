using Entidades;
using Manejadores;
using System;
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
    }
}