using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosMembresias : Form
    {
        private ManejadorMembresias mb;

        public FrmDatosMembresias()
        {
            InitializeComponent();
            mb = new ManejadorMembresias();

            // Evento mágico para la calculadora automática
            TxtCostoMensual.TextChanged += TxtCostoMensual_TextChanged;

            // Si el ID es diferente de 0, es porque estamos Editando
            if (FrmMembresias.membresiaSeleccionada.IdMembresia != 0)
            {
                TxtNombre.Text = FrmMembresias.membresiaSeleccionada.Nombre;
                TxtCostoMensual.Text = FrmMembresias.membresiaSeleccionada.CostoMensual.ToString("0.00");
                TxtCostoSemestral.Text = FrmMembresias.membresiaSeleccionada.CostoSemestral.ToString("0.00");
                TxtCostoAnual.Text = FrmMembresias.membresiaSeleccionada.CostoAnual.ToString("0.00");
            }
        }

        private void TxtCostoMensual_TextChanged(object sender, EventArgs e)
        {
            // Solo se calcula si el usuario está escribiendo directamente en esta caja
            if (TxtCostoMensual.Focused && double.TryParse(TxtCostoMensual.Text, out double mensual))
            {
                // Semestral: 6 meses con 10% de descuento (* 0.90)
                TxtCostoSemestral.Text = ((mensual * 6) * 0.90).ToString("0.00");

                // Anual: 12 meses con 20% de descuento (* 0.80)
                TxtCostoAnual.Text = ((mensual * 12) * 0.80).ToString("0.00");
            }
        }

        private void BtnAnadirBeneficios_Click(object sender, EventArgs e)
        {
            // Abrimos la ventana doble para gestionar la relación N a N
            FrmBeneficios frmBen = new FrmBeneficios();
            frmBen.ShowDialog();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtCostoMensual.Text))
            {
                MessageBox.Show("Por favor, complete al menos el nombre y el costo mensual.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double cMensual = Convert.ToDouble(TxtCostoMensual.Text);
            double cSemestral = Convert.ToDouble(TxtCostoSemestral.Text);
            double cAnual = Convert.ToDouble(TxtCostoAnual.Text);

            if (FrmMembresias.membresiaSeleccionada.IdMembresia == 0)
            {
                // MODO CREAR
                Membresias nueva = new Membresias(0, TxtNombre.Text, cMensual, cSemestral, cAnual, "Activo");

                // ¡Atrapamos el nuevo ID!
                int nuevoId = mb.CrearMembresia(nueva);

                // Vinculamos los beneficios guardados en memoria a este nuevo ID
                mb.VincularBeneficios(nuevoId, FrmMembresias.membresiaSeleccionada.BeneficiosIds);

                MessageBox.Show("Membresía creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // MODO EDITAR
                Membresias editada = new Membresias(FrmMembresias.membresiaSeleccionada.IdMembresia, TxtNombre.Text, cMensual, cSemestral, cAnual, "Activo");
                mb.EditarMembresia(editada);

                // Vinculamos los beneficios al ID ya existente
                mb.VincularBeneficios(editada.IdMembresia, FrmMembresias.membresiaSeleccionada.BeneficiosIds);

                MessageBox.Show("Membresía actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}