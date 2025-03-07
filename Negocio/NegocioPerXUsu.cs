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
    public class NegocioPerXUsu
    {
        DaoPermisosXUsuarios dao = new DaoPermisosXUsuarios();
        public DataTable tablaPermisosDeCadaUsuario(string nombreNegocio)
        {
            return dao.tablaPermisosDeCadaUsuario(nombreNegocio); 
        }
        public bool modificarUnPermisoDelUsuario(int idDelPermiso, int idDelUsuario, string trueOrFalse)
        {
            bool result = false;
            permisosXusuarios permisoDelUsuario = new permisosXusuarios();
            permisoDelUsuario.IdUsuario_perXus = idDelUsuario;
            permisoDelUsuario.IdPermiso_perXus = idDelPermiso;
            permisoDelUsuario.TienePermiso_perXus = Convert.ToBoolean(trueOrFalse);
            if (dao.existePermisoXusuario(permisoDelUsuario))
            {
               if (dao.modificarUnPermisoDelUsuario(idDelPermiso, idDelUsuario, trueOrFalse) == 1)
               {
                   result = true;
               }
            }
               return result;
        }
        public bool altaUnPermisoDelUsuario(int idDelPermiso, int idDelUsuario, string trueOrFalse)
        {
            bool result = false;
            permisosXusuarios permisoDelUsuario = new permisosXusuarios();
            permisoDelUsuario.IdUsuario_perXus = idDelUsuario;
            permisoDelUsuario.IdPermiso_perXus = idDelPermiso;
            permisoDelUsuario.TienePermiso_perXus = Convert.ToBoolean(trueOrFalse);
            if (!dao.existePermisoXusuario(permisoDelUsuario))
            {
                if (dao.altaUnPermisoDelUsuario(permisoDelUsuario) == 1)
                {
                    result = true;
                }  
            }
             return result;
        }
    }
}
