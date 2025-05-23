﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AccesoDatos
    {
        string rutaBD = "Data Source=LAPTOPJANO\\SQLEXPRESS;Initial Catalog=Gestion_de_Negocio;Integrated Security=True";

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
                  Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine("-- exception en obtener conexion");
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
        public string obtenerUnDatoEnString(string consulta)
        {
           using(SqlConnection conexion = obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta,conexion))
            using(SqlDataReader datos = cmd.ExecuteReader())
            {
                if (datos.Read())
                {
                    return datos.GetInt32(0).ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        public int obtenerMaximo(string consulta)
        {
            int maximo = 0;
            using (SqlConnection conexion = obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                object resultado = cmd.ExecuteScalar();
                maximo = (resultado == null || resultado == DBNull.Value) ? 0 : Convert.ToInt32(resultado);
            }
            return maximo;
        }

        
    }
}
