using AccesoDatos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorTrabajadores
    {
        private Base b = new Base();

        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.RowHeadersVisible = false; // ¡Adiós fantasma!
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAR COLUMNAS INTERNAS
            if (tabla.Columns.Contains("clave")) tabla.Columns["clave"].Visible = false;
            if (tabla.Columns.Contains("created_at")) tabla.Columns["created_at"].Visible = false;
            if (tabla.Columns.Contains("updated_at")) tabla.Columns["updated_at"].Visible = false;

            // 2. MAGIA VISUAL: NOMBRES Y FORMATOS
            if (tabla.Columns.Contains("idTrabajador"))
            {
                tabla.Columns["idTrabajador"].HeaderText = "Folio";
                tabla.Columns["idTrabajador"].DefaultCellStyle.Format = "T-0000"; // Formato pro (T-0001)
            }

            if (tabla.Columns.Contains("nombre"))
                tabla.Columns["nombre"].HeaderText = "Trabajador";

            if (tabla.Columns.Contains("telefono"))
                tabla.Columns["telefono"].HeaderText = "Teléfono";

            if (tabla.Columns.Contains("email"))
                tabla.Columns["email"].HeaderText = "Correo";

            if (tabla.Columns.Contains("estatus"))
                tabla.Columns["estatus"].HeaderText = "Estatus";

            // 3. BOTONES DINÁMICOS Y CON TÍTULO
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
                    string estatusFila = fila.Cells["estatus"].Value?.ToString().ToLower() ?? "";

                    if (estatusFila == "activo")
                    {
                        fila.Cells[colIndex + 1].Value = "Desactivar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        fila.Cells[colIndex + 1].Value = "Activar";
                        fila.Cells[colIndex + 1].Style.BackColor = Color.Green;
                    }
                }
            }

            // 4. TRUCO ANTI-SCROLL Y AJUSTE PERFECTO
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Solo la columna del trabajador se estirará para rellenar los huecos
            if (tabla.Columns.Contains("nombre"))
            {
                tabla.Columns["nombre"].MinimumWidth = 150;
                tabla.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            tabla.ClearSelection();
        }

        // --- CRUDS ---
        // Hacemos que devuelva el ID para poder guardarle sus permisos después
        public int CrearTrabajador(Trabajadores t)
        {
            b.Comando($"call p_insertTrabajadores('{t.Nombre}', '{t.Clave}', '{t.Telefono}', '{t.Email}')");
            // Recuperamos el ID recién creado
            DataTable dt = b.Consultar("SELECT LAST_INSERT_ID()", "ID").Tables[0];
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void CambiarEstado(int idTrabajador, string nuevoEstado)
        {
            b.Comando($"UPDATE tbl_trabajadores SET estatus = '{nuevoEstado}' WHERE idTrabajador = {idTrabajador}");
        }

        // Actualiza los datos personales
        public void EditarTrabajador(Trabajadores t)
        {
            b.Comando($"call p_updateTrabajadores({t.IdTrabajador}, '{t.Nombre}', '{t.Clave}', '{t.Telefono}', '{t.Email}')");
        }

        // Trae los permisos guardados en la base de datos
        public DataTable ObtenerPermisos(int idTrabajador)
        {
            return b.Consultar($"SELECT modulo, p_ver, p_crear, p_editar, p_eliminar FROM tbl_permisos_trabajadores WHERE fkIdTrabajador = {idTrabajador}", "Permisos").Tables[0];
        }

        // Guarda un permiso individual
        public void GuardarPermisos(int idTrabajador, string modulo, bool ver, bool crear, bool editar, bool eliminar)
        {
            int v = ver ? 1 : 0;
            int c = crear ? 1 : 0;
            int ed = editar ? 1 : 0;
            int el = eliminar ? 1 : 0;
            b.Comando($"call p_guardarPermiso({idTrabajador}, '{modulo}', {v}, {c}, {ed}, {el})");
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