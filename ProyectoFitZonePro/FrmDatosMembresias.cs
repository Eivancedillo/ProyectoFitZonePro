using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void FrmDatosMembresias_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAceptar.Width, BtnAceptar.Height), radioBorde);
            GraphicsPath rutaBoton2 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAnadirBeneficios.Width, BtnAnadirBeneficios.Height), radioBorde);

            BtnAceptar.Region = new Region(rutaBoton1);
            BtnCancelar.Region = new Region(rutaBoton1);
            BtnAnadirBeneficios.Region = new Region(rutaBoton2);
        }
        private GraphicsPath CrearRutaRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath ruta = new GraphicsPath();
            int diametro = radio * 2;

            // Dibujamos los 4 arcos de las esquinas
            ruta.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90); // Arriba Izquierda
            ruta.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90); // Arriba Derecha
            ruta.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90); // Abajo Derecha
            ruta.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90); // Abajo Izquierda

            ruta.CloseFigure(); // Cerramos la figura uniendo los arcos
            return ruta;
        }
    }
}