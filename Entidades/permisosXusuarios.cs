using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class permisosXusuarios
    {
        private int idUsuario_perXus;
        private int idPermiso_perXus;
        private bool tienePermiso_perXus;

        public int IdUsuario_perXus { get => idUsuario_perXus; set => idUsuario_perXus = value; }
        public int IdPermiso_perXus { get => idPermiso_perXus; set => idPermiso_perXus = value; }
        public bool TienePermiso_perXus { get => tienePermiso_perXus; set => tienePermiso_perXus = value; }
    }
}
