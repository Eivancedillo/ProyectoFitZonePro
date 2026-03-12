using AccesoDatos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSocios
    {
        private Base b = new Base();

        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // Ocultamos columnas internas o IDs crudos si los trajimos
            if (tabla.Columns.Contains("fkIdUsuario")) tabla.Columns["fkIdUsuario"].Visible = false;
            if (tabla.Columns.Contains("fkIdMembresia")) tabla.Columns["fkIdMembresia"].Visible = false;

            // Formato pro para el ID del Socio
            if (tabla.Columns.Contains("idSuscripcion")) tabla.Columns["idSuscripcion"].DefaultCellStyle.Format = "S-0000";
            if (tabla.Columns.Contains("costo_total")) tabla.Columns["costo_total"].DefaultCellStyle.Format = "C2"; // Formato moneda

            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                tabla.Columns.Insert(colIndex, Boton("Editar", Color.Orange));

                DataGridViewButtonColumn btnEstado = Boton("Estado", Color.Gray);
                btnEstado.UseColumnTextForButtonValue = false;
                tabla.Columns.Insert(colIndex + 1, btnEstado);

                foreach (DataGridViewRow fila in tabla.Rows)
                {
                    // Le agregamos .ToLower() para asegurar que siempre esté en minúsculas
                    string estadoSocio = fila.Cells["estado"].Value?.ToString().ToLower() ?? "";

                    if (estadoSocio == "activo")
                    {
                        fila.Cells[colIndex + 1].Value = "Cancelar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Red;
                    }
                    else if (estadoSocio == "vencido")
                    {
                        fila.Cells[colIndex + 1].Value = "Renovar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Green;
                    }
                    else // cancelado
                    {
                        fila.Cells[colIndex + 1].Value = "Reactivar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Blue;
                    }
                }
            }
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabla.ClearSelection();
        }

        // --- CRUDS ACTUALIZADOS ---
        public void CrearSocio(Socios s)
        {
            // Fíjate que ya solo mandamos 5 parámetros, justo como lo pide tu p_insertSuscripcion
            b.Comando($"call p_insertSuscripcion({s.FkIdUsuario}, {s.FkIdMembresia}, '{s.Duracion}', '{s.FechaFin}', {s.CostoTotal})");
        }

        public void EditarSocio(Socios s)
        {
            // Tu p_updateSuscripcion no pide el id del Usuario, así que lo quitamos de aquí
            b.Comando($"call p_updateSuscripcion({s.IdSuscripcion}, {s.FkIdMembresia}, '{s.Duracion}', '{s.FechaFin}', {s.CostoTotal})");
        }

        public void CambiarEstado(int idSuscripcion, string nuevoEstado)
        {
            if (nuevoEstado == "cancelado")
            {
                // Usamos tu procedure corregido
                b.Comando($"call p_deleteSuscripcion({idSuscripcion})");
            }
            else
            {
                // Para reactivar
                b.Comando($"UPDATE tbl_suscripcionesSocios SET estado = '{nuevoEstado}' WHERE idSuscripcion = {idSuscripcion}");
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