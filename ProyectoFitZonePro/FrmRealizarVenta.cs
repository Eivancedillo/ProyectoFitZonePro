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
        ManejadorProductos mp;
        public static List<DetalleVentas> carrito = new List<DetalleVentas>();
        int fila = 0 , columna = 0;
        public FrmRealizarVenta()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            mp.GridCarrito(DtgCarrito);
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto fap = new FrmAgregarProducto();
            fap.ShowDialog();
        }

        private void BtnCorteCaja_Click(object sender, EventArgs e)
        {
            
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
            }
        }

        private void DtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (columna == 5)
            {
                int idProducto = Convert.ToInt32(DtgProductos.Rows[fila].Cells["idProducto"].Value);
                string nombreProducto = DtgProductos.Rows[fila].Cells["Nombre"].Value.ToString();
                double precio = Convert.ToDouble(DtgProductos.Rows[fila].Cells["Precio"].Value);

                bool productoExiste = false;

                foreach (DataGridViewRow row in DtgCarrito.Rows)
                {
                    if (!row.IsNewRow && Convert.ToInt32(row.Cells["idProducto"].Value) == idProducto)
                    {
                        int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        row.Cells["Cantidad"].Value = cantidadActual + 1;
                        productoExiste = true;
                        break;
                    }
                }

                if (!productoExiste)
                {
                    DtgCarrito.Rows.Add(idProducto, nombreProducto, 1, precio);
                }
            }
        }

        private void DtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }
    }
}
