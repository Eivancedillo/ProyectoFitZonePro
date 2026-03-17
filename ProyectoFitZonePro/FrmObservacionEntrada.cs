using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace ProyectoFitZonePro
{
    public partial class FrmObservacionEntrada : Form
    {
        ManejadorInventarios mi;
        Entradas entradas = new Entradas(0,"","");
        DetalleEntrada detalle = new DetalleEntrada();
        public FrmObservacionEntrada()
        {
            InitializeComponent();
            mi = new ManejadorInventarios();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmEntradasInventario.de.Clear();
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtObservacion.Text))
            {
                MessageBox.Show("¡No puedes guardar sin una observación! Escribe una descripción válida.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtObservacion.Focus();
                return; 
            }
            try
            {
                // Si llegó hasta aquí, es porque la validación pasó con éxito
                mi.GuardarEntrada(new Entradas(0, "", TxtObservacion.Text));

                foreach (var item in FrmEntradasInventario.de)
                {
                    mi.GuardarDetalleEntrada(new DetalleEntrada(0, 0, item.FkIdProduto, item.Cantidad, item.Precio_Unitario));
                }

                MessageBox.Show("Entrada Guardada Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                FrmEntradasInventario.de.Clear();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar en la base de datos:\n\n{ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
