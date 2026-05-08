using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmDashboard : Form
    {
        private ManejadorDashboard md;

        public FrmDashboard()
        {
            InitializeComponent();
            md = new ManejadorDashboard();
            this.Shown += FrmDashboard_Shown;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel1 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel2 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, PSom4.Width, PSom4.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel4.Width, Pdel4.Height), radioBorde);
            GraphicsPath rutaPanel5 = CrearRutaRedondeada(new Rectangle(0, 0, PSom5.Width, PSom5.Height), radioBorde);
            GraphicsPath rutaPanel6 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel5.Width, Pdel5.Height), radioBorde);


            Pdel.Region = new Region(rutaPanel1);
            Pdel2.Region = new Region(rutaPanel1);
            Pdel3.Region = new Region(rutaPanel1);
            Pdel4.Region = new Region(rutaPanel4);
            Pdel5.Region = new Region(rutaPanel6);

            PSom.Region = new Region(rutaPanel2);
            PSom2.Region = new Region(rutaPanel2);
            PSom3.Region = new Region(rutaPanel2);
            PSom4.Region = new Region(rutaPanel3);
            PSom5.Region = new Region(rutaPanel5);

            PSom.BackColor = Color.FromArgb(20, Color.Black);
            PSom2.BackColor = Color.FromArgb(20, Color.Black);
            PSom3.BackColor = Color.FromArgb(20, Color.Black);
            PSom4.BackColor = Color.FromArgb(20, Color.Black);
            PSom5.BackColor = Color.FromArgb(20, Color.Black);
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

        private void FrmDashboard_Shown(object sender, EventArgs e)
        {
            CargarDashboardSinBatallar();
        }

        private void CargarDashboardSinBatallar()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int totalMiembros = md.ConsultarMiembrosTotales();
                int activosHoy = md.ConsultarActivosHoy();
                decimal ventasSemana = md.ConsultarVentasSemana();

                LblTotalMiembros.Text = totalMiembros.ToString();
                LblActivosHoy.Text = activosHoy.ToString();
                LblVentasSemana.Text = ventasSemana.ToString("C2");

                DataTable dtRecientes = md.ConsultarEntradasSalidasRecientes();

                if (dtRecientes != null && dtRecientes.Rows.Count > 0)
                {
                    DtgEntradasSalidas.DataSource = dtRecientes;
                    DtgEntradasSalidas.ClearSelection();

                    // 1. Esconder la columna técnica y cabeceras
                    DtgEntradasSalidas.Columns["TipoMovimiento"].Visible = false;
                    DtgEntradasSalidas.ColumnHeadersVisible = false; // Oculta el título "Mensaje"
                    DtgEntradasSalidas.RowHeadersVisible = false;    // Oculta la flecha de la izquierda

                    // 2. Quitar bordes y estilos viejos
                    DtgEntradasSalidas.BorderStyle = BorderStyle.None;
                    DtgEntradasSalidas.CellBorderStyle = DataGridViewCellBorderStyle.None; // Sin líneas divisorias para que parezca una lista limpia
                    DtgEntradasSalidas.BackgroundColor = Color.White; // Color de fondo de tu tarjeta del dashboard

                    // 3. Estilo de las filas
                    DtgEntradasSalidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Que llene todo el ancho disponible
                    DtgEntradasSalidas.RowTemplate.Height = 40; // Filas más altas para que respire el texto y se vea moderno
                    DtgEntradasSalidas.AllowUserToAddRows = false;
                    DtgEntradasSalidas.ReadOnly = true;

                    // 4. Quitar el color azul feo cuando el usuario le dé clic
                    DtgEntradasSalidas.DefaultCellStyle.SelectionBackColor = Color.White;
                    DtgEntradasSalidas.DefaultCellStyle.SelectionForeColor = Color.Black;
                    DtgEntradasSalidas.DefaultCellStyle.Padding = new Padding(15, 0, 0, 0); // Un margen a la izquierda para que no esté pegado al borde

                }
                else
                {
                    DtgEntradasSalidas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo falló al cargar: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DtgEntradasSalidas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos que sea una fila válida y que estemos formateando la columna "Mensaje"
            if (e.RowIndex >= 0 && DtgEntradasSalidas.Columns[e.ColumnIndex].Name == "Mensaje")
            {
                // Obtenemos el tipo de movimiento desde nuestra columna oculta
                string tipo = DtgEntradasSalidas.Rows[e.RowIndex].Cells["TipoMovimiento"].Value.ToString();

                // Aplicamos el color de letra según corresponda para que combine con tu UI
                if (tipo == "Entrada")
                {
                    e.CellStyle.ForeColor = Color.MediumSeaGreen; // Un verde elegante
                }
                else if (tipo == "Salida")
                {
                    e.CellStyle.ForeColor = Color.IndianRed; // Un rojo suave, no tan chillón
                }
            }
        }

        private void TmrActualizarDashboard_Tick(object sender, EventArgs e)
        {
            CargarDashboardSinBatallar();
        }
    }
}