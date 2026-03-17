using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
