using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleEntrada
    {
        public DetalleEntrada(int idDetalleEntrada, int fkIdEntrada, int fkIdProduto, int cantidad, double precio_Unitario)
        {
            IdDetalleEntrada = idDetalleEntrada;
            FkIdEntrada = fkIdEntrada;
            FkIdProduto = fkIdProduto;
            Cantidad = cantidad;
            Precio_Unitario = precio_Unitario;
        }

        public DetalleEntrada()
        {
            
        }

        public int IdDetalleEntrada { get; set; }
        public int FkIdEntrada { get; set; }
        public int FkIdProduto { get; set; }
        public int Cantidad { get; set; }
        public double Precio_Unitario { get; set; }
    }
}
