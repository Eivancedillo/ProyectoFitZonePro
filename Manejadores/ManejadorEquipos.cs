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
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // Ocultar columnas internas del sistema
            tabla.Columns["estado"].Visible = false;
            tabla.Columns["created_at"].Visible = false;
            tabla.Columns["updated_at"].Visible = false;

            // Formato visual para el ID (ej. M-0001)
            tabla.Columns["idEquipo"].DefaultCellStyle.Format = "M-0000";

            if (tabla.Rows.Count > 0)
            {
                if (estado) // Equipos Activos
                {
                    tabla.Columns.Insert(6, Boton("Editar", Color.Green));
                    tabla.Columns.Insert(7, Boton("Mantenimiento", Color.Orange));
                    tabla.Columns.Insert(8, Boton("Desactivar", Color.Red));
                }
                else // Equipos Inactivos
                {
                    // Se muestran en gris para indicar que están deshabilitados
                    tabla.Columns.Insert(6, Boton("Editar", Color.LightGray));
                    tabla.Columns.Insert(7, Boton("Mantenimiento", Color.LightGray));
                    tabla.Columns.Insert(8, Boton("Activar", Color.Blue));
                }
            }

            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
            tabla.ClearSelection(); // Evita que el primer registro se resalte por defecto al cargar
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