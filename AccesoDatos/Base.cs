using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos

{
    public class Base
    {
        private MySqlConnection con;

        public Base()
        {
            con = new MySqlConnection("server=localhost; port=3306; user=root; password=; database=fitZone; Charset=utf8mb4;");
        }

        public void Comando(string query, bool mantenerConexion = false)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

                if (!mantenerConexion)
                    con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                throw;
            }
        }

        public DataSet Consultar(string query, string table, bool mantenerConexion = false)
        {
            DataSet ds = new DataSet();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                da.Fill(ds, table);

                if (!mantenerConexion)
                    con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                throw;
            }

            return ds;
        }


        public int ConsultarEscalarInt(string query, bool mantenerConexion = false)
        {
            int resultado = 0;
            try
            {
                if (con.State != ConnectionState.Open) con.Open();

                MySqlCommand cmd = new MySqlCommand(query, con);
                object res = cmd.ExecuteScalar();

                if (res != null && res != DBNull.Value)
                {
                    resultado = Convert.ToInt32(res);
                }

                if (!mantenerConexion) con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open) con.Close();
                throw;
            }
            return resultado;
        }

        public decimal ConsultarEscalarDecimal(string query, bool mantenerConexion = false)
        {
            decimal resultado = 0;
            try
            {
                if (con.State != ConnectionState.Open) con.Open();

                MySqlCommand cmd = new MySqlCommand(query, con);
                object res = cmd.ExecuteScalar();

                if (res != null && res != DBNull.Value)
                {
                    resultado = Convert.ToDecimal(res);
                }

                if (!mantenerConexion) con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open) con.Close();
                throw;
            }
            return resultado;
        }

        // Método dentro de tu clase Base de datos
        public bool EjecutarProcedimientoHuella(int idUsuario, byte[] huellaBinaria, bool mantenerConexion = false)
        {
            bool exito = false;
            try
            {
                // Usamos TU variable de conexión global 'con'
                if (con.State != ConnectionState.Open)
                    con.Open();

                // Le pasamos 'con' al comando en lugar de crear una nueva
                MySqlCommand cmd = new MySqlCommand("p_registrarHuella", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros seguros para evitar inyección SQL y poder mandar el BLOB
                cmd.Parameters.AddWithValue("_idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("_huella", huellaBinaria);

                // Ejecutamos la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();
                exito = (filasAfectadas > 0);

                // Respetamos tu regla de cerrar la conexión si no se pide mantenerla
                if (!mantenerConexion)
                    con.Close();
            }
            catch (Exception ex)
            {
                // Respetamos tu manejo de errores
                if (con.State == ConnectionState.Open)
                    con.Close();

                throw new Exception("Error al guardar la huella en la BD: " + ex.Message);
            }

            return exito;
        }
    }
}