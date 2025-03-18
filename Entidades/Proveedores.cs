using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedores
    {
        private int idProveedor_prov;
        private string nombre_prov;
        private int idNegocio_prov;
        private string razonSocial_prov;
        private string telefono_prov;
        private string mail_prov;

        public string Nombre_prov { get => nombre_prov; set => nombre_prov = value; }
        public int IdNegocio_prov { get => idNegocio_prov; set => idNegocio_prov = value; }
        public string RazonSocial_prov { get => razonSocial_prov; set => razonSocial_prov = value; }
        public string Telefono_prov { get => telefono_prov; set => telefono_prov = value; }
        public string Mail_prov { get => mail_prov; set => mail_prov = value; }
        public int IdProveedor_prov { get => idProveedor_prov; set => idProveedor_prov = value; }
    }
}
