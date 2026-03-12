using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Socios
    {
        public Socios(int idSuscripcion, int fkIdUsuario, int fkIdMembresia, string duracion, string fechaInicio, string fechaFin, double costoTotal, string estado)
        {
            IdSuscripcion = idSuscripcion;
            FkIdUsuario = fkIdUsuario;
            FkIdMembresia = fkIdMembresia;
            Duracion = duracion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            CostoTotal = costoTotal;
            this.estado = estado;
        }

        public int IdSuscripcion { get; set; }
        public int FkIdUsuario { get; set; }
        public int FkIdMembresia { get; set; }
        public string Duracion { get; set; } // Mensual, Semestral, Anual
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public double CostoTotal { get; set; }
        public string estado { get; set; } // activo, vencido, cancelado
    }
}