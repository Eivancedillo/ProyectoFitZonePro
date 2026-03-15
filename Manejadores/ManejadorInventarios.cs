using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorInventarios
    {
        Base b = new Base();

        //Llenar grid con productos
        public void VerProductos(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idProducto"].Visible = false;
            tabla.Columns["estado"].Visible = false;
            tabla.Columns.Insert(3, Boton("+", Color.DarkGreen));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Llenar Grid con stock
        public void VerStock(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idProducto"].Visible = false;
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Llenar grid con productos para la entrada de inventario
        public void GridEntrada(DataGridView tabla)
        {
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();

            tabla.Columns.Add("idProducto", "idProducto");
            tabla.Columns["idProducto"].Visible = false;

            tabla.Columns.Add("Producto", "Producto");
            tabla.Columns["Producto"].ReadOnly = true;

            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns["Cantidad"].ReadOnly = false;

            tabla.Columns.Add("Precio", "Precio");
            tabla.Columns["Precio"].ReadOnly = false;

            tabla.Columns["Precio"].DefaultCellStyle.Format = "C2";
            tabla.Columns.Insert(4, Boton("-", Color.DarkRed));
        }

        //Insertar Entrada
        public void GuardarEntrada(Entradas entrada)
        {
            b.Comando($"call p_insertEntrada('{entrada.Observacion}')");
        }

        //Insertar detalle de la entrada
        public void GuardarDetalleEntrada(DetalleEntrada de)
        {
            b.Comando($"call p_insertDetalleEntrada({de.FkIdProduto},{de.Cantidad},{de.Precio_Unitario});");
        }

        //Ver entradas
        public void VerEntradas(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idEntrada"].Visible = false;
            tabla.Columns.Insert(3, Boton("Ver Detalle", Color.DarkGreen));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Ver detalle de la entrada
        public void VerDetalleEntrada(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idDetalleEntrada"].Visible = false;
            tabla.Columns["idEntrada"].Visible = false;
            tabla.Columns["idProducto"].Visible = false;
            tabla.Columns["Precio"].DefaultCellStyle.Format = "C2";
            tabla.Columns["Total"].DefaultCellStyle.Format = "C2";
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Calcular total
        public double CalcularTotal(DataGridView tabla)
        {
            double total = 0.0;

            if (tabla == null || tabla.Rows.Count == 0) return 0.0;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["Precio"].Value != null && row.Cells["Cantidad"].Value != null)
                    {
                        try
                        {
                            double precio = Convert.ToDouble(row.Cells["Precio"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            total += (precio * cantidad);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            return total;
        }

        //Creacion de boton
        private static DataGridViewButtonColumn Boton(string titulo, Color fondo)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Text = titulo,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };
            btn.DefaultCellStyle.BackColor = fondo;
            btn.DefaultCellStyle.ForeColor = Color.White;

            return btn;
        }
    }
}
