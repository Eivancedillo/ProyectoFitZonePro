using AccesoDatos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorUsuarios
    {
        private readonly Base b = new Base();

        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // Ocultamos las columnas internas (verifica que el nombre coincida con tu BD)
            if (tabla.Columns.Contains("estado")) tabla.Columns["estado"].Visible = false;
            if (tabla.Columns.Contains("created_at")) tabla.Columns["created_at"].Visible = false;
            if (tabla.Columns.Contains("updated_at")) tabla.Columns["updated_at"].Visible = false;

            // Formato pro para el ID
            if (tabla.Columns.Contains("idUsuario")) tabla.Columns["idUsuario"].DefaultCellStyle.Format = "U-0000";

            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                // 1. Botón Editar
                tabla.Columns.Insert(colIndex, Boton("Editar", Color.Green));

                // 2. Botón Estado (dinámico)
                DataGridViewButtonColumn btnEstado = Boton("Estado", Color.Gray);
                btnEstado.UseColumnTextForButtonValue = false; // Permite texto diferente por fila
                tabla.Columns.Insert(colIndex + 1, btnEstado);

                // Recorremos para poner "Activar" o "Desactivar" según el caso
                foreach (DataGridViewRow fila in tabla.Rows)
                {
                    if (fila.Cells["estatus"].Value != null && fila.Cells["estatus"].Value.ToString() == "Activo")
                    {
                        fila.Cells[colIndex + 1].Value = "Desactivar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        fila.Cells[colIndex + 1].Value = "Activar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Blue;
                    }
                }
            }

            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tabla.ClearSelection();
        }

        public void CrearUsuario(Usuarios u)
        {
            b.Comando($"call p_insertUsuarios('{u.Nombre}', '{u.CURP}', '{u.Telefono}', '{u.Email}', '{u.FechaNacimiento}')");
        }

        public void EditarUsuario(Usuarios u)
        {
            b.Comando($"call p_updateUsuarios({u.IdUsuario}, '{u.Nombre}', '{u.CURP}', '{u.Telefono}', '{u.Email}', '{u.FechaNacimiento}')");
        }

        public void CambiarEstado(int idUsuario, bool estado)
        {
            DialogResult rs = MessageBox.Show("¿Está seguro que desea cambiar el estatus de este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (estado)
                    b.Comando($"call p_deleteUsuarios({idUsuario})"); // Lo pasa a Inactivo
                else
                    b.Comando($"call p_activarUsuarios({idUsuario})"); // Lo pasa a Activo
            }
        }

        private static DataGridViewButtonColumn Boton(string titulo, Color fondo)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Text = titulo,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup
            };
            btn.DefaultCellStyle.BackColor = fondo;
            btn.DefaultCellStyle.ForeColor = Color.Black;
            return btn;
        }
    }
}