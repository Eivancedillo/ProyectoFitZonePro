using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDatosSocios : Form
    {
        private ManejadorSocios ms;

        // Variables internas para guardar lo que seleccionemos de las otras ventanas
        private int idUsuarioSeleccionado = 0;

        private int idMembresiaSeleccionada = 0;
        private double costoMes = 0;
        private double costoSemestre = 0;
        private double costoAnio = 0;

        public FrmDatosSocios()
        {
            InitializeComponent();
            ms = new ManejadorSocios();

            // Llenamos el ComboBox por si no lo has hecho en el diseño
            if (CmbDuracion.Items.Count == 0)
            {
                CmbDuracion.Items.Add("Mensual");
                CmbDuracion.Items.Add("Semestral");
                CmbDuracion.Items.Add("Anual");
            }

            // Le agregamos el evento mágico que calcula los costos y fechas
            CmbDuracion.SelectedIndexChanged += CalcularCostosYFechas;

            // --- LÓGICA MODO EDITAR ---
            if (FrmSocios.socio.IdSuscripcion != 0)
            {
                TxtIdSocio.Text = FrmSocios.socio.IdSuscripcion.ToString("S-0000");
                TxtNombre.Text = FrmSocios.nombreClienteEdit;
                TxtMembresia.Text = FrmSocios.nombrePaqueteEdit;
                idUsuarioSeleccionado = FrmSocios.socio.FkIdUsuario;
                idMembresiaSeleccionada = FrmSocios.socio.FkIdMembresia;
                CmbDuracion.Text = FrmSocios.socio.Duracion;
                TxtCosto.Text = FrmSocios.socio.CostoTotal.ToString("0.00");
            }
            else
            {
                TxtIdSocio.Text = "NUEVO";
                TxtCosto.Text = "0.00";
            }
        }

        // --- BOTÓN SELECTOR DE USUARIO ---
        private void BtnSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuarios.modoSeleccion = true; // Activamos el trucazo
            FrmUsuarios frmU = new FrmUsuarios();
            frmU.ShowDialog();
            FrmUsuarios.modoSeleccion = false; // Lo apagamos al salir

            // Si sí seleccionó a alguien (el ID no es 0)
            if (FrmUsuarios.usuario.IdUsuario != 0)
            {
                idUsuarioSeleccionado = FrmUsuarios.usuario.IdUsuario;
                TxtNombre.Text = FrmUsuarios.usuario.Nombre;
            }
        }

        // --- BOTÓN SELECTOR DE MEMBRESÍA ---
        private void BtnSeleccionarMembresia_Click(object sender, EventArgs e)
        {
            FrmMembresias.modoSeleccion = true; // Activamos el trucazo
            FrmMembresias frmM = new FrmMembresias();
            frmM.ShowDialog();
            FrmMembresias.modoSeleccion = false; // Lo apagamos al salir

            if (FrmMembresias.membresiaSeleccionada.IdMembresia != 0)
            {
                idMembresiaSeleccionada = FrmMembresias.membresiaSeleccionada.IdMembresia;
                TxtMembresia.Text = FrmMembresias.membresiaSeleccionada.Nombre;

                // Guardamos los costos en la memoria para que la calculadora los use
                costoMes = FrmMembresias.membresiaSeleccionada.CostoMensual;
                costoSemestre = FrmMembresias.membresiaSeleccionada.CostoSemestral;
                costoAnio = FrmMembresias.membresiaSeleccionada.CostoAnual;

                // Disparamos la calculadora por si ya había elegido una duración
                CalcularCostosYFechas(null, null);
            }
        }

        // --- LA CALCULADORA AUTOMÁTICA ---
        private void CalcularCostosYFechas(object sender, EventArgs e)
        {
            if (idMembresiaSeleccionada == 0 || CmbDuracion.SelectedItem == null) return;

            string duracion = CmbDuracion.SelectedItem.ToString();

            if (duracion == "Mensual") TxtCosto.Text = costoMes.ToString("0.00");
            else if (duracion == "Semestral") TxtCosto.Text = costoSemestre.ToString("0.00");
            else if (duracion == "Anual") TxtCosto.Text = costoAnio.ToString("0.00");
        }

        // --- GUARDAR EN LA BASE DE DATOS ---
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0 || idMembresiaSeleccionada == 0 || CmbDuracion.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un Usuario, una Membresía y la Duración.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculamos las fechas exactas desde el día de hoy
            DateTime fInicio = DateTime.Now;
            DateTime fFin = DateTime.Now;
            string duracion = CmbDuracion.SelectedItem.ToString();

            if (duracion == "Mensual") fFin = fInicio.AddMonths(1);
            else if (duracion == "Semestral") fFin = fInicio.AddMonths(6);
            else if (duracion == "Anual") fFin = fInicio.AddMonths(12);

            double costoTotal = Convert.ToDouble(TxtCosto.Text);

            // Convertimos las fechas al formato que le gusta a MySQL (Año-Mes-Día)
            string strInicio = fInicio.ToString("yyyy-MM-dd");
            string strFin = fFin.ToString("yyyy-MM-dd");

            if (FrmSocios.socio.IdSuscripcion == 0)
            {
                // MODO CREAR
                Socios nuevo = new Socios(0, idUsuarioSeleccionado, idMembresiaSeleccionada, duracion, strInicio, strFin, costoTotal, "Activo");
                ms.CrearSocio(nuevo);
                MessageBox.Show("¡Socio inscrito exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // MODO EDITAR
                Socios editado = new Socios(FrmSocios.socio.IdSuscripcion, idUsuarioSeleccionado, idMembresiaSeleccionada, duracion, strInicio, strFin, costoTotal, "Activo");
                ms.EditarSocio(editado);
                MessageBox.Show("Suscripción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}