using AccesoDatos;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic; // Para usar el Diccionario
using DPFP;

namespace Manejadores
{
    public class ManejadorAsistencias
    {
        private Base b = new Base();

        // Muestra la tabla filtrada por el día de hoy
        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.RowHeadersVisible = false; // ¡Exorcismo aplicado al fantasma de la izquierda!
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // 1. OCULTAMOS COLUMNAS INTERNAS (Si es que traes IDs ocultos en tu consulta)
            if (tabla.Columns.Contains("idAsistencia")) tabla.Columns["idAsistencia"].Visible = false;
            if (tabla.Columns.Contains("fkIdUsuario")) tabla.Columns["fkIdUsuario"].Visible = false;

            // 2. MAGIA VISUAL: NOMBRES PROFESIONALES
            if (tabla.Columns.Contains("Cliente"))
                tabla.Columns["Cliente"].HeaderText = "Socio";

            if (tabla.Columns.Contains("Entrada"))
                tabla.Columns["Entrada"].HeaderText = "Hora de Entrada";

            if (tabla.Columns.Contains("Salida"))
                tabla.Columns["Salida"].HeaderText = "Hora de Salida";

            // 3. ARREGLO DEL TEXTO ROTO ("A??n en el gym") Y DISEÑO PRO
            foreach (DataGridViewRow fila in tabla.Rows)
            {
                if (fila.Cells["Salida"].Value != null)
                {
                    string salidaStr = fila.Cells["Salida"].Value.ToString();

                    // Si detectamos el texto roto, el texto con acento, o si viene vacío
                    if (salidaStr.Contains("A??n") || salidaStr.Contains("Aún") || string.IsNullOrWhiteSpace(salidaStr))
                    {
                        // Lo cambiamos por algo súper limpio y le damos estilo
                        fila.Cells["Salida"].Value = "Entrenando...";
                        fila.Cells["Salida"].Style.ForeColor = Color.Green;
                        fila.Cells["Salida"].Style.Font = new Font(tabla.Font, FontStyle.Bold);
                    }
                }
            }

            // 4. TRUCO DE DISEÑO ANTI-SCROLL Y AJUSTE PERFECTO
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Hacemos que la columna del Socio rellene todo el espacio gris feo que sobraba
            if (tabla.Columns.Contains("Cliente"))
            {
                tabla.Columns["Cliente"].MinimumWidth = 200; // Su salvavidas para que no desaparezca
                tabla.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            tabla.ClearSelection();
        }

        public Dictionary<int, DPFP.Template> ObtenerHuellasBD()
        {
            Dictionary<int, DPFP.Template> diccionarioHuellas = new Dictionary<int, DPFP.Template>();
            try
            {
                // Llamamos al procedure que me pasaste antes
                DataTable dtHuellas = b.Consultar("CALL p_obtenerHuellasActivas();", "Huellas").Tables[0];

                foreach (DataRow fila in dtHuellas.Rows)
                {
                    if (fila["huella_dactilar"] != DBNull.Value)
                    {
                        int idUsuario = Convert.ToInt32(fila["idUsuario"]);
                        byte[] huellaBytes = (byte[])fila["huella_dactilar"];

                        // Convertimos el BLOB de bytes a una Plantilla que el sensor entienda
                        DPFP.Template plantilla = new DPFP.Template();
                        plantilla.DeSerialize(huellaBytes);

                        diccionarioHuellas.Add(idUsuario, plantilla);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las huellas: " + ex.Message);
            }
            return diccionarioHuellas;
        }

        public string[] ProcesarAcceso(int idUsuario)
        {
            // Buscamos la suscripción ACTIVA de este usuario específico
            string query = $"SELECT fkIdUsuario, Cliente, Paquete, fecha_fin, estado FROM v_vista_suscripciones WHERE fkIdUsuario = {idUsuario} AND estado = 'activo' ORDER BY idSuscripcion DESC LIMIT 1";
            DataTable dtSocio = b.Consultar(query, "InfoSocio").Tables[0];

            if (dtSocio.Rows.Count == 0)
            {
                return new string[] { "DENEGADO", "El usuario de esta huella no tiene ninguna membresía activa." };
            }

            DataRow fila = dtSocio.Rows[0];
            string nombre = fila["Cliente"].ToString();
            string paquete = fila["Paquete"].ToString();
            string vigencia = Convert.ToDateTime(fila["fecha_fin"]).ToString("dd/MMM/yyyy");

            // Si está activo, llamamos al procedure para marcar entrada/salida
            DataTable dtAsistencia = b.Consultar($"call p_registrarAsistencia({idUsuario})", "Registro").Tables[0];

            string mensajeDB = dtAsistencia.Rows[0]["Mensaje"].ToString();
            string tipoRegistro = dtAsistencia.Rows[0]["TipoRegistro"].ToString();

            return new string[] { tipoRegistro, mensajeDB, nombre, paquete, vigencia };
        }
    }
}