using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmSocios : Form
    {
        private ManejadorSocios ms;
        public static Socios socio = new Socios(0, 0, 0, "", "", "", 0.0, "Activo");
        public static string nombreClienteEdit = "";
        public static string nombrePaqueteEdit = "";

        public FrmSocios()
        {
            InitializeComponent();
            ms = new ManejadorSocios();
            this.Shown += FrmSocios_Shown;
        }

        private void FrmSocios_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            // Carga de datos mediante la vista configurada en la base de datos
            string consulta = $"SELECT * FROM v_vista_suscripciones WHERE Cliente LIKE '%{TxtBuscar.Text}%'";
            ms.Mostrar(consulta, DtgDatos, "Suscripciones");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Validación de privilegios para inscripción de nuevos socios
            if (!Sesion.TienePermiso("Socios", "crear"))
            {
                MessageBox.Show("No cuenta con autorización para dar de alta nuevas suscripciones.", "Restricción de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Reinicio de objeto para nueva captura
            socio = new Socios(0, 0, 0, "", "", "", 0.0, "Activo");
            FrmDatosSocios frmDatos = new FrmDatosSocios();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int fila = e.RowIndex;
            int col = e.ColumnIndex;
            int totalCols = DtgDatos.Columns.Count - 2;

            // Mapeo de datos de la fila seleccionada al objeto global
            socio.IdSuscripcion = Convert.ToInt32(DtgDatos.Rows[fila].Cells["idSuscripcion"].Value);
            socio.FkIdUsuario = Convert.ToInt32(DtgDatos.Rows[fila].Cells["fkIdUsuario"].Value);
            socio.FkIdMembresia = Convert.ToInt32(DtgDatos.Rows[fila].Cells["fkIdMembresia"].Value);
            socio.Duracion = DtgDatos.Rows[fila].Cells["duracion"].Value.ToString();
            nombreClienteEdit = DtgDatos.Rows[fila].Cells["Cliente"].Value.ToString();
            nombrePaqueteEdit = DtgDatos.Rows[fila].Cells["Paquete"].Value.ToString();

            socio.FechaInicio = Convert.ToDateTime(DtgDatos.Rows[fila].Cells["fecha_inicio"].Value).ToString("yyyy-MM-dd");
            socio.FechaFin = Convert.ToDateTime(DtgDatos.Rows[fila].Cells["fecha_fin"].Value).ToString("yyyy-MM-dd");

            socio.CostoTotal = Convert.ToDouble(DtgDatos.Rows[fila].Cells["costo_total"].Value);
            socio.estado = DtgDatos.Rows[fila].Cells["estado"].Value.ToString().ToLower();

            // Operación: Editar Suscripción
            if (col == totalCols)
            {
                if (!Sesion.TienePermiso("Socios", "editar"))
                {
                    MessageBox.Show("No tiene privilegios para modificar suscripciones existentes.", "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (socio.estado == "cancelado")
                {
                    MessageBox.Show("No se permite la edición de registros con estatus 'Cancelado'.", "Aviso de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosSocios frmDatos = new FrmDatosSocios();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            // Operación: Gestión de Estatus (Cancelar / Reactivar)
            else if (col == totalCols + 1)
            {
                if (!Sesion.TienePermiso("Socios", "eliminar"))
                {
                    MessageBox.Show("No cuenta con permisos para realizar cambios de estado o cancelaciones.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (socio.estado == "activo")
                {
                    if (MessageBox.Show("¿Confirmar la cancelación de la suscripción seleccionada?", "Validación de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ms.CambiarEstado(socio.IdSuscripcion, "cancelado");
                    }
                }
                else if (socio.estado == "vencido" || socio.estado == "cancelado")
                {
                    if (MessageBox.Show("¿Desea reactivar la suscripción? Es necesario actualizar los periodos de vigencia posteriormente.", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ms.CambiarEstado(socio.IdSuscripcion, "activo");
                    }
                }
                ActualizarTabla();
            }
        }
    }
}