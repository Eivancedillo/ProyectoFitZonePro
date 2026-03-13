using Manejadores;
using System;
using System.Windows.Forms;
using Entidades;

namespace ProyectoFitZonePro
{
    public partial class FrmLogin : Form
    {
        private ManejadorLogin Ml;

        public FrmLogin()
        {
            InitializeComponent();
            Ml = new ManejadorLogin();

            // Para que la contraseña salga con asteriscos (por si no lo configuraste en el diseño)
            TxtPassword.PasswordChar = '*';

            // Un buen detalle de UX: si presiona Enter en la contraseña, que intente loguearse
            TxtPassword.KeyPress += TxtPassword_KeyPress;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsuario.Text) || string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Validamos en la base de datos
            int idLogueado = Ml.ValidarUsuario(TxtUsuario.Text, TxtPassword.Text);

            if (idLogueado > 0)
            {
                // 2. ¡Éxito! Llenamos la credencial virtual con el nuevo método
                Sesion.IdTrabajador = idLogueado;
                Sesion.Nombre = TxtUsuario.Text;
                Sesion.PermisosMenu = Ml.ObtenerPermisos(idLogueado);

                // 3. Abrimos el menú principal
                FrmPrincipal fp = new FrmPrincipal();
                fp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o cuenta inactiva.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Clear();
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Tecla Enter
            {
                e.Handled = true;
                BtnIngresar_Click(sender, e);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra todo el programa por completo
        }
    }
}