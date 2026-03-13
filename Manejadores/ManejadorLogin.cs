using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using Entidades;

namespace Manejadores
{
    public class ManejadorLogin
    {
        private Base b = new Base();

        // Devuelve el ID si es correcto, o 0 si falla
        public int ValidarUsuario(string usuario, string clave)
        {
            DataTable dt = b.Consultar($"call p_validarTrabajadores('{usuario}', '{clave}')", "Login").Tables[0];

            if (dt.Rows[0]["rs"].ToString() == "Ac3ptad0")
            {
                return Convert.ToInt32(dt.Rows[0]["idTrabajador"]);
            }
            return 0; // Falló
        }

        // Carga qué módulos puede VER el usuario
        // Reemplaza tu método ObtenerPermisosDeAcceso por este:
        public Dictionary<string, PermisoModulo> ObtenerPermisos(int idTrabajador)
        {
            Dictionary<string, PermisoModulo> permisos = new Dictionary<string, PermisoModulo>();

            // Nos traemos las 4 columnas de la base de datos
            DataTable dt = b.Consultar($"SELECT modulo, p_ver, p_crear, p_editar, p_eliminar FROM tbl_permisos_trabajadores WHERE fkIdTrabajador = {idTrabajador}", "Permisos").Tables[0];

            foreach (DataRow fila in dt.Rows)
            {
                PermisoModulo p = new PermisoModulo
                {
                    Ver = Convert.ToBoolean(fila["p_ver"]),
                    Crear = Convert.ToBoolean(fila["p_crear"]),
                    Editar = Convert.ToBoolean(fila["p_editar"]),
                    Eliminar = Convert.ToBoolean(fila["p_eliminar"])
                };

                // Guardamos el módulo (ej. "Membresias") y sus 4 permisos
                permisos.Add(fila["modulo"].ToString(), p);
            }
            return permisos;
        }
    }
}