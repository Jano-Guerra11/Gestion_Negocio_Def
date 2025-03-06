using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoPermisos
    {
        AccesoDatos ad = new AccesoDatos();

        public int obtenerIdPorNombre(string nombreDelPermiso)
        {
            string consulta = "select idPermiso_Per from Permisos where NombrePermiso_Per =" +
                " '"+nombreDelPermiso+"'";
            return Convert.ToInt32(ad.obtenerUnDatoEnString(consulta));
        }
    }
}
