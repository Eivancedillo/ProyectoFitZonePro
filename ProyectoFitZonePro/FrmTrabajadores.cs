using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmTrabajadores : Form
    {
        private ManejadorTrabajadores mt;
        public static Trabajadores trabajador = new Trabajadores(0, "", "", "", "", "Activo");

        public FrmTrabajadores()
        {
            InitializeComponent();
            mt = new ManejadorTrabajadores();
            this.Shown += FrmTrabajadores_Shown;
        }

        private void FrmTrabajadores_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            // Carga de la lista completa de trabajadores desde la base de datos
            mt.Mostrar("SELECT * FROM tbl_trabajadores", DtgDatos, "Trabajadores");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Validación de privilegios para el alta de nuevo personal
            if (!Sesion.TienePermiso("Trabajadores", "crear"))
            {
                MessageBox.Show("No cuenta con los privilegios necesarios para registrar nuevo personal en el sistema.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            trabajador = new Trabajadores(0, "", "", "", "", "Activo");
            FrmDatosTrabajadores frmDatos = new FrmDatosTrabajadores();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificación de integridad del clic en la cuadrícula de datos
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int fila = e.RowIndex;
            int col = e.ColumnIndex;
            int totalCols = DtgDatos.Columns.Count - 2;

            // Mapeo de la fila seleccionada al objeto global de trabajo
            trabajador.IdTrabajador = Convert.ToInt32(DtgDatos.Rows[fila].Cells["idTrabajador"].Value);
            trabajador.Nombre = DtgDatos.Rows[fila].Cells["nombre"].Value.ToString();
            trabajador.Telefono = DtgDatos.Rows[fila].Cells["telefono"].Value.ToString();
            trabajador.Email = DtgDatos.Rows[fila].Cells["email"].Value.ToString();
            trabajador.Estatus = DtgDatos.Rows[fila].Cells["estatus"].Value.ToString();

            // --- OPERACIÓN: EDITAR INFORMACIÓN ---
            if (col == totalCols)
            {
                // Verificación de permisos de edición para el módulo de personal
                if (!Sesion.TienePermiso("Trabajadores", "editar"))
                {
                    MessageBox.Show("No tiene autorización para modificar los perfiles de los trabajadores.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (trabajador.Estatus.ToLower() == "inactivo")
                {
                    MessageBox.Show("El registro se encuentra inactivo. Debe reactivarlo para permitir modificaciones.", "Aviso de Estatus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosTrabajadores frmDatos = new FrmDatosTrabajadores();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            // --- OPERACIÓN: GESTIÓN DE ESTATUS (BAJAS/REACTIVACIONES) ---
            else if (col == totalCols + 1)
            {
                // Validación de privilegios para la modificación de estatus operativo (equivalente a eliminación lógica)
                if (!Sesion.TienePermiso("Trabajadores", "eliminar"))
                {
                    MessageBox.Show("No cuenta con autorización para cambiar el estado de los usuarios del sistema.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string nuevoEstado = trabajador.Estatus.ToLower() == "activo" ? "Inactivo" : "Activo";
                if (MessageBox.Show($"¿Confirmar el cambio de estado a '{nuevoEstado}' para el trabajador seleccionado?", "Validación de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mt.CambiarEstado(trabajador.IdTrabajador, nuevoEstado);
                    ActualizarTabla();
                }
            }
        }
    }
}