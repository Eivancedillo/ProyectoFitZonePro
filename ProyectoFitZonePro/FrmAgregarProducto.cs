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
        ManejadorProductos mp;
        public FrmAgregarProducto()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            mp.InsertarProducto(new Productos(0, TxtNombre.Text, TxtDesc.Text, Convert.ToDouble(TxtPrecio.Text)));
            mp.VerProductos("select * from v_productos", DtgProductos, "tbl_productos");
            TxtNombre.Clear();
            TxtDesc.Clear();
            TxtPrecio.Clear();
            TxtNombre.Focus();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
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
    }
}
