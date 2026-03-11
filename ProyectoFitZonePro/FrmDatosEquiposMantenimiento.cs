using Manejadores;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosEquiposMantenimiento : Form
    {
        private ManejadorEquipos me;
        private int idMantenimientoPendiente = 0;

        public FrmDatosEquiposMantenimiento()
        {
            InitializeComponent();
            me = new ManejadorEquipos();

            // Cargar datos iniciales del equipo bloqueando su edición
            TxtNombre.Text = FrmEquipos.equipo.Nombre;
            TxtNombre.Enabled = false;

            TxtIdEquipo.Text = "M-" + FrmEquipos.equipo.IdEquipo.ToString("0000");
            TxtIdEquipo.Enabled = false;

            VerificarMantenimientoPendiente();
        }

        private void VerificarMantenimientoPendiente()
        {
            DataTable dtPendiente = me.ObtenerMantenimientoPendiente(FrmEquipos.equipo.IdEquipo);

            if (dtPendiente.Rows.Count > 0)
            {
                // Configurar ventana para finalizar un mantenimiento activo
                idMantenimientoPendiente = Convert.ToInt32(dtPendiente.Rows[0]["idMantenimiento"]);

                DtpFechaAdquisicion.Value = Convert.ToDateTime(dtPendiente.Rows[0]["fecha_mantenimiento"]);
                DtpFechaAdquisicion.Enabled = false;

                BtnAceptar.Enabled = false;
                BtnFinalizar.Enabled = true;
            }
            else
            {
                // Configurar ventana para programar uno nuevo
                BtnAceptar.Enabled = true;
                BtnFinalizar.Enabled = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string fechaFormateada = DtpFechaAdquisicion.Value.ToString("yyyy-MM-dd HH:mm:ss");

            me.CrearMantenimiento(FrmEquipos.equipo.IdEquipo, fechaFormateada);
            MessageBox.Show("Mantenimiento programado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (idMantenimientoPendiente > 0)
            {
                DialogResult rs = MessageBox.Show("¿Desea marcar este mantenimiento como finalizado con la fecha actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    me.FinalizarMantenimiento(idMantenimientoPendiente);
                    MessageBox.Show("Mantenimiento finalizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}