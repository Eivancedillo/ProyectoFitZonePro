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
            // ¡Mira nomás qué hermosura de consulta limpia gracias a tu Vista!
            string consulta = $"SELECT * FROM v_vista_suscripciones WHERE Cliente LIKE '%{TxtBuscar.Text}%'";
            ms.Mostrar(consulta, DtgDatos, "Suscripciones");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // Limpiamos la memoria
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

            // Llenamos el objeto estático con la fila seleccionada
            socio.IdSuscripcion = Convert.ToInt32(DtgDatos.Rows[fila].Cells["idSuscripcion"].Value);
            socio.FkIdUsuario = Convert.ToInt32(DtgDatos.Rows[fila].Cells["fkIdUsuario"].Value);
            socio.FkIdMembresia = Convert.ToInt32(DtgDatos.Rows[fila].Cells["fkIdMembresia"].Value);
            socio.Duracion = DtgDatos.Rows[fila].Cells["duracion"].Value.ToString();
            nombreClienteEdit = DtgDatos.Rows[fila].Cells["Cliente"].Value.ToString();
            nombrePaqueteEdit = DtgDatos.Rows[fila].Cells["Paquete"].Value.ToString();

            socio.FechaInicio = Convert.ToDateTime(DtgDatos.Rows[fila].Cells["fecha_inicio"].Value).ToString("yyyy-MM-dd");
            socio.FechaFin = Convert.ToDateTime(DtgDatos.Rows[fila].Cells["fecha_fin"].Value).ToString("yyyy-MM-dd");

            socio.CostoTotal = Convert.ToDouble(DtgDatos.Rows[fila].Cells["costo_total"].Value);
            socio.estado = DtgDatos.Rows[fila].Cells["estado"].Value.ToString();

            // Botón Editar
            if (col == totalCols)
            {
                if (socio.estado == "cancelado")
                {
                    MessageBox.Show("No se puede editar una suscripción cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosSocios frmDatos = new FrmDatosSocios();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            // Botón Estado (Cancelar / Renovar / Reactivar)
            else if (col == totalCols + 1)
            {
                if (socio.estado == "activo")
                {
                    if (MessageBox.Show("¿Desea cancelar esta suscripción?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ms.CambiarEstado(socio.IdSuscripcion, "Cancelado");
                }
                else if (socio.estado == "vencido" || socio.estado == "cancelado")
                {
                    if (MessageBox.Show("¿Desea reactivar/renovar esta suscripción? Deberá editar las fechas.", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ms.CambiarEstado(socio.IdSuscripcion, "Activo");
                        // Aquí podríamos abrir FrmDatosSocios automáticamente para que le cobren el nuevo periodo
                    }
                }
                ActualizarTabla();
            }
        }
    }
}