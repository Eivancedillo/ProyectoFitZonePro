using AccesoDatos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorEquipos
    {
        // Instancia de solo lectura para mayor seguridad y optimización de memoria
        private readonly Base b = new Base();

        // Configura y llena el DataGridView con los datos y botones correspondientes
        public void Mostrar(string consulta, DataGridView tabla, string dato, bool estado)
        {
            tabla.Columns.Clear();
            tabla.RowHeadersVisible = false; // ¡Exorcismo al fantasma!
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAMOS COLUMNAS INTERNAS
            if (tabla.Columns.Contains("estado")) tabla.Columns["estado"].Visible = false;
            if (tabla.Columns.Contains("created_at")) tabla.Columns["created_at"].Visible = false;
            if (tabla.Columns.Contains("updated_at")) tabla.Columns["updated_at"].Visible = false;

            // 2. MAGIA VISUAL: NOMBRES PROFESIONALES Y FORMATOS
            if (tabla.Columns.Contains("idEquipo"))
            {
                tabla.Columns["idEquipo"].HeaderText = "Folio";
                tabla.Columns["idEquipo"].DefaultCellStyle.Format = "M-0000";
            }

            if (tabla.Columns.Contains("nombre_maquina"))
                tabla.Columns["nombre_maquina"].HeaderText = "Equipo";

            if (tabla.Columns.Contains("categoria"))
                tabla.Columns["categoria"].HeaderText = "Categoría";

            if (tabla.Columns.Contains("fecha_adquisicion"))
                tabla.Columns["fecha_adquisicion"].HeaderText = "Adquisición";

            if (tabla.Columns.Contains("ultimo_mantenimiento"))
                tabla.Columns["ultimo_mantenimiento"].HeaderText = "Último Mantenimiento";

            if (tabla.Columns.Contains("mantenimiento_programado"))
                tabla.Columns["mantenimiento_programado"].HeaderText = "Próx. Mantenimiento";

            // 3. AGREGAMOS LOS BOTONES DE FORMA DINÁMICA
            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count; // Siempre los pone al final, sin importar cuántas columnas haya

                // Botón Editar
                DataGridViewButtonColumn btnEditar = Boton("Editar", estado ? Color.Green : Color.LightGray);
                btnEditar.HeaderText = "Modificar";
                tabla.Columns.Insert(colIndex, btnEditar);

                // Botón Mantenimiento
                DataGridViewButtonColumn btnMantenimiento = Boton("Mantenimiento", estado ? Color.Orange : Color.LightGray);
                btnMantenimiento.HeaderText = "Servicio";
                tabla.Columns.Insert(colIndex + 1, btnMantenimiento);

                // Botón Estado (Desactivar/Activar)
                DataGridViewButtonColumn btnEstado = Boton(estado ? "Desactivar" : "Activar", estado ? Color.Red : Color.Blue);
                btnEstado.HeaderText = "Acción";
                tabla.Columns.Insert(colIndex + 2, btnEstado);
            }

            // 4. TRUCO DE DISEÑO ANTI-SCROLL
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Hacemos que la columna del Equipo rellene todo el espacio gris vacío
            if (tabla.Columns.Contains("nombre_maquina"))
            {
                tabla.Columns["nombre_maquina"].MinimumWidth = 150; // Salvavidas
                tabla.Columns["nombre_maquina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            tabla.ClearSelection();
        }

        // --- MÉTODOS CRUD DE EQUIPOS ---

        public void CrearEquipo(Equipos equipo)
        {
            b.Comando($"call p_insertEquipos('{equipo.Nombre}', '{equipo.Categoria}', '{equipo.FechaAdquisicion}')");
        }

        public void EditarEquipo(Equipos equipo)
        {
            b.Comando($"call p_updateEquipos({equipo.IdEquipo}, '{equipo.Nombre}', '{equipo.Categoria}', '{equipo.FechaAdquisicion}')");
        }

        public void CambiarEstado(int idEquipo, bool estado)
        {
            DialogResult rs = MessageBox.Show("¿Está seguro que desea cambiar el estado de este equipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                if (estado)
                    b.Comando($"call p_deleteEquipos({idEquipo})");
                else
                    b.Comando($"call p_activarEquipos({idEquipo})");
            }
        }

        // --- MÉTODOS DE MANTENIMIENTO ---

        // Verifica si existe un mantenimiento programado sin finalizar
        public DataTable ObtenerMantenimientoPendiente(int idEquipo)
        {
            string query = $"SELECT idMantenimiento, fecha_mantenimiento FROM tbl_mantenimientoEquipos WHERE fkIdEquipo = {idEquipo} AND estado = 'Pendiente' ORDER BY idMantenimiento DESC LIMIT 1";
            return b.Consultar(query, "Mantenimiento").Tables[0];
        }

        public void CrearMantenimiento(int idEquipo, string fecha)
        {
            b.Comando($"call p_insertMantenimiento({idEquipo}, '{fecha}', '')");
        }

        // Finaliza el mantenimiento registrando la fecha y hora exacta del sistema
        public void FinalizarMantenimiento(int idMantenimiento)
        {
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            b.Comando($"call p_updateMantenimiento({idMantenimiento}, '{fechaActual}')");
        }

        // --- MÉTODOS AUXILIARES ---

        // Genera columnas de botones con estilo personalizado para el DataGridView
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