using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dao
{
   
    public class daoNegocios
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerTablaNegocios()
        {
            string consulta = "SELECT * FROM NEGOCIOS";
           return ad.obtenerTabla(consulta,"Negocios");
        }
        public bool existeNegocio(NegocioC negocio)
        {
            bool existe = false;
            string consulta = "SELECT * FROM Negocios WHERE nombre_n = '"+negocio.NombreNegocio+"'";
            if (ad.existe(consulta))
            {
                existe = true;
            }
            return existe;
        }
        public int obtenerID(NegocioC negocio)
        {
            int id = 0;
            string consulta = "SELECT idNegocio_n FROM Negocios where nombre_n = '" + negocio.NombreNegocio +
                "'";
            DataTable dt = ad.obtenerTabla(consulta, "idNegocio");
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0]);
            }
            return id;

        }
        public DataTable obtenerInfoNegocio(int idNegocio)
        {
            string consulta = "SELECT * FROM Negocios WHERE idNegocio_n = " + idNegocio;
            return ad.obtenerTabla(consulta, "infoDelNegocio");
        }
        public int altaNegocio(NegocioC negocio)
        {
            string consulta="insert into Negocios (nombre_n) " +
                "select '"+negocio.NombreNegocio+"'";
            return ad.ejecutarConsulta(consulta);
        }
    }
}
