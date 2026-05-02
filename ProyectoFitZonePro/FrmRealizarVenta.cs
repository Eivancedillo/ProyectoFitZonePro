using Entidades;
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
    public partial class FrmRealizarVenta : Form
    {
        private ManejadorVentas mp;
        public static List<DetalleVentas> carrito = new List<DetalleVentas>();
        private int fila = 0, columna = 0;

        public FrmRealizarVenta()
        {
            InitializeComponent();
            mp = new ManejadorVentas();
            mp.GridCarrito(DtgCarrito);
            this.Shown += FrmRealizarVenta_Shown;
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            // --- CANDADO: ¿Tiene permiso de crear productos/tienda? ---
            if (!Sesion.TienePermiso("Tienda", "crear"))
            {
                MessageBox.Show("¡Acceso Denegado! No tienes autorización para agregar nuevos productos al catálogo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            // ----------------------------------------------------------

            FrmAgregarProducto fap = new FrmAgregarProducto();
            fap.ShowDialog();
        }

        private void BtnCorteCaja_Click(object sender, EventArgs e)
        {
            FrmCorteCaja fcc = new FrmCorteCaja();
            fcc.ShowDialog();
        }

        //Actualizar tabla al escribir en el cuadro de búsqueda
        private void ActualizarTabla()
        {
            string busqueda = TxtBusqueda.Text;
            mp.VerProductosC($"select * from v_productos where Nombre like '%{busqueda}%'", DtgProductos, "tbl_productos");
        }

        private void BtnFinalizarVenta_Click(object sender, EventArgs e)
        {
            // --- CANDADO: ¿Tiene permiso para registrar ventas? ---
            if (!Sesion.TienePermiso("Tienda", "crear"))
            {
                MessageBox.Show("¡Acceso Denegado! Tu usuario no tiene permisos para cobrar ni registrar ventas.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            // ------------------------------------------------------

            if (DtgCarrito.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DtgCarrito.Rows)
                {
                    DetalleVentas item = new DetalleVentas
                    {
                        FkIdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        Precio = Convert.ToDouble(row.Cells["Precio"].Value)
                    };
                    carrito.Add(item);
                }
                FrmConfirmarVenta fcv = new FrmConfirmarVenta();
                if (fcv.ShowDialog() == DialogResult.OK)
                {
                    DtgCarrito.Rows.Clear();
                    LblTotalVenta.Text = "Total de la venta: $0.00";
                }
            }
            else
            {
                MessageBox.Show("No hay productos en el carrito para finalizar la venta.", "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == 5)
            {
                int fila = e.RowIndex;

                int idProducto = Convert.ToInt32(DtgProductos.Rows[fila].Cells["idProducto"].Value);
                string nombreProducto = DtgProductos.Rows[fila].Cells["Nombre"].Value.ToString();
                double precio = Convert.ToDouble(DtgProductos.Rows[fila].Cells["Precio"].Value);

                bool productoExiste = false;

                foreach (DataGridViewRow row in DtgCarrito.Rows)
                {
                    if (!row.IsNewRow && Convert.ToInt32(row.Cells["idProducto"].Value) == idProducto)
                    {
                        int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        int nuevaCantidad = cantidadActual + 1;
                        row.Cells["Cantidad"].Value = nuevaCantidad;
                        row.Cells["Total"].Value = nuevaCantidad * precio;

                        productoExiste = true;
                        break;
                    }
                }

                if (!productoExiste)
                {
                    DtgCarrito.Rows.Add(idProducto, nombreProducto, 1, precio, precio);
                }
                ActualizarEtiquetaTotal();
                ActualizarTabla();
            }
        }

        private void DtgCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == 5)
            {
                string producto = DtgCarrito.Rows[e.RowIndex].Cells["Producto"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Estás seguro de que quieres quitar '{producto}' del carrito?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    DtgCarrito.Rows.RemoveAt(e.RowIndex);
                    ActualizarEtiquetaTotal();
                }
            }
        }

        private void DtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        private void DtgCarrito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgCarrito.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                DataGridViewRow fila = DtgCarrito.Rows[e.RowIndex];
                fila.Cells["Total"].Value = mp.CalcularSubtotalRenglon(fila);
                ActualizarEtiquetaTotal();
            }
        }

        private void FrmRealizarVenta_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnCorteCaja.Width, BtnCorteCaja.Height), radioBorde);

            Pdel.Region = new Region(rutaPanel3);
            PSom.Region = new Region(rutaPanel4);
            Pdel2.Region = new Region(rutaPanel3);
            PSom2.Region = new Region(rutaPanel4);
            BtnCorteCaja.Region = new Region(rutaBoton1);
            BtnAgregarProducto.Region = new Region(rutaBoton1);
            BtnFinalizarVenta.Region = new Region(rutaBoton1);

            Pdel.BackColor = Color.White;
            Pdel2.BackColor = Color.White;
            PSom.BackColor = Color.FromArgb(20, Color.Black);
            PSom2.BackColor = Color.FromArgb(20, Color.Black);
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

        private void FrmRealizarVenta_Shown(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void ActualizarEtiquetaTotal()
        {
            double totalVenta = mp.CalcularTotal(DtgCarrito);
            LblTotalVenta.Text = $"Total de la venta: {totalVenta.ToString("C2")}";
        }
    }
}