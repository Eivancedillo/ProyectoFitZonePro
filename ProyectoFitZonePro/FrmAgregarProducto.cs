using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public partial class FrmAgregarProducto : Form
    {
        Productos producto = new Productos(0, "", "", 0.0);
        ManejadorVentas mp;
        public FrmAgregarProducto()
        {
            InitializeComponent();
            mp = new ManejadorVentas();
            mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                mp.InsertarProducto(new Productos(0, TxtNombre.Text, TxtDesc.Text, Convert.ToDouble(TxtPrecio.Text)));
                mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
                TxtNombre.Clear();
                TxtDesc.Clear();
                TxtPrecio.Clear();
                TxtNombre.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show($"Ingrese datos validos para el producto", "Ok", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(DtgProductos.SelectedRows[0].Cells["idProducto"].Value);
                string Nombre = Convert.ToString(DtgProductos.SelectedRows[0].Cells["Nombre"].Value);
                string Desc = Convert.ToString(DtgProductos.SelectedRows[0].Cells["Descripcion"].Value);
                double Precio = Convert.ToDouble(DtgProductos.SelectedRows[0].Cells["Precio"].Value);

                var confirm = MessageBox.Show($"¿Deseas editar el producto: {Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    mp.ActualizarProducto(new Productos(id, TxtNombre.Text, TxtDesc.Text, Convert.ToDouble(TxtPrecio.Text)));
                    mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
                    TxtNombre.Clear();
                    TxtDesc.Clear();
                    TxtPrecio.Clear();
                    TxtNombre.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Elija un producto para actualizar", "Ok", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void DtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DtgProductos.Rows[e.RowIndex];

                TxtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                TxtDesc.Text = fila.Cells["Descripcion"].Value.ToString();
                TxtPrecio.Text = fila.Cells["Precio"].Value.ToString();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(DtgProductos.SelectedRows[0].Cells["idProducto"].Value);
                string Nombre = Convert.ToString(DtgProductos.SelectedRows[0].Cells["Nombre"].Value);

                var confirm = MessageBox.Show($"¿Deseas eliminar el producto: {Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    mp.EliminarProducto(id);
                    mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
                    TxtNombre.Clear();
                    TxtDesc.Clear();
                    TxtPrecio.Clear();
                    TxtNombre.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Elija un producto para eliminar", "Ok", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                TextBox cajaTexto = sender as TextBox;
                if ((e.KeyChar == '.') && (cajaTexto.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            int radioBorde = 5;
            GraphicsPath rutaPanel3 = CrearRutaRedondeada(new Rectangle(0, 0, Pdel.Width, Pdel.Height), radioBorde);
            GraphicsPath rutaPanel4 = CrearRutaRedondeada(new Rectangle(0, 0, PSom.Width, PSom.Height), radioBorde);
            GraphicsPath rutaBoton1 = CrearRutaRedondeada(new Rectangle(0, 0, BtnActualizar.Width, BtnActualizar.Height), radioBorde);
            GraphicsPath rutaBoton2 = CrearRutaRedondeada(new Rectangle(0, 0, BtnAgregar.Width, BtnAgregar.Height), radioBorde);

            Pdel.Region = new Region(rutaPanel3);
            PSom.Region = new Region(rutaPanel4);
            PSom2.Region = new Region(rutaPanel3);
            PSom2.Region = new Region(rutaPanel4);
            BtnActualizar.Region = new Region(rutaBoton1);
            BtnAgregar.Region = new Region(rutaBoton2);
            BtnEliminar.Region = new Region(rutaBoton2);

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
    }
}
