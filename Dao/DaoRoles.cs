using System;
using System.Collections.Generic;
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
    }
}
