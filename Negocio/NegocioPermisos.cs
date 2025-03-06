using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPermisos
    {
        DaoPermisos dao = new DaoPermisos();
        public int obtenerIdPorNombre(string nombreDelPermiso)
        {
            return dao.obtenerIdPorNombre(nombreDelPermiso);
        }
    }
}
