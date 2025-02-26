using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NegocioNegocios
    {
        daoNegocios dao = new daoNegocios();
        public bool existeNegocio(NegocioC negocio)
        {
            bool existe = false;    
            if (dao.existeNegocio(negocio))
            {
                existe = true;
            }
            return existe;
        }
        public int obtenerID(NegocioC negocio)
        {
            return dao.obtenerID(negocio);
        }
    }
}
