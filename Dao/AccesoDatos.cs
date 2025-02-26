using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AccesoDatos
    {
        string rutaBD = "Data Source=LAPTOPJANO\\SQLEXPRESS;Initial Catalog=Gestion_de_Negocio;Integrated Security=True;Encrypt=True";

        private SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(rutaBD);
                try
                {
                    conexion.Open();
                    return conexion;
                }
                catch (Exception ex)
                {
                    return null;
                }
            
        }

        private SqlDataAdapter obtenerAdaptador(string consultaSQL,SqlConnection cn)
        {
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(consultaSQL, cn);
                return adapter;
            }catch(Exception ex)
            {
                return null;
            }
        }
        
        public DataTable obtenerTabla(string consulta,string nombreTabla)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
              SqlDataAdapter adapter = obtenerAdaptador(consulta, conexion);
              DataSet ds = new DataSet();
              adapter.Fill(ds,nombreTabla);
              return ds.Tables[nombreTabla];

            }
        }
        public int ejecutarConsulta(string consultaSQL)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
               int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas;
            }
        }

        public int ejecutarProcedimientoAlmacenado(SqlCommand cmd,string nombreSP)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
                SqlCommand comando = cmd;
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas;
            }
        }
        public bool existe(string consultaSQL)
        {
            bool existe = false;
            using (SqlConnection conexion = obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consultaSQL, conexion))
            using (SqlDataReader datos = cmd.ExecuteReader())
            {
                if (datos.Read())
                {
                    existe = true;
                }
            }
               return existe;
        }
        

        
    }
}
