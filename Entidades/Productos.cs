using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public Productos(int idProducto, string nombreProducto, string descripcion, double precioVenta)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
        }
    }
}
