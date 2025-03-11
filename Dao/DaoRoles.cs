using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoRoles
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerRoles()
        {
            string consulta = "select * from roles";
           return ad.obtenerTabla(consulta,"roles");
        }
        public int altaRol(Roles rol)
        {
            string consulta = "insert into roles (nombre_r) " +
                "values('" + rol.Nombre_r + "')";
           return ad.ejecutarConsulta(consulta);
        }
        public bool existeRol(Roles role)
        {
            string consulta = "select * from roles where nombre_r ='" + role.Nombre_r + "'";
           return ad.existe(consulta);
        }
        public string obtenerIdRol(string nombre)
        {
            string consulta = "select idRol_r from roles WHERE nombre_r ='" + nombre + "'";
           return ad.obtenerUnDatoEnString(consulta);
        }
    }
}
