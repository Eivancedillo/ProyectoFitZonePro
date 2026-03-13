using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmEquipos : Form
    {
        private ManejadorEquipos me;
        public static Equipos equipo = new Equipos(0, "", "", "", "");

        public FrmEquipos()
        {
            InitializeComponent();
            me = new ManejadorEquipos();

            CmbEstado.Items.Add("Activos");
            CmbEstado.Items.Add("Inactivos");

            CmbEstado.SelectedIndexChanged += CmbEstado_SelectedIndexChanged;
            this.Shown += FrmEquipos_Shown;
        }

        private void FrmEquipos_Shown(object sender, EventArgs e)
        {
            CmbEstado.SelectedIndex = 0;
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEstado.SelectedIndex == -1) return;
            ActualizarTabla();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            string busqueda = TxtBuscar.Text;

            if (CmbEstado.Text.Equals("Activos"))
            {
                me.Mostrar($"SELECT * FROM v_vista_equipos WHERE nombre_maquina LIKE '%{busqueda}%' and estado = 'Activo'", DtgDatos, "Equipos", true);
            }
            else
            {
                me.Mostrar($"SELECT * FROM v_vista_equipos WHERE nombre_maquina LIKE '%{busqueda}%' and estado = 'Inactivo'", DtgDatos, "Equipos", false);
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Validación de privilegios para creación de registros
            if (!Sesion.TienePermiso("Equipos", "crear"))
            {
                MessageBox.Show("No cuenta con los privilegios suficientes para dar de alta nuevos equipos.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            equipo = new Equipos(0, "", "", "", "Activo");
            FrmDatosEquipos frmDatos = new FrmDatosEquipos();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int indexFila = e.RowIndex;
            int indexColumna = e.ColumnIndex;

            equipo.IdEquipo = Convert.ToInt32(DtgDatos.Rows[indexFila].Cells["idEquipo"].Value);
            equipo.Nombre = DtgDatos.Rows[indexFila].Cells["nombre_maquina"].Value.ToString();
            equipo.Categoria = DtgDatos.Rows[indexFila].Cells["categoria"].Value.ToString();
            equipo.FechaAdquisicion = Convert.ToDateTime(DtgDatos.Rows[indexFila].Cells["fecha_adquisicion"].Value).ToString("yyyy-MM-dd");

            bool esInactivo = CmbEstado.Text.Equals("Inactivos");

            switch (indexColumna)
            {
                // Operación: Editar
                case 6:
                    if (!Sesion.TienePermiso("Equipos", "editar"))
                    {
                        MessageBox.Show("No tiene autorización para modificar la información técnica del equipo.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (esInactivo)
                    {
                        MessageBox.Show("No se puede editar un equipo inactivo. Actívelo primero.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FrmDatosEquipos frmDatos = new FrmDatosEquipos();
                    frmDatos.ShowDialog();
                    ActualizarTabla();
                    break;

                // Operación: Gestión de Mantenimiento
                case 7:
                    if (!Sesion.TienePermiso("Equipos", "editar"))
                    {
                        MessageBox.Show("No cuenta con permisos para programar o registrar mantenimientos.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (esInactivo)
                    {
                        MessageBox.Show("No se puede programar mantenimiento a un equipo inactivo. Actívelo primero.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FrmDatosEquiposMantenimiento frmMantenimiento = new FrmDatosEquiposMantenimiento();
                    frmMantenimiento.ShowDialog();
                    ActualizarTabla();
                    break;

                // Operación: Cambio de Estado (Activar/Desactivar)
                case 8:
                    if (!Sesion.TienePermiso("Equipos", "eliminar"))
                    {
                        MessageBox.Show("No tiene autorización para cambiar el estado operativo de los activos.", "Permiso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (!esInactivo)
                    {
                        me.CambiarEstado(equipo.IdEquipo, true); // Desactivar
                    }
                    else
                    {
                        me.CambiarEstado(equipo.IdEquipo, false); // Activar
                    }
                    ActualizarTabla();
                    break;
            }
        }
    }
}