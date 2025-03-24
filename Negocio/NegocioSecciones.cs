using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class NegocioSecciones
    {
        DaoSecciones dao = new DaoSecciones();

        public DataTable obtenerTablaSecciones(int idNegocio)
        {
            return dao.obtenerTablaSecciones(idNegocio);
        } 
        public int obtenerIdSeccion(string nombreSec)
        {
            int idFinal = -1;
           string id = dao.obtenerIdSeccion(nombreSec);
            if (!string.IsNullOrEmpty(id))
            {
                idFinal = Convert.ToInt32(id);
            }
            return idFinal;
        }

        public bool altaSeccion( string nombreSeccion, int idNegocio)
        {
            bool alta = false;
            int idSeccion = obtenerIdSeccion(nombreSeccion);
            if (idSeccion == -1)
            {
                if (nombreSeccion == "sin seccion") idSeccion = 0;
                else idSeccion = dao.obtenerUltimoId() + 1;

                if (dao.altaSeccion(idSeccion, nombreSeccion, idNegocio) == 1){
                      alta = true;
                }
            }
            return alta;
        }

    }
}
