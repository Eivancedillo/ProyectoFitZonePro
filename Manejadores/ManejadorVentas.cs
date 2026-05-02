using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorVentas
    {
        private Base b = new Base();

        //Insertar un nuevo producto
        public void InsertarProducto(Productos producto)
        {
            b.Comando($"call p_insertProducto('{producto.NombreProducto}','{producto.Descripcion}',{producto.PrecioVenta})");
        }

        //Ver todos los productos
        public void VerProductos(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idProducto"].Visible = false;
            tabla.Columns["estado"].Visible = false;
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Actualizar un producto
        public void ActualizarProducto(Productos producto)
        {
            b.Comando($"call p_updateProducto({producto.IdProducto},'{producto.NombreProducto}','{producto.Descripcion}',{producto.PrecioVenta})");
        }

        //Eliminar un producto
        public void EliminarProducto(int id)
        {
            b.Comando($"call p_deleteProducto({id})");
        }

        //Ver productos y agregar al carrito
        public void VerProductosC(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idProducto"].Visible = false;
            tabla.Columns["estado"].Visible = false;
            tabla.Columns["Descripcion"].Visible = false;
            tabla.Columns.Insert(5, Boton("+", Color.DarkGreen));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Llenar comboBox con usuarios
        public void LlenarUsarios(ComboBox combo)
        {
            combo.DataSource = b.Consultar("select idUsuario,nombre as Nombre from tbl_usuarios where estatus = 'Activo'", "tbl_usuarios").Tables[0];
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "idUsuario";
        }

        //Llenar grid carrito
        public void GridCarrito(DataGridView tabla)
        {
            // Limpia antes de configurar para evitar errores si se vuelve a llamar
            tabla.Columns.Clear();

            tabla.Columns.Add("idProducto", "idProducto");
            tabla.Columns["idProducto"].Visible = false;

            tabla.Columns.Add("Producto", "Producto");
            tabla.Columns["Producto"].ReadOnly = true;

            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns["Cantidad"].ReadOnly = false;

            tabla.Columns.Add("Precio", "Precio");
            tabla.Columns["Precio"].ReadOnly = true;

            tabla.Columns.Add("Total", "Total");
            tabla.Columns["Total"].ReadOnly = true; // <-- Corregido, antes decía Precio

            tabla.Columns["Precio"].DefaultCellStyle.Format = "C2";
            tabla.Columns["Total"].DefaultCellStyle.Format = "C2";

            // --- AQUÍ ESTÁ EL TRUCO PARA EL BOTÓN ---
            var btnEliminar = Boton("-", Color.DarkRed);
            tabla.Columns.Insert(5, btnEliminar);

            // Configuramos el ancho del botón MANUALMENTE para que sea corto
            tabla.Columns[5].Width = 35;
            tabla.Columns[5].Resizable = DataGridViewTriState.False;

            // Centramos el "-" para que no se vea pegado a un lado
            tabla.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // El AutoResize debe ir AL FINAL para que respete lo que acabamos de configurar
            tabla.AutoResizeColumns();
            // Pero forzamos que el de la columna 5 NO cambie tras el AutoResize
            tabla.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            tabla.AutoResizeRows();
        }

        //Guardar venta
        public void GuardarVenta(Ventas venta)
        {
            b.Comando($"call p_insertVenta({venta.FkIdUsuario},'{venta.Metodo_pago}')");
        }

        //Guardar detalle venta
        public void GuardarDetalleVenta(int idProducto, int cantidad, double precio)
        {
            b.Comando($"call p_insertDetalleVenta({idProducto},{cantidad},{precio})");
        }

        //Lenar grid ventas
        public void VerVentas(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idVenta"].Visible = false;
            tabla.Columns.Insert(4, Boton("Ver Detalle", Color.DarkGreen));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        //Ver detalle de venta
        public void VerDetalleVenta(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, datos).Tables[0];
            tabla.Columns["idDetalle"].Visible = false;
            tabla.Columns["idVenta"].Visible = false;
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

        //Calcular subtotal de un renglon
        public double CalcularSubtotalRenglon(DataGridViewRow fila)
        {
            try
            {
                double precio = Convert.ToDouble(fila.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                return precio * cantidad;
            }
            catch { return 0; }
        }

        //Obtener datos para corte de caja
        public DataTable ObtenerDatos(string consulta)
        {
            return b.Consultar(consulta, "tbl_ventas").Tables[0];
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
