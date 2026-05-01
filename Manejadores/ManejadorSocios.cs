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
            tabla.RowHeadersVisible = false; // <-- ESTA ES LA LÍNEA MÁGICA
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAMOS COLUMNAS INTERNAS
            if (tabla.Columns.Contains("fkIdUsuario")) tabla.Columns["fkIdUsuario"].Visible = false;
            if (tabla.Columns.Contains("fkIdMembresia")) tabla.Columns["fkIdMembresia"].Visible = false;

            // 2. FORMATOS PRO (Rescatados de tu código original)
            if (tabla.Columns.Contains("idSuscripcion"))
            {
                tabla.Columns["idSuscripcion"].HeaderText = "Folio";
                tabla.Columns["idSuscripcion"].DefaultCellStyle.Format = "S-0000";
            }
            if (tabla.Columns.Contains("costo_total"))
            {
                tabla.Columns["costo_total"].HeaderText = "Total";
                tabla.Columns["costo_total"].DefaultCellStyle.Format = "C2"; // Formato moneda
            }

            // 3. MAGIA VISUAL: NOMBRES PROFESIONALES Y CORTOS
            if (tabla.Columns.Contains("Cliente"))
                tabla.Columns["Cliente"].HeaderText = "Socio";

            if (tabla.Columns.Contains("Paquete"))
                tabla.Columns["Paquete"].HeaderText = "Membresía";

            if (tabla.Columns.Contains("Duracion"))
                tabla.Columns["Duracion"].HeaderText = "Periodo";

            if (tabla.Columns.Contains("fecha_inicio"))
                tabla.Columns["fecha_inicio"].HeaderText = "Inicio";

            if (tabla.Columns.Contains("fecha_fin"))
                tabla.Columns["fecha_fin"].HeaderText = "Vencimiento";

            if (tabla.Columns.Contains("estado"))
                tabla.Columns["estado"].HeaderText = "Estatus";

            // 4. AGREGAMOS LOS BOTONES
            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                // Botón Editar
                DataGridViewButtonColumn btnEditar = Boton("Editar", Color.Orange);
                btnEditar.HeaderText = "Modificar";
                tabla.Columns.Insert(colIndex, btnEditar);

                // Botón Estado
                DataGridViewButtonColumn btnEstado = Boton("Estado", Color.Gray);
                btnEstado.UseColumnTextForButtonValue = false;
                btnEstado.HeaderText = "Acción";
                tabla.Columns.Insert(colIndex + 1, btnEstado);

                foreach (DataGridViewRow fila in tabla.Rows)
                {
                    // Lógica original de 3 estados
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

            // 5. TRUCO DE DISEÑO ANTI-SCROLL
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Hacemos que la columna del Socio rellene el espacio vacío, PERO sin desaparecer
            if (tabla.Columns.Contains("Cliente"))
            {
                tabla.Columns["Cliente"].MinimumWidth = 150; // <-- EL SALVAVIDAS (Mínimo 150 píxeles)
                tabla.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

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