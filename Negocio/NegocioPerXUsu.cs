using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPerXUsu
    {
        DaoPermisosXUsuarios dao = new DaoPermisosXUsuarios();
        public DataTable tablaPermisosDeCadaUsuario()
        {
            return dao.tablaPermisosDeCadaUsuario(); 
        }
        public bool modificarUnPermisoDelUsuario(int idDelPermiso, int idDelUsuario, string trueOrFalse)
        {
            bool result = false;
            if (dao.modificarUnPermisoDelUsuario(idDelPermiso, idDelUsuario, trueOrFalse) == 1)
            {
                result = true;
            }
            return result;
        }
    }
}
