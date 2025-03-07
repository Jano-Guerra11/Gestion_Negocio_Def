using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioRolesXpermisos
    {
        DaoRolesXPermisos dao = new DaoRolesXPermisos();

        public DataTable tablaDePermisosSegunRol(int idRol)
        {
            return dao.tablaDePermisosSegunRol(idRol);
        }
    }
}
