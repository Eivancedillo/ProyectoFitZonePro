using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmAsistencias : Form
    {
        private ManejadorAsistencias ma;

        public FrmAsistencias()
        {
            InitializeComponent();
            ma = new ManejadorAsistencias();
            this.Shown += FrmAsistencias_Shown;
        }

        private void FrmAsistencias_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            // Filtramos para que solo salgan las asistencias de HOY
            string consulta = $"SELECT * FROM v_vista_asistencias WHERE FechaCorte = CURDATE() AND Cliente LIKE '%{TxtBuscar.Text}%'";
            ma.Mostrar(consulta, DtgDatos, "Asistencias");
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if (!Sesion.TienePermiso("Asistencias", "crear"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para abrir el registro de asistencias.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Rebotado
            }

            // Este botón abrirá la pantalla de recepción (El escáner)
            FrmDatosAsistencias frmReceptor = new FrmDatosAsistencias();
            frmReceptor.ShowDialog();
            ActualizarTabla(); // Cuando cierre, se actualiza la tabla
        }
    }
}