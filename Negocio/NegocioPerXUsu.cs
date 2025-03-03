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
    }
}
