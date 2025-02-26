using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        private int idUsuario;
        private string nombreUsuario;
        private string contrasenia;
        private int rolUsuario;
        private string dniUsuario;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public int RolUsuario { get => rolUsuario; set => rolUsuario = value; }
        public string DniUsuario { get => dniUsuario; set => dniUsuario = value; }
    }
}
