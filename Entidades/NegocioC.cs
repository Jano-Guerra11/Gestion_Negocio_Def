using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NegocioC
    {
        private int idNegocio;
        private string nombreNegocio;

        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
        public string NombreNegocio { get => nombreNegocio; set => nombreNegocio = value; }
    }
}
