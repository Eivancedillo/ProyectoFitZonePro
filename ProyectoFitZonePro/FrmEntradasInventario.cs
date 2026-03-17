using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace ProyectoFitZonePro
{
    public partial class FrmEntradasInventario : Form
    {
        ManejadorInventarios mi;
        int fila = 0,columna = 0;
        public static List<DetalleEntrada> de = new List<DetalleEntrada>();
        public FrmEntradasInventario()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
            mi.GridEntrada(DtgEntrada);
        }

        private void ActualizarTabla()
        {
            string busqueda = TxtBusqueda.Text;
            mi.VerProductos($"select * from v_productosEntrada where Nombre like '%{busqueda}%'", DtgProductos, "tbl_productos");
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla();
        }

        private void DtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validación básica para no tronar el programa
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == 3)
            {
                int fila = e.RowIndex;

                int idProducto = Convert.ToInt32(DtgProductos.Rows[fila].Cells["idProducto"].Value);
                string nombreProducto = DtgProductos.Rows[fila].Cells["Nombre"].Value.ToString();

                bool productoExiste = false;

                foreach (DataGridViewRow row in DtgEntrada.Rows)
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
                    DtgEntrada.Rows.Add(idProducto, nombreProducto, 1, "");
                    DtgEntrada.AutoResizeColumns();
                    DtgEntrada.AutoResizeRows();
                }
            }

        }

        private void DtgEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == 4)
            {
                string producto = DtgEntrada.Rows[e.RowIndex].Cells["Producto"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    $"¿Estás seguro de que quieres quitar '{producto}' de la entrada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    DtgEntrada.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void BtnRealizarEntrada_Click(object sender, EventArgs e)
        {
            if (DtgEntrada.Rows.Count == 0 || (DtgEntrada.Rows.Count == 1 && DtgEntrada.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay productos registrados para dar de entrada.", "Entrada vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            de.Clear();

            foreach (DataGridViewRow row in DtgEntrada.Rows)
            {
                string cantidadTexto = row.Cells["Cantidad"].Value?.ToString();
                string precioTexto = row.Cells["Precio"].Value?.ToString();
                string nombreProd = row.Cells["Producto"].Value?.ToString(); 

                if (!int.TryParse(cantidadTexto, out int cantidadValidada) || cantidadValidada <= 0)
                {
                    MessageBox.Show($"La cantidad ingresada para '{nombreProd}' no es un número válido mayor a 0.", "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(precioTexto, out double precioValidado) || precioValidado < 0)
                {
                    MessageBox.Show($"El precio de costo para '{nombreProd}' está vacío o es incorrecto.", "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DetalleEntrada item = new DetalleEntrada
                {
                    FkIdProduto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                    Cantidad = cantidadValidada,      
                    Precio_Unitario = precioValidado
                };

                de.Add(item);
            }

            // Solo si TODO el ciclo terminó sin errores, abrimos la ventana de observación
            FrmObservacionEntrada foe = new FrmObservacionEntrada();
            if (foe.ShowDialog() == DialogResult.OK)
            {
                DtgEntrada.Rows.Clear();
            }
        }

        private void BtnVerEntradas_Click(object sender, EventArgs e)
        {
            FrmVerEntradas fve = new FrmVerEntradas();
            fve.ShowDialog();
        }

        private void DtgProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }
    }
}
