using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmMembresias : Form
    {
        private ManejadorMembresias mb;

        // Objeto global estático para pasarlo a la ventana de edición
        public static Membresias membresiaSeleccionada = new Membresias(0, "", 0, 0, 0, "Activo");

        public static bool modoSeleccion = false;

        public FrmMembresias()
        {
            InitializeComponent();
            mb = new ManejadorMembresias();
            this.Shown += FrmMembresias_Shown;

        }

        private void FrmMembresias_Shown(object sender, EventArgs e)
        {
            ActualizarTodo();
        }

        private void ActualizarTodo()
        {
            // 1. Llenamos la tabla general
            mb.Mostrar("SELECT * FROM tbl_membresias", DtgDatos, "Membresias");

            // MAGIA DE LIMPIEZA VISUAL
            if (modoSeleccion)
            {
                BtnCrear.Visible = false;

                int totalCols = DtgDatos.Columns.Count;
                if (totalCols >= 2)
                {
                    DtgDatos.Columns[totalCols - 1].Visible = false;
                    DtgDatos.Columns[totalCols - 2].Visible = false;
                }
            }
            else
            {
                BtnCrear.Visible = true;
            }

            // 2. Cargamos las tarjetas mágicas del Top 3
            CargarPanelesTop3();
        }

        private void CargarPanelesTop3()
        {
            DataTable dtTop = mb.ObtenerTop3();

            // Si hay al menos 1 registro, llenamos el Panel 1
            if (dtTop.Rows.Count > 0)
            {
                DataRow fila1 = dtTop.Rows[0];
                // Asegúrate de tener un LblNombreTop1, LblPreciosTop1 y LblBeneficiosTop1 dentro de tu primer panel
                LblNombreTop1.Text = fila1["nombre"].ToString().ToUpper();
                LblPreciosTop1.Text = $"1M: ${fila1["costo_mensual"]} | 6M: ${fila1["costo_semestral"]} | 12M: ${fila1["costo_anual"]}";
                LblBeneficiosTop1.Text = fila1["beneficios"].ToString();
            }

            // Si hay 2 registros, llenamos el Panel 2
            if (dtTop.Rows.Count > 1)
            {
                DataRow fila2 = dtTop.Rows[1];
                LblNombreTop2.Text = fila2["nombre"].ToString().ToUpper();
                LblPreciosTop2.Text = $"1M: ${fila2["costo_mensual"]} | 6M: ${fila2["costo_semestral"]} | 12M: ${fila2["costo_anual"]}";
                LblBeneficiosTop2.Text = fila2["beneficios"].ToString();
            }

            // Si hay 3 registros, llenamos el Panel 3
            if (dtTop.Rows.Count > 2)
            {
                DataRow fila3 = dtTop.Rows[2];
                LblNombreTop3.Text = fila3["nombre"].ToString().ToUpper();
                LblPreciosTop3.Text = $"1M: ${fila3["costo_mensual"]} | 6M: ${fila3["costo_semestral"]} | 12M: ${fila3["costo_anual"]}";
                LblBeneficiosTop3.Text = fila3["beneficios"].ToString();
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            // EL CADENERO DE CREACIÓN
            if (!Sesion.TienePermiso("Membresias", "crear"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes permiso para crear nuevas membresías.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Lo rebotamos
            }

            membresiaSeleccionada = new Membresias(0, "", 0.0, 0.0, 0.0, "Activo");
            membresiaSeleccionada.BeneficiosIds = new List<int>();

            FrmDatosMembresias frmDatos = new FrmDatosMembresias();
            frmDatos.ShowDialog();
            ActualizarTodo();
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (modoSeleccion)
            {
                membresiaSeleccionada.IdMembresia = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["idMembresia"].Value);
                membresiaSeleccionada.Nombre = DtgDatos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                membresiaSeleccionada.CostoMensual = Convert.ToDouble(DtgDatos.Rows[e.RowIndex].Cells["costo_mensual"].Value);
                membresiaSeleccionada.CostoSemestral = Convert.ToDouble(DtgDatos.Rows[e.RowIndex].Cells["costo_semestral"].Value);
                membresiaSeleccionada.CostoAnual = Convert.ToDouble(DtgDatos.Rows[e.RowIndex].Cells["costo_anual"].Value);
                this.Close();
                return;
            }

            int fila = e.RowIndex;
            int col = e.ColumnIndex;
            int totalColumnasOriginales = DtgDatos.Columns.Count - 2;

            // Guardamos los datos de la fila clickeada en nuestro objeto global
            membresiaSeleccionada.IdMembresia = Convert.ToInt32(DtgDatos.Rows[fila].Cells["idMembresia"].Value);
            membresiaSeleccionada.Nombre = DtgDatos.Rows[fila].Cells["nombre"].Value.ToString();
            membresiaSeleccionada.CostoMensual = Convert.ToDouble(DtgDatos.Rows[fila].Cells["costo_mensual"].Value);
            membresiaSeleccionada.CostoSemestral = Convert.ToDouble(DtgDatos.Rows[fila].Cells["costo_semestral"].Value);
            membresiaSeleccionada.CostoAnual = Convert.ToDouble(DtgDatos.Rows[fila].Cells["costo_anual"].Value);
            string estatusFila = DtgDatos.Rows[fila].Cells["estatus"].Value.ToString();

            // Botón Editar
            if (col == totalColumnasOriginales)
            {
                if (!Sesion.TienePermiso("Membresias", "editar"))
                {
                    MessageBox.Show("¡Acceso Denegado! No tienes permiso para modificar la información.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (estatusFila == "Inactivo")
                {
                    MessageBox.Show("Active la membresía primero para poder editarla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                membresiaSeleccionada.BeneficiosIds = mb.ObtenerBeneficiosPorMembresia(membresiaSeleccionada.IdMembresia);

                FrmDatosMembresias frmDatos = new FrmDatosMembresias();
                frmDatos.ShowDialog();
                ActualizarTodo();
            }
            // Botón Activar/Desactivar
            else if (col == totalColumnasOriginales + 1)
            {
                if (!Sesion.TienePermiso("Membresias", "eliminar"))
                {
                    MessageBox.Show("¡Acceso Denegado! No tienes permiso para activar o desactivar registros.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool mandarDesactivar = estatusFila == "Activo";
                mb.CambiarEstado(membresiaSeleccionada.IdMembresia, mandarDesactivar);
                ActualizarTodo();
            }
        }

        private void FrmMembresias_Load(object sender, EventArgs e)
        {
            int radioBorde = 5; // Puedes hacer este número más grande para más curva

            // Creamos la ruta del tamaño exacto del panel
            GraphicsPath rutaPanel1 = CrearRutaRedondeada(new Rectangle(0, 0, Ps1.Width, Ps1.Height), radioBorde);
            GraphicsPath rutaPanel2 = CrearRutaRedondeada(new Rectangle(0, 0, PTop4.Width, PTop4.Height), radioBorde);
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, PTop1.Width, PTop1.Height), radioBorde);
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnCrear.Width, BtnCrear.Height), radioBorde);


            // Aplicamos el recorte al panel
            Ps1.Region = new Region(rutaPanel1);
            Ps2.Region = new Region(rutaPanel1);
            Ps3.Region = new Region(rutaPanel1);
            PTop1.Region = new Region(rutaPanel3);
            PTop2.Region = new Region(rutaPanel3);
            PTop3.Region = new Region(rutaPanel3);
            PTop4.Region = new Region(rutaPanel2);
            PTop5.Region = new Region(rutaPanel2);
            PTop6.Region = new Region(rutaPanel2);
            BtnCrear.Region = new Region(rutaBoton1);


            //Este es el para el panel de la sombre
            Ps1.BackColor = Color.FromArgb(20, Color.Black);
            Ps2.BackColor = Color.FromArgb(20, Color.Black);
            Ps3.BackColor = Color.FromArgb(20, Color.Black);
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