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
    public class ManejadorProductos
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
            tabla.Columns.Insert(5, Boton("+", Color.DarkGreen));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
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
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();

            tabla.Columns.Add("idProducto", "idProducto");
            tabla.Columns["idProducto"].Visible = false;

            tabla.Columns.Add("Producto", "Producto");
            tabla.Columns["Producto"].ReadOnly = true;

            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns["Cantidad"].ReadOnly = false;

            tabla.Columns.Add("Precio", "Precio");
            tabla.Columns["Precio"].ReadOnly = true;

            tabla.Columns["Precio"].DefaultCellStyle.Format = "C2";
        }

        //Guardar venta
        public void GuardarVenta(Ventas venta)
        {
            b.Comando($"call p_insertVenta({venta.FkIdUsuario},'{venta.Metodo_pago}')");
        }

        //Guardar detalle venta
        public void GuardarDetalleVenta(int idProducto,int cantidad,double precio)
        {
            b.Comando($"call p_insertDetalleVenta({idProducto},{cantidad},{precio})");
        }
    }
}
