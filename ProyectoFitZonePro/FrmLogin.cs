using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProyectoFitZonePro
{
    public partial class FrmLogin : Form
    {
        private ManejadorLogin Ml;

        public FrmLogin()
        {
            InitializeComponent();
            Ml = new ManejadorLogin();
            this.DoubleBuffered = true; //para eliminar los parpadeos, hace que lo dibuje en memoria antes de mostrarlo

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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            // Creamos la ruta del tamaño exacto del panel
            Rectangle areaPanel2 = new Rectangle(0, 0, panel2.Width, panel2.Height);
            Rectangle areaPanel3 = new Rectangle(0, 0, panel3.Width, panel3.Height);
            GraphicsPath rutaPanel2 = CrearRutaRedondeada(areaPanel2, radioBorde);
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(areaPanel3, radioBorde);


            // Aplicamos el recorte al panel
            panel2.Region = new Region(rutaPanel2);
            panel3.Region = new Region(rutaPanel3);
        
        panel3.BackColor = Color.FromArgb(40, Color.Black);

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

        private void TxtUsuario_Click(object sender, EventArgs e)
        {
            TxtUsuario.Text = "";
            TxtUsuario.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            TxtPassword.Text = "";
            TxtPassword.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            TxtPassword.PasswordChar = '*';
        }
    }
}