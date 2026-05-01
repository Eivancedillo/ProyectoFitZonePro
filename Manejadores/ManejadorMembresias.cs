using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Manejadores
{
    public class ManejadorMembresias
    {
        private readonly Base b = new Base();

        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.RowHeadersVisible = false;
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAR COLUMNAS INTERNAS
            if (tabla.Columns.Contains("idMembresia")) tabla.Columns["idMembresia"].Visible = false;
            if (tabla.Columns.Contains("beneficios")) tabla.Columns["beneficios"].Visible = false;
            if (tabla.Columns.Contains("estatus")) tabla.Columns["estatus"].HeaderText = "Estado";

            // 2. RENOMBRAR COLUMNAS PARA QUE SE VEAN PRO
            if (tabla.Columns.Contains("nombre")) tabla.Columns["nombre"].HeaderText = "Membresía";
            if (tabla.Columns.Contains("costo_mensual"))
            {
                tabla.Columns["costo_mensual"].HeaderText = "Mensualidad";
                tabla.Columns["costo_mensual"].DefaultCellStyle.Format = "C2";
            }
            if (tabla.Columns.Contains("costo_semestral"))
            {
                tabla.Columns["costo_semestral"].HeaderText = "Semestral";
                tabla.Columns["costo_semestral"].DefaultCellStyle.Format = "C2";
            }
            if (tabla.Columns.Contains("costo_anual"))
            {
                tabla.Columns["costo_anual"].HeaderText = "Anualidad";
                tabla.Columns["costo_anual"].DefaultCellStyle.Format = "C2";
            }

            // 3. AGREGAR BOTONES CON ESTILO PLANO (FIGMA)
            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                // Botón Editar
                DataGridViewButtonColumn btnEditar = Boton("Editar", Color.FromArgb(108, 169, 129)); // Verde FitZone
                btnEditar.HeaderText = "Modificar";
                btnEditar.FlatStyle = FlatStyle.Flat;
                // El truco: Color de selección igual al color de fondo del botón
                btnEditar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(108, 169, 129);
                btnEditar.DefaultCellStyle.SelectionForeColor = Color.White;
                tabla.Columns.Insert(colIndex, btnEditar);

                // Botón Estado
                DataGridViewButtonColumn btnEstado = Boton("Desactivar", Color.FromArgb(235, 110, 110)); // Rojo suave
                btnEstado.HeaderText = "Acción";
                btnEstado.FlatStyle = FlatStyle.Flat;
                btnEstado.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 110, 110);
                btnEstado.DefaultCellStyle.SelectionForeColor = Color.White;
                tabla.Columns.Insert(colIndex + 1, btnEstado);

                // Ajustar texto dinámico según el estatus
                foreach (DataGridViewRow fila in tabla.Rows)
                {
                    if (fila.Cells["estatus"].Value.ToString() == "Inactivo")
                    {
                        fila.Cells[colIndex + 1].Value = "Activar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.FromArgb(70, 130, 180); // Azul acero para activar
                        fila.Cells[colIndex + 1].Style.SelectionBackColor = Color.FromArgb(70, 130, 180);
                    }
                }
            }
        }

        public List<int> ObtenerBeneficiosPorMembresia(int idMembresia)
        {
            List<int> listaIds = new List<int>();
            // Consultamos la tabla intermedia usando el nombre real que me pasaste
            DataTable dt = b.Consultar($"SELECT fkIdBeneficio FROM tbl_beneficiosMembresias WHERE fkIdMembresia = {idMembresia}", "BeneficiosRel").Tables[0];

            foreach (DataRow fila in dt.Rows)
            {
                listaIds.Add(Convert.ToInt32(fila["fkIdBeneficio"]));
            }
            return listaIds;
        }

        // --- MAGIA DEL TOP 3 (Usando tu nueva Vista) ---
        public DataTable ObtenerTop3()
        {
            // MAGIA SQL: Traemos los mismos datos, pero los cruzamos con las suscripciones reales,
            // contamos cuántas tiene cada una (COUNT) y las ordenamos de la que más tiene a la que menos (DESC).
            string query = @"
                SELECT m.nombre, m.costo_mensual, m.costo_semestral, m.costo_anual, m.beneficios
                FROM v_vista_membresias_beneficios m
                LEFT JOIN tbl_suscripcionesSocios s ON m.idMembresia = s.fkIdMembresia
                WHERE m.estatus = 'Activo'
                GROUP BY m.idMembresia, m.nombre, m.costo_mensual, m.costo_semestral, m.costo_anual, m.beneficios
                ORDER BY COUNT(s.fkIdMembresia) DESC
                LIMIT 3";

            return b.Consultar(query, "TopMembresias").Tables[0];
        }

        // --- CRUDS ACTUALIZADOS ---
        public int CrearMembresia(Membresias m)
        {
            // Usamos Consultar para atrapar el LAST_INSERT_ID() devuelto por tu MySQL
            DataTable dt = b.Consultar($"call p_insertMembresias('{m.Nombre}', {m.CostoMensual}, {m.CostoSemestral}, {m.CostoAnual})", "NuevoID").Tables[0];
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void EditarMembresia(Membresias m)
        {
            b.Comando($"call p_updateMembresias({m.IdMembresia}, '{m.Nombre}', {m.CostoMensual}, {m.CostoSemestral}, {m.CostoAnual})");
        }

        // --- MÉTODO PARA LA RELACIÓN N A N ---
        public void VincularBeneficios(int idMembresia, System.Collections.Generic.List<int> beneficiosIds)
        {
            // 1. Borramos los anteriores (así la edición es súper fácil: borrón y cuenta nueva)
            b.Comando($"call p_deleteMembresiaBeneficios({idMembresia})");

            // 2. Insertamos los que estén en la lista temporal de la memoria
            foreach (int idBeneficio in beneficiosIds)
            {
                b.Comando($"call p_insertMembresiaBeneficio({idMembresia}, {idBeneficio})");
            }
        }

        public void CambiarEstado(int idMembresia, bool estado)
        {
            DialogResult rs = MessageBox.Show("¿Está seguro que desea cambiar el estatus?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (estado) b.Comando($"call p_deleteMembresias({idMembresia})"); // Pasa a Inactivo
                else b.Comando($"call p_activarMembresias({idMembresia})"); // Pasa a Activo
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

        public void AplicarEstiloFigma(DataGridView tabla)
        {
            Color colorFondo = Color.White;
            Color colorLineas = Color.FromArgb(235, 235, 235);
            Color colorTextoCabecera = Color.FromArgb(120, 120, 120);

            tabla.BackgroundColor = colorFondo;
            tabla.BorderStyle = BorderStyle.None;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            tabla.GridColor = colorLineas;
            tabla.EnableHeadersVisualStyles = false;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.MultiSelect = false;

            // Estilo Cabecera
            tabla.ColumnHeadersDefaultCellStyle.BackColor = colorFondo;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = colorTextoCabecera;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorFondo; // IMPORTANTE: evita el blanco al clickear cabecera
            tabla.ColumnHeadersHeight = 45;

            // Estilo Filas
            tabla.DefaultCellStyle.BackColor = colorFondo;
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 248); // Gris casi blanco para la fila seleccionada
            tabla.DefaultCellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);
            tabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabla.RowTemplate.Height = 45;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tabla.ClearSelection();
        }
    }
}