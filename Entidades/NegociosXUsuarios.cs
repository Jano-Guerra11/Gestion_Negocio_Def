using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NegociosXUsuarios
    {
        private int idUsuario;
        private int idNegocio;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
    }
}
