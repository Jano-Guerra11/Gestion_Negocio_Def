using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioRoles
    {
        DaoRoles dao = new DaoRoles();
        public DataTable obtenerRoles()
        {
            return dao.obtenerRoles();
        }
        public bool altaRol(string nombreRol)
        {
            bool alta = false;
            Roles rol = new Roles();
            rol.Nombre_r = nombreRol;

            if(!dao.existeRol(rol))
            {
               if (dao.altaRol(rol) > 0)
               {
                    alta = true;
               }
            }
               return alta;
        }
        public int obtenerIdRol(string nombre)
        {
           return Convert.ToInt32(dao.obtenerIdRol(nombre));
        }
    }
}
