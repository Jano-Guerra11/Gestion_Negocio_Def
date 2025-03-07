using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioNxU
    {
        DaoNegociosXUsuarios dao = new DaoNegociosXUsuarios();
        public bool existeNxU(NegociosXUsuarios nXu)
        {
            bool existe = false;
            if (dao.existeNegXUsu(nXu))
            {
                existe = true;
            }
            return existe;
        }
        public bool altaNegXUsu(NegociosXUsuarios negXusu)
        {
            bool alta = false;
            if (!dao.existeNegXUsu(negXusu))
            {
                if (dao.altaNegXUsu(negXusu) == 1)
                {
                    alta = true;
                }
            }
            return alta;
        }
    }
}
