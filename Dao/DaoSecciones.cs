using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoSecciones
    {
        AccesoDatos ad = new AccesoDatos();
        
        public DataTable obtenerTablaSecciones(int idNegocio)
        {
            string consulta = "select idSeccion_sec,nombre_sec from secciones where idNegocio_sec = " + idNegocio;
           return ad.obtenerTabla(consulta,"secciones");
        }

        public int altaSeccion(int idSeccion,string nombreSeccion,int idNegocio)
        {
            string consulta = "insert into secciones (idSeccion_sec,nombre_sec,idNegocio_sec) " +
                              "values(" + idSeccion + ",'" + nombreSeccion + "'," + idNegocio + ")";
            return ad.ejecutarConsulta(consulta);
        }
        public bool existeSeccion(int idSeccion)
        {
            string consulta = "select * from secciones where idSeccion_sec = " + idSeccion;
            return ad.existe(consulta);
        }
        public string obtenerIdSeccion(string nombre)
        {
            string consulta = "select idSeccion_sec from secciones where nombre_sec = '" + nombre + "'";
            return ad.obtenerUnDatoEnString(consulta);
        }
        public int obtenerUltimoId()
        {
            string consulta = "select MAX(idSeccion_sec) from secciones";
            return ad.obtenerMaximo(consulta);
        }
    }
}
