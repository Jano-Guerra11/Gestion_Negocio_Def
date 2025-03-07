using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RolesXpermisos
    {
        private int idRol_rxp;
        private int idPermiso_rxp;
        private bool tienePermiso_rxp;

        public int IdRol_rxp { get => idRol_rxp; set => idRol_rxp = value; }
        public int IdPermiso_rxp { get => idPermiso_rxp; set => idPermiso_rxp = value; }
        public bool TienePermiso_rxp { get => tienePermiso_rxp; set => tienePermiso_rxp = value; }
    }
}
