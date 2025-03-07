using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoNegociosXUsuarios
    {
        AccesoDatos ad = new AccesoDatos();
        public bool existeNegXUsu(NegociosXUsuarios nXu)
        {
            bool existe=false;
            string consulta = "SELECT * FROM NegociosXusuarios WHERE idUsuario_nXu = " + nXu.IdUsuario + " " +
                "AND idNegocio_nXu = " + nXu.IdNegocio;
            if (ad.existe(consulta))
            {
                existe=true;
            }
            return existe;
        }
        public int altaNegXUsu(NegociosXUsuarios nXu)
        {
            string consulta = "insert into negociosXusuarios (idUsuario_nXu,idNegocio_nXu)";
            return ad.ejecutarConsulta(consulta);
        }
    }
}
