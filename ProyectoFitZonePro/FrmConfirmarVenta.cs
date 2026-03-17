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
    public partial class FrmConfirmarVenta : Form
    {
        ManejadorVentas mp;
        Ventas venta = new Ventas(0,0,"","");
        public FrmConfirmarVenta()
        {
            InitializeComponent();
            mp = new ManejadorVentas();
            mp.LlenarUsarios(CmbSocios);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (CmbSocios.SelectedIndex == -1 || CmbSocios.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un socio válido para continuar con la venta.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbSocios.Focus();
                return;
            }

            if (CmbMetodoPago.SelectedIndex == -1 || string.IsNullOrWhiteSpace(CmbMetodoPago.Text))
            {
                MessageBox.Show("Por favor, seleccione un método de pago antes de registrar la transacción.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbMetodoPago.Focus();
                return;
            }

            try
            {
                mp.GuardarVenta(new Ventas(0, Convert.ToInt32(CmbSocios.SelectedValue), "", CmbMetodoPago.SelectedItem.ToString()));

                foreach (var item in FrmRealizarVenta.carrito)
                {
                    mp.GuardarDetalleVenta(item.FkIdProducto, item.Cantidad, item.Precio);
                }

                MessageBox.Show("La venta se ha registrado exitosamente en el sistema.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                FrmRealizarVenta.carrito.Clear();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado al intentar procesar la transacción.\n\nDetalles técnicos para soporte: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmRealizarVenta.carrito.Clear();
            Close();
        }
    }
}
