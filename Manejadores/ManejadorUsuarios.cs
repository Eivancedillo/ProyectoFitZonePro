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
            tabla.RowHeadersVisible = false; // ¡Adiós al fantasma de la flechita!
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAMOS LO QUE HACE BULTO
            if (tabla.Columns.Contains("created_at")) tabla.Columns["created_at"].Visible = false;
            if (tabla.Columns.Contains("updated_at")) tabla.Columns["updated_at"].Visible = false;
            if (tabla.Columns.Contains("curp")) tabla.Columns["curp"].Visible = false;
            if (tabla.Columns.Contains("fecha_nacimiento")) tabla.Columns["fecha_nacimiento"].Visible = false;
            if (tabla.Columns.Contains("fecha_registro")) tabla.Columns["fecha_registro"].Visible = false;

            // 2. MAGIA VISUAL: NOMBRES PROFESIONALES Y FORMATOS
            if (tabla.Columns.Contains("idUsuario"))
            {
                tabla.Columns["idUsuario"].HeaderText = "Folio";
                tabla.Columns["idUsuario"].DefaultCellStyle.Format = "U-0000"; // <-- AQUÍ ESTÁ DE REGRESO TU FORMATO VIP
            }

            if (tabla.Columns.Contains("nombre"))
                tabla.Columns["nombre"].HeaderText = "Nombre Completo";

            if (tabla.Columns.Contains("telefono"))
                tabla.Columns["telefono"].HeaderText = "Teléfono";

            if (tabla.Columns.Contains("email"))
                tabla.Columns["email"].HeaderText = "Correo";

            if (tabla.Columns.Contains("estatus"))
                tabla.Columns["estatus"].HeaderText = "Estado";

            // 3. AGREGAMOS LOS BOTONES
            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                DataGridViewButtonColumn btnEditar = Boton("Editar", Color.Green);
                btnEditar.HeaderText = "Modificar";
                tabla.Columns.Insert(colIndex, btnEditar);

                DataGridViewButtonColumn btnEstado = Boton("Estado", Color.Gray);
                btnEstado.UseColumnTextForButtonValue = false;
                btnEstado.HeaderText = "Acción";
                tabla.Columns.Insert(colIndex + 1, btnEstado);

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

            // 4. TRUCO DE DISEÑO
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Hacemos que la columna de Nombre rellene el espacio que sobre
            if (tabla.Columns.Contains("nombre"))
            {
                tabla.Columns["nombre"].MinimumWidth = 200; // Su salvavidas
                tabla.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            tabla.ClearSelection();
        }

        public bool RegistrarUsuarioConHuella(string nombre, string curp, string tel, string email, string fechaNac, byte[] huella)
        {
            try
            {
                // 1. Insertamos al usuario y obtenemos su ID
                // Nota: Tu método Consultar debe poder recibir los parámetros. 
                // Si tu clase Base es muy simple, tendrás que concatenar (con cuidado) o usar parámetros.
                string queryInsert = $"CALL p_insertUsuarios('{nombre}', '{curp}', '{tel}', '{email}', '{fechaNac}');";
                DataSet ds = b.Consultar(queryInsert, "temp");

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int nuevoId = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);

                    // 2. Ahora guardamos la huella usando el ID obtenido
                    // IMPORTANTE: Para mandar el BLOB (byte[]), tu clase Base necesita un método que acepte parámetros de MySQL
                    // Si no lo tienes, aquí te doy la lógica para ejecutar el procedimiento de la huella:
                    return b.EjecutarProcedimientoHuella(nuevoId, huella);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el manejador al registrar usuario: " + ex.Message);
            }
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