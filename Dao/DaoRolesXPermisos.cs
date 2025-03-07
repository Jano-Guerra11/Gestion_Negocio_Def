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
    }
}
