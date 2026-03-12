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
            mt.Mostrar("SELECT * FROM tbl_trabajadores", DtgDatos, "Trabajadores");
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            trabajador = new Trabajadores(0, "", "", "", "", "Activo");
            FrmDatosTrabajadores frmDatos = new FrmDatosTrabajadores();
            frmDatos.ShowDialog();
            ActualizarTabla();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int fila = e.RowIndex;
            int col = e.ColumnIndex;
            int totalCols = DtgDatos.Columns.Count - 2;

            trabajador.IdTrabajador = Convert.ToInt32(DtgDatos.Rows[fila].Cells["idTrabajador"].Value);
            trabajador.Nombre = DtgDatos.Rows[fila].Cells["nombre"].Value.ToString();
            trabajador.Telefono = DtgDatos.Rows[fila].Cells["telefono"].Value.ToString();
            trabajador.Email = DtgDatos.Rows[fila].Cells["email"].Value.ToString();
            trabajador.Estatus = DtgDatos.Rows[fila].Cells["estatus"].Value.ToString();

            if (col == totalCols) // Botón Editar
            {
                if (trabajador.Estatus.ToLower() == "inactivo")
                {
                    MessageBox.Show("Active al trabajador para poder editarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmDatosTrabajadores frmDatos = new FrmDatosTrabajadores();
                frmDatos.ShowDialog();
                ActualizarTabla();
            }
            else if (col == totalCols + 1) // Botón Estado
            {
                string nuevoEstado = trabajador.Estatus.ToLower() == "activo" ? "Inactivo" : "Activo";
                if (MessageBox.Show($"¿Desea {(nuevoEstado == "Inactivo" ? "desactivar" : "activar")} a este trabajador?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    mt.CambiarEstado(trabajador.IdTrabajador, nuevoEstado);
                    ActualizarTabla();
                }
            }
        }
    }
}