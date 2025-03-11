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
    public class NegocioRolesXpermisos
    {
        DaoRolesXPermisos dao = new DaoRolesXPermisos();

        public DataTable tablaDePermisosSegunRol(int idRol)
        {
            return dao.tablaDePermisosSegunRol(idRol);
        }
        public bool altaUnPermisoDelRol(int idRol,int idPermiso,bool activo)
        {
            bool alta = false;
            RolesXpermisos rxp = new RolesXpermisos();
            rxp.IdRol_rxp = idRol;
            rxp.IdPermiso_rxp = idPermiso;
            rxp.TienePermiso_rxp = activo;
            if (!dao.existeRolXPermiso(rxp))
            {
                if (dao.altaRolesXPermisos(rxp)>0)
                {
                    alta = true;
                }
            }
               return alta;
        }
    }
}
