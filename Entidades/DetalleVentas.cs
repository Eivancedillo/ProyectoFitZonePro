using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentas
    {
        public int IdDetalleVenta { get; set; }
        public int FkIdVenta { get; set; }
        public int FkIdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public DetalleVentas()
        {
            
        }
        public DetalleVentas(int idDetalleVenta, int fkIdVenta, int fkIdProducto, int cantidad, double precio)
        {
            IdDetalleVenta = idDetalleVenta;
            FkIdVenta = fkIdVenta;
            FkIdProducto = fkIdProducto;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
