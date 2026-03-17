using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFitZonePro
{
    public partial class FrmRealizarVenta : Form
    {
        ManejadorVentas mp;
        public static List<DetalleVentas> carrito = new List<DetalleVentas>();
        int fila = 0 , columna = 0;
        public FrmRealizarVenta()
        {
            InitializeComponent();
            mp = new ManejadorVentas();
            mp.GridCarrito(DtgCarrito);
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto fap = new FrmAgregarProducto();
            fap.ShowDialog();
        }

        private void BtnCorteCaja_Click(object sender, EventArgs e)
        {
            FrmCorteCaja fcc = new FrmCorteCaja();
            fcc.ShowDialog();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        //Actualizar tabla al escribir en el cuadro de búsqueda
        private void ActualizarTabla()
        {
            string busqueda = TxtBusqueda.Text;
            mp.VerProductosC($"select * from v_productos where Nombre like '%{busqueda}%'", DtgProductos, "tbl_productos");
        }

        private void BtnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if(DtgCarrito.Rows.Count > 0)
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

        private void ActualizarEtiquetaTotal()
        {
            double totalVenta = mp.CalcularTotal(DtgCarrito);
            LblTotalVenta.Text = $"Total de la venta: {totalVenta.ToString("C2")}";
        }
    }
}
