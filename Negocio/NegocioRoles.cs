using Dao;
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
    }
}
