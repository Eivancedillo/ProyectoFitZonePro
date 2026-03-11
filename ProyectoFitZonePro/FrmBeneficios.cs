using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmBeneficios : Form
    {
        private Base b = new Base();
        private DataTable dtTodosLosBeneficios;
        private List<int> respaldoBeneficios;

        public FrmBeneficios()
        {
            InitializeComponent();
            this.Shown += FrmBeneficios_Shown;
        }

        private void FrmBeneficios_Shown(object sender, EventArgs e)
        {
            // Al abrir la ventana, le sacamos una "copia" a los beneficios actuales
            respaldoBeneficios = new List<int>(FrmMembresias.membresiaSeleccionada.BeneficiosIds);
            CargarListas();
        }

        private void CargarListas()
        {
            dtTodosLosBeneficios = b.Consultar("SELECT * FROM tbl_beneficios", "Beneficios").Tables[0];

            DataTable dtExistentes = dtTodosLosBeneficios.Clone();
            DataTable dtAgregados = dtTodosLosBeneficios.Clone();

            foreach (DataRow fila in dtTodosLosBeneficios.Rows)
            {
                int idB = Convert.ToInt32(fila["idBeneficio"]);
                if (FrmMembresias.membresiaSeleccionada.BeneficiosIds.Contains(idB))
                {
                    dtAgregados.ImportRow(fila);
                }
                else
                {
                    dtExistentes.ImportRow(fila);
                }
            }

            DtgDatosExistentes.DataSource = dtExistentes;
            DtgDatosAgregados.DataSource = dtAgregados;

            // Tabla Izquierda (Existentes)
            if (DtgDatosExistentes.Columns.Contains("idBeneficio")) DtgDatosExistentes.Columns["idBeneficio"].Visible = false;
            if (DtgDatosExistentes.Columns.Contains("created_at")) DtgDatosExistentes.Columns["created_at"].Visible = false;
            if (DtgDatosExistentes.Columns.Contains("updated_at")) DtgDatosExistentes.Columns["updated_at"].Visible = false;
            if (DtgDatosExistentes.Columns.Contains("beneficio"))
            {
                DtgDatosExistentes.Columns["beneficio"].HeaderText = "Beneficios Disponibles";
                DtgDatosExistentes.Columns["beneficio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Para que ocupe todo el espacio
            }

            // Tabla Derecha (Agregados)
            if (DtgDatosAgregados.Columns.Contains("idBeneficio")) DtgDatosAgregados.Columns["idBeneficio"].Visible = false;
            if (DtgDatosAgregados.Columns.Contains("created_at")) DtgDatosAgregados.Columns["created_at"].Visible = false;
            if (DtgDatosAgregados.Columns.Contains("updated_at")) DtgDatosAgregados.Columns["updated_at"].Visible = false;
            if (DtgDatosAgregados.Columns.Contains("beneficio"))
            {
                DtgDatosAgregados.Columns["beneficio"].HeaderText = "Asignados a la Membresía";
                DtgDatosAgregados.Columns["beneficio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DtgDatosExistentes.ClearSelection();
            DtgDatosAgregados.ClearSelection();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text)) return;
            b.Comando($"call p_insertBeneficios('{TxtNombre.Text}')");
            TxtNombre.Clear();
            CargarListas();
        }

        private void DtgDatosExistentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idSeleccionado = Convert.ToInt32(DtgDatosExistentes.Rows[e.RowIndex].Cells["idBeneficio"].Value);
            if (!FrmMembresias.membresiaSeleccionada.BeneficiosIds.Contains(idSeleccionado))
            {
                FrmMembresias.membresiaSeleccionada.BeneficiosIds.Add(idSeleccionado);
                CargarListas();
            }
        }

        private void DtgDatosAgregados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int idSeleccionado = Convert.ToInt32(DtgDatosAgregados.Rows[e.RowIndex].Cells["idBeneficio"].Value);
            if (FrmMembresias.membresiaSeleccionada.BeneficiosIds.Contains(idSeleccionado))
            {
                FrmMembresias.membresiaSeleccionada.BeneficiosIds.Remove(idSeleccionado);
                CargarListas();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Restauramos la lista de beneficios a como estaba antes de abrir la ventana
            FrmMembresias.membresiaSeleccionada.BeneficiosIds = new List<int>(respaldoBeneficios);
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Los cambios ya se hicieron en la memoria de "membresiaSeleccionada", solo cerramos
            Close();
        }
    }
}