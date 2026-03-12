using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trabajadores
    {
        public Trabajadores(int idTrabajador, string nombre, string clave, string telefono, string email, string estatus)
        {
            IdTrabajador = idTrabajador;
            Nombre = nombre;
            Clave = clave;
            Telefono = telefono;
            Email = email;
            Estatus = estatus;
        }

        public int IdTrabajador { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estatus { get; set; }
    }
}