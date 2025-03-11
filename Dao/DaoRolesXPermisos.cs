using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoRolesXPermisos
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable tablaDePermisosSegunRol(int idRol)
        {
            string consulta = "select idPermiso_rxp,tienePermiso_rxp from rolesXpermisos " +
                "where idRol_Rxp = " + idRol;
           return ad.obtenerTabla(consulta,"permisosDelRol");
        }
        public int altaRolesXPermisos(RolesXpermisos rxp)
        {
            string consulta = "insert into rolesxpermisos(idRol_rxp,idPermiso_rxp,tienePermiso_rxp) " +
                "values(" + rxp.IdRol_rxp + "," + rxp.IdPermiso_rxp + ",'" + rxp.TienePermiso_rxp + "')";
            return ad.ejecutarConsulta(consulta);
        }
        public bool existeRolXPermiso(RolesXpermisos rxp)
        {
            string consulta = "select * from rolesxpermisos where idRol_rxp = " + rxp.IdRol_rxp + " AND " +
                "idPermiso_rxp = " + rxp.IdPermiso_rxp;
            return ad.existe(consulta);
                
        }
    }
}
