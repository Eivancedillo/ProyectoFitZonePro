using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entradas
    {
        public Entradas(int idEntradas, string fecha, string observacion)
        {
            IdEntradas = idEntradas;
            Fecha = fecha;
            Observacion = observacion;
        }

        public int IdEntradas {  get; set; }
        public string Fecha { get; set; }
        public string Observacion { get; set; }

        
    }
}
