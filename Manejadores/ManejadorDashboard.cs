using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorDashboard
    {
        private Base b = new Base();

        public int ConsultarMiembrosTotales()
        {
            // Solo pedimos el valor de la vista
            return b.ConsultarEscalarInt("SELECT Valor FROM v_kpi_miembros_totales;");
        }

        public int ConsultarActivosHoy()
        {
            return b.ConsultarEscalarInt("SELECT Valor FROM v_kpi_activos_hoy;");
        }

        public decimal ConsultarVentasSemana()
        {
            return b.ConsultarEscalarDecimal("SELECT Valor FROM v_kpi_ventas_semana;");
        }

        public DataTable ConsultarEntradasSalidasRecientes()
        {
            string query = "SELECT Mensaje, TipoMovimiento FROM v_dashboard_entradas_salidas;";
            return b.Consultar(query, "recientes").Tables[0];
        }
    }
}