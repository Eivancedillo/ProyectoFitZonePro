using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipos
    {
        public Equipos(int idEquipo, string nombre, string categoria, string fechaAdquisicion, string estado)
        {
            IdEquipo = idEquipo;
            Nombre = nombre;
            Categoria = categoria;
            FechaAdquisicion = fechaAdquisicion;
            Estado = estado;
        }

        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string FechaAdquisicion { get; set; }
        public string Estado { get; set; }
    }
}