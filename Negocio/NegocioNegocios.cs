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
    public class NegocioNegocios
    {
        daoNegocios dao = new daoNegocios();

        public DataTable obtenerTablaNegocios()
        {
            return dao.obtenerTablaNegocios();
        }
        public bool existeNegocio(NegocioC negocio)
        {
            bool existe = false;    
            if (dao.existeNegocio(negocio))
            {
                existe = true;
            }
            return existe;
        }
        public int obtenerID(string nombreNegocio)
        {
            NegocioC negocio = new NegocioC();
            negocio.NombreNegocio = nombreNegocio;
            return dao.obtenerID(negocio);
        }

        public bool altaNegocio(string nombreNeg)
        {
            bool alta = false;
            NegocioC negocio = new NegocioC();
            negocio.NombreNegocio = nombreNeg;
            if (!dao.existeNegocio(negocio))
            {
               if(dao.altaNegocio(negocio) == 1)
               {
                   alta = true;
               }
            }
            return alta;
        }
    }
}
