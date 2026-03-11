using System.Collections.Generic;

namespace Entidades
{
    public class Membresias
    {
        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public double CostoMensual { get; set; }
        public double CostoSemestral { get; set; }
        public double CostoAnual { get; set; }
        public string Estatus { get; set; }
        public List<int> BeneficiosIds { get; set; }

        public Membresias(int idMembresia, string nombre, double costoMensual, double costoSemestral, double costoAnual, string estatus)
        {
            IdMembresia = idMembresia;
            Nombre = nombre;
            CostoMensual = costoMensual;
            CostoSemestral = costoSemestral;
            CostoAnual = costoAnual;
            Estatus = estatus;
            BeneficiosIds = new List<int>();
        }
    }
}