using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosTrabajadores : Form
    {
        private ManejadorTrabajadores mt;
        private bool permisosBloqueados = false; // <-- LA NUEVA BANDERA

        // ¡NUESTRA MEMORIA MÁGICA!
        private Dictionary<string, PermisosTemp> dictPermisos = new Dictionary<string, PermisosTemp>();

        // Bandera para que los CheckBoxes no se vuelvan locos al cambiar de módulo
        private bool cargandoPermisos = false;

        // Lista de todos los módulos de tu sistema
        private string[] listaModulos = { "Dashboard", "Membresias", "Usuarios", "Socios", "Tienda", "Equipos", "Asistencias", "Trabajadores" };

        public FrmDatosTrabajadores()
        {
            InitializeComponent();
            mt = new ManejadorTrabajadores();
            InicializarMemoriaPermisos();

            // Amarramos los eventos por código (así no tienes que hacerlo a mano en el diseño)
            CmbPermisos.SelectedIndexChanged += CmbPermisos_SelectedIndexChanged;
            ChkVer.CheckedChanged += ActualizarMemoriaPermisos;
            ChkCrear.CheckedChanged += ActualizarMemoriaPermisos;
            ChkEditar.CheckedChanged += ActualizarMemoriaPermisos;
            ChkEliminar.CheckedChanged += ActualizarMemoriaPermisos;

            CargarDatos();
        }

        private void InicializarMemoriaPermisos()
        {
            // Llenamos el diccionario y el ComboBox con todos los módulos en falso (vacíos)
            CmbPermisos.Items.Clear();
            foreach (string mod in listaModulos)
            {
                dictPermisos.Add(mod, new PermisosTemp());
                CmbPermisos.Items.Add(mod);
            }
        }

        private void CargarDatos()
        {
            if (FrmTrabajadores.trabajador.IdTrabajador != 0)
            {
                // MODO EDITAR
                TxtNombre.Text = FrmTrabajadores.trabajador.Nombre;
                TxtNumero.Text = FrmTrabajadores.trabajador.Telefono;
                TxtEmail.Text = FrmTrabajadores.trabajador.Email;
                // La clave se queda en blanco por seguridad. Si escribe algo, se cambia; si no, se queda igual.

                // Bloqueamos la edición hasta que le dé al botón Editar
                BloquearControles(false);

                // Traemos los permisos reales de la BD y actualizamos nuestra memoria
                DataTable dtPermisos = mt.ObtenerPermisos(FrmTrabajadores.trabajador.IdTrabajador);
                foreach (DataRow fila in dtPermisos.Rows)
                {
                    string mod = fila["modulo"].ToString();
                    if (dictPermisos.ContainsKey(mod))
                    {
                        dictPermisos[mod].Ver = Convert.ToBoolean(fila["p_ver"]);
                        dictPermisos[mod].Crear = Convert.ToBoolean(fila["p_crear"]);
                        dictPermisos[mod].Editar = Convert.ToBoolean(fila["p_editar"]);
                        dictPermisos[mod].Eliminar = Convert.ToBoolean(fila["p_eliminar"]);
                    }
                }
            }
            else
            {
                // MODO CREAR: Todo habilitado desde el inicio
                BloquearControles(true);
            }

            // Seleccionamos el primer módulo para que se vean las cajitas
            if (CmbPermisos.Items.Count > 0) CmbPermisos.SelectedIndex = 0;
        }

        // Activa o desactiva la pantalla (El botón Editar que pediste)
        private void BloquearControles(bool habilitar)
        {
            TxtNombre.Enabled = habilitar;
            TxtPassword.Enabled = habilitar;
            TxtNumero.Enabled = habilitar;
            TxtEmail.Enabled = habilitar;
            ChkVer.Enabled = habilitar;
            ChkCrear.Enabled = habilitar;
            ChkEditar.Enabled = habilitar;
            ChkEliminar.Enabled = habilitar;
            BtnAceptar.Enabled = habilitar;
            CmbPermisos.Enabled = habilitar;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Trabajadores", "editar"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para editar trabajadores.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            BloquearControles(true);

            int idSeleccionado = FrmTrabajadores.trabajador.IdTrabajador;
            bool esElMismoUsuario = (idSeleccionado == Sesion.IdTrabajador);
            bool esAdminPrincipal = (idSeleccionado == 1);

            if (esElMismoUsuario || esAdminPrincipal)
            {
                permisosBloqueados = true; // <-- ACTIVAMOS EL CANDADO MÁGICO

                // Apagamos las cajitas para el primer módulo visible
                ChkVer.Enabled = false;
                ChkCrear.Enabled = false;
                ChkEditar.Enabled = false;
                ChkEliminar.Enabled = false;

                string mensaje = esAdminPrincipal
                    ? "Edición habilitada.\nPor seguridad del sistema, los PERMISOS del Administrador Principal no pueden ser modificados."
                    : "Edición habilitada.\nPor seguridad, no puedes modificar tus PROPIOS permisos.";

                MessageBox.Show(mensaje, "Protección de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                permisosBloqueados = false; // Nos aseguramos que esté apagado
                MessageBox.Show("Edición habilitada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- LA MAGIA DE CAMBIAR DE MÓDULO ---
        private void CmbPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPermisos.SelectedItem == null) return;
            string moduloSeleccionado = CmbPermisos.SelectedItem.ToString();

            // Activamos la bandera para que no se dispare el evento "CheckedChanged" por accidente
            cargandoPermisos = true;

            // Leemos la memoria y marcamos las cajitas según corresponda
            ChkVer.Checked = dictPermisos[moduloSeleccionado].Ver;
            ChkCrear.Checked = dictPermisos[moduloSeleccionado].Crear;
            ChkEditar.Checked = dictPermisos[moduloSeleccionado].Editar;
            ChkEliminar.Checked = dictPermisos[moduloSeleccionado].Eliminar;

            // --- EL CANDADO FINAL ---
            if (permisosBloqueados)
            {
                ChkVer.Enabled = false;
                ChkCrear.Enabled = false;
                ChkEditar.Enabled = false;
                ChkEliminar.Enabled = false;
            }
            // ------------------------

            cargandoPermisos = false;
        }

        // --- LA MAGIA DE GUARDAR EN MEMORIA AL DAR CLIC ---
        private void ActualizarMemoriaPermisos(object sender, EventArgs e)
        {
            // Si el programa está cargando, o no hay módulo, no hacemos nada
            if (cargandoPermisos || CmbPermisos.SelectedItem == null) return;

            string moduloSeleccionado = CmbPermisos.SelectedItem.ToString();

            // Actualizamos la memoria con lo que el usuario acaba de palomear
            dictPermisos[moduloSeleccionado].Ver = ChkVer.Checked;
            dictPermisos[moduloSeleccionado].Crear = ChkCrear.Checked;
            dictPermisos[moduloSeleccionado].Editar = ChkEditar.Checked;
            dictPermisos[moduloSeleccionado].Eliminar = ChkEliminar.Checked;
        }

        // --- GUARDAR TODO EN LA BD ---
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idActual = FrmTrabajadores.trabajador.IdTrabajador;

            if (idActual == 0)
            {
                // CREAR
                if (string.IsNullOrWhiteSpace(TxtPassword.Text))
                {
                    MessageBox.Show("Debe asignar una contraseña al nuevo trabajador.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Trabajadores nuevo = new Trabajadores(0, TxtNombre.Text, TxtPassword.Text, TxtNumero.Text, TxtEmail.Text, "Activo");
                idActual = mt.CrearTrabajador(nuevo); // Atrapamos el ID nuevo
                MessageBox.Show("Trabajador creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // EDITAR
                Trabajadores editado = new Trabajadores(idActual, TxtNombre.Text, TxtPassword.Text, TxtNumero.Text, TxtEmail.Text, "Activo");
                mt.EditarTrabajador(editado);
                MessageBox.Show("Trabajador actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Recorremos nuestro diccionario mágico y guardamos TODOS los permisos en la base de datos
            foreach (var item in dictPermisos)
            {
                string nombreModulo = item.Key;
                PermisosTemp p = item.Value;

                mt.GuardarPermisos(idActual, nombreModulo, p.Ver, p.Crear, p.Editar, p.Eliminar);
            }

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDatosTrabajadores_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAceptar.Width, BtnAceptar.Height), radioBorde);
            GraphicsPath rutaBoton2 = CrearRutaRedondeada(new Rectangle(0, 0, BtnEditar.Width, BtnEditar.Height), radioBorde);

            BtnAceptar.Region = new Region(rutaBoton1);
            BtnCancelar.Region = new Region(rutaBoton1);
            BtnEditar.Region = new Region(rutaBoton2);
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

// Creamos una clase pequeñita aquí mismo para guardar los permisos en la memoria
public class PermisosTemp
{
    public bool Ver { get; set; }
    public bool Crear { get; set; }
    public bool Editar { get; set; }
    public bool Eliminar { get; set; }
}