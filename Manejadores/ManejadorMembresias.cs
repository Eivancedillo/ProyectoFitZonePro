using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorMembresias
    {
        private readonly Base b = new Base();

        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // Ocultamos columnas internas
            if (tabla.Columns.Contains("estatus")) tabla.Columns["estatus"].Visible = false;
            if (tabla.Columns.Contains("created_at")) tabla.Columns["created_at"].Visible = false;
            if (tabla.Columns.Contains("updated_at")) tabla.Columns["updated_at"].Visible = false;
            if (tabla.Columns.Contains("idMembresia")) tabla.Columns["idMembresia"].Visible = false;

            if (tabla.Columns.Contains("idMembresia")) tabla.Columns["idMembresia"].DefaultCellStyle.Format = "MEM-00";

            if (tabla.Rows.Count > 0)
            {
                int colIndex = tabla.Columns.Count;

                tabla.Columns.Insert(colIndex, Boton("Editar", Color.Green));

                DataGridViewButtonColumn btnEstado = Boton("Estado", Color.Gray);
                btnEstado.UseColumnTextForButtonValue = false;
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
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabla.ClearSelection();
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
            string query = "SELECT nombre, costo_mensual, costo_semestral, costo_anual, beneficios FROM v_vista_membresias_beneficios WHERE estatus = 'Activo' ORDER BY idMembresia DESC LIMIT 3";
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
    }
}