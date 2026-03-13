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

            PnlTodos.Click += PanelFiltro_Click;
            PnlActivos.Click += PanelFiltro_Click;
            PnlInactivos.Click += PanelFiltro_Click;

            this.Shown += FrmUsuarios_Shown;
        }

        private void FrmUsuarios_Shown(object sender, EventArgs e)
        {
            PanelFiltro_Click(PnlTodos, EventArgs.Empty);
        }

        private void PanelFiltro_Click(object sender, EventArgs e)
        {
            Panel panelClickeado = (Panel)sender;

            PnlTodos.BackColor = Color.LightGray;
            PnlActivos.BackColor = Color.LightGray;
            PnlInactivos.BackColor = Color.LightGray;

            panelClickeado.BackColor = Color.DeepSkyBlue;

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

            if (filtroActual != "Todos")
            {
                consulta += $" AND estatus = '{filtroActual}'";
            }

            mu.Mostrar(consulta, DtgDatos, "Usuarios");

            if (modoSeleccion)
            {
                BtnCrear.Visible = false;
                int totalCols = DtgDatos.Columns.Count;
                if (totalCols >= 2)
                {
                    DtgDatos.Columns[totalCols - 1].Visible = false;
                    DtgDatos.Columns[totalCols - 2].Visible = false;
                }
            }
            else
            {
                BtnCrear.Visible = true;
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Verificación de nivel de acceso para la creación de registros
            if (!Sesion.TienePermiso("Usuarios", "crear"))
            {
                MessageBox.Show("Su perfil no cuenta con los permisos necesarios para realizar nuevos registros de usuarios.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            usuario = new Usuarios(0, "", "", "", "", "", "Activo", "");
            FrmDatosUsuarios frmDatos = new FrmDatosUsuarios();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lógica para modo selección (utilizado al asignar suscripciones)
            if (modoSeleccion)
            {
                usuario.IdUsuario = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["idUsuario"].Value);
                usuario.Nombre = DtgDatos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                this.Close();
                return;
            }

            if (e.ColumnIndex < 0) return;

            int indexFila = e.RowIndex;
            int indexColumna = e.ColumnIndex;
            int totalColumnasOriginales = DtgDatos.Columns.Count - 2;

            usuario.IdUsuario = Convert.ToInt32(DtgDatos.Rows[indexFila].Cells["idUsuario"].Value);
            usuario.Nombre = DtgDatos.Rows[indexFila].Cells["nombre"].Value.ToString();
            usuario.CURP = DtgDatos.Rows[indexFila].Cells["curp"].Value.ToString();
            usuario.Telefono = DtgDatos.Rows[indexFila].Cells["telefono"].Value.ToString();
            usuario.Email = DtgDatos.Rows[indexFila].Cells["email"].Value.ToString();
            usuario.FechaNacimiento = Convert.ToDateTime(DtgDatos.Rows[indexFila].Cells["fecha_nacimiento"].Value).ToString("yyyy-MM-dd");

            string estadoFila = DtgDatos.Rows[indexFila].Cells["estatus"].Value.ToString();

            // Validación de operaciones sobre la fila seleccionada
            if (indexColumna == totalColumnasOriginales) // Operación: Editar
            {
                if (!Sesion.TienePermiso("Usuarios", "editar"))
                {
                    MessageBox.Show("No cuenta con privilegios de edición para este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (estadoFila == "Inactivo")
                {
                    MessageBox.Show("No es posible editar la información de un usuario con estatus inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosUsuarios frmDatos = new FrmDatosUsuarios();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            else if (indexColumna == totalColumnasOriginales + 1) // Operación: Gestión de Estatus
            {
                if (!Sesion.TienePermiso("Usuarios", "eliminar"))
                {
                    MessageBox.Show("No tiene autorización para modificar el estatus operativo de los registros.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                bool mandarDesactivar = estadoFila == "Activo";

                mu.CambiarEstado(usuario.IdUsuario, mandarDesactivar);
                ActualizarTabla();
            }
        }
    }
}