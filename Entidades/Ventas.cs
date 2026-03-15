using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        public Ventas(int idVenta, int fkIdUsuario, string fecha_venta, string metodo_pago)
        {
            IdVenta = idVenta;
            FkIdUsuario = fkIdUsuario;
            Fecha_venta = fecha_venta;
            Metodo_pago = metodo_pago;
        }

        public int IdVenta { get; set; }
        public int FkIdUsuario { get; set; }
        public string Fecha_venta { get; set; }
        public string Metodo_pago { get; set; }
    }
}
