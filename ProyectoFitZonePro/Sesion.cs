using Entidades;
using System.Collections.Generic;

namespace ProyectoFitZonePro
{
    public static class Sesion
    {
        public static int IdTrabajador { get; set; }
        public static string Nombre { get; set; }

        public static Dictionary<string, PermisoModulo> PermisosMenu { get; set; } = new Dictionary<string, PermisoModulo>();

        public static bool TienePermiso(string modulo, string accion)
        {
            if (!PermisosMenu.ContainsKey(modulo)) return false;

            PermisoModulo p = PermisosMenu[modulo];

            switch (accion.ToLower())
            {
                case "ver": return p.Ver;
                case "crear": return p.Crear;
                case "editar": return p.Editar;
                case "eliminar": return p.Eliminar;
                default: return false;
            }
        }
    }
}