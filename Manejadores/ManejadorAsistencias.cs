using AccesoDatos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorAsistencias
    {
        private Base b = new Base();

        // Muestra la tabla filtrada por el día de hoy
        public void Mostrar(string consulta, DataGridView tabla, string dato)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consultar(consulta, dato).Tables[0];

            // Ocultamos el ID y la columna interna de FechaCorte
            if (tabla.Columns.Contains("idAsistencia")) tabla.Columns["idAsistencia"].Visible = false;
            if (tabla.Columns.Contains("FechaCorte")) tabla.Columns["FechaCorte"].Visible = false;

            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.ClearSelection();
        }

        // --- LA MAGIA DEL ESCÁNER ---
        public string[] ProcesarAcceso(string idEscaneado)
        {
            // 1. Limpiamos lo que escribió (Si escribió "S-0015", nos quedamos solo con "15")
            string idLimpio = Regex.Replace(idEscaneado, "[^0-9]", "");
            if (string.IsNullOrEmpty(idLimpio)) return new string[] { "ERROR", "Por favor ingrese un ID válido." };

            // 2. Buscamos esa suscripción usando la vista que ya teníamos de socios
            string querySuscripcion = $"SELECT fkIdUsuario, Cliente, Paquete, fecha_fin, estado FROM v_vista_suscripciones WHERE idSuscripcion = {idLimpio}";
            DataTable dtSocio = b.Consultar(querySuscripcion, "InfoSocio").Tables[0];

            if (dtSocio.Rows.Count == 0)
            {
                return new string[] { "ERROR", "Suscripción no encontrada. Verifique el número." };
            }

            DataRow fila = dtSocio.Rows[0];
            string estado = fila["estado"].ToString().ToLower();
            string nombre = fila["Cliente"].ToString();
            string paquete = fila["Paquete"].ToString();
            string vigencia = Convert.ToDateTime(fila["fecha_fin"]).ToString("dd/MMM/yyyy");

            // 3. Verificamos si está activo
            if (estado != "activo")
            {
                return new string[] { "DENEGADO", $"¡Membresía {estado.ToUpper()}! No puede pasar.", nombre, paquete, vigencia };
            }

            // 4. Si está activo, llamamos al procedure inteligente para marcar entrada/salida
            int idUsuario = Convert.ToInt32(fila["fkIdUsuario"]);
            DataTable dtAsistencia = b.Consultar($"call p_registrarAsistencia({idUsuario})", "Registro").Tables[0];

            string mensajeDB = dtAsistencia.Rows[0]["Mensaje"].ToString();
            string tipoRegistro = dtAsistencia.Rows[0]["TipoRegistro"].ToString(); // ENTRADA o SALIDA

            // Devolvemos el arreglo con todos los datos para que el Formulario los pinte
            return new string[] { tipoRegistro, mensajeDB, nombre, paquete, vigencia };
        }
    }
}