using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmUsuarios : Form
    {
        private ManejadorUsuarios mu;
        public static Usuarios usuario = new Usuarios(0, "", "", "", "", "", "Activo", "");
        private string filtroActual = "Todos";
        public static bool modoSeleccion = false;

        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();

            // Vinculamos el mismo evento a los 3 paneles
            PnlTodos.Click += PanelFiltro_Click;
            PnlActivos.Click += PanelFiltro_Click;
            PnlInactivos.Click += PanelFiltro_Click;

            this.Shown += FrmUsuarios_Shown;
        }

        private void FrmUsuarios_Shown(object sender, EventArgs e)
        {
            // Simulamos el clic en "Todos" para que cargue la tabla por primera vez
            PanelFiltro_Click(PnlTodos, EventArgs.Empty);
        }

        // --- LÓGICA DE LOS PANELES COMO BOTONES DE FILTRO ---
        private void PanelFiltro_Click(object sender, EventArgs e)
        {
            Panel panelClickeado = (Panel)sender;

            // 1. Reseteamos todos a color inactivo (Ej. Gris o el que prefieras)
            PnlTodos.BackColor = Color.LightGray;
            PnlActivos.BackColor = Color.LightGray;
            PnlInactivos.BackColor = Color.LightGray;

            // 2. Pintamos el panel clickeado de un color llamativo (Ej. Azul oscuro)
            panelClickeado.BackColor = Color.DeepSkyBlue;

            // 3. Actualizamos la variable de filtro
            if (panelClickeado.Name == "PnlTodos") filtroActual = "Todos";
            else if (panelClickeado.Name == "PnlActivos") filtroActual = "Activo";
            else if (panelClickeado.Name == "PnlInactivos") filtroActual = "Inactivo";

            ActualizarTabla();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            string busqueda = TxtBuscar.Text;
            string consulta = $"SELECT * FROM tbl_usuarios WHERE nombre LIKE '%{busqueda}%'";

            // Agregamos la condición del estado si no estamos en "Todos"
            if (filtroActual != "Todos")
            {
                consulta += $" AND estatus = '{filtroActual}'";
            }

            mu.Mostrar(consulta, DtgDatos, "Usuarios");

            // MAGIA DE LIMPIEZA VISUAL
            if (modoSeleccion)
            {
                BtnCrear.Visible = false; // Ocultamos el botón Crear

                int totalCols = DtgDatos.Columns.Count;
                if (totalCols >= 2)
                {
                    DtgDatos.Columns[totalCols - 1].Visible = false; // Oculta botón Estado
                    DtgDatos.Columns[totalCols - 2].Visible = false; // Oculta botón Editar
                }
            }
            else
            {
                BtnCrear.Visible = true; // Lo regresamos a la normalidad si no estamos seleccionando
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            usuario = new Usuarios(0, "", "", "", "", "", "Activo", "");
            FrmDatosUsuarios frmDatos = new FrmDatosUsuarios();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modoSeleccion)
            {
                // Solo guardamos el ID y Nombre y cerramos la ventana
                usuario.IdUsuario = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["idUsuario"].Value);
                usuario.Nombre = DtgDatos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                this.Close();
                return;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int indexFila = e.RowIndex;
            int indexColumna = e.ColumnIndex;
            int totalColumnasOriginales = DtgDatos.Columns.Count - 2; // Descontando los 2 botones

            // Extraemos los datos de la fila
            usuario.IdUsuario = Convert.ToInt32(DtgDatos.Rows[indexFila].Cells["idUsuario"].Value);
            usuario.Nombre = DtgDatos.Rows[indexFila].Cells["nombre"].Value.ToString();
            usuario.CURP = DtgDatos.Rows[indexFila].Cells["curp"].Value.ToString();
            usuario.Telefono = DtgDatos.Rows[indexFila].Cells["telefono"].Value.ToString();
            usuario.Email = DtgDatos.Rows[indexFila].Cells["email"].Value.ToString();
            usuario.FechaNacimiento = Convert.ToDateTime(DtgDatos.Rows[indexFila].Cells["fecha_nacimiento"].Value).ToString("yyyy-MM-dd");

            string estadoFila = DtgDatos.Rows[indexFila].Cells["estatus"].Value.ToString();

            // Lógica de los botones
            if (indexColumna == totalColumnasOriginales) // Botón Editar
            {
                if (estadoFila == "Inactivo")
                {
                    MessageBox.Show("No se puede editar un usuario inactivo. Actívelo primero.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosUsuarios frmDatos = new FrmDatosUsuarios();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            else if (indexColumna == totalColumnasOriginales + 1) // Botón Estado
            {
                bool mandarDesactivar = estadoFila == "Activo";
                mu.CambiarEstado(usuario.IdUsuario, mandarDesactivar);
                ActualizarTabla();
            }
        }
    }
}