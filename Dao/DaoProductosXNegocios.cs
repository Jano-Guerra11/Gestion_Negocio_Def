using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace Dao
{
    public class DaoProductosXNegocios
    {
        AccesoDatos ad = new AccesoDatos();

        public int altaProductosXnegocios(int idNegocio,int idProducto)
        {
            string consulta ="insert into productosxnegocios(idNegocio_prXneg,idProducto_prXneg) " +
                "values("+idNegocio+","+idProducto+")";
            return ad.ejecutarConsulta(consulta);
        }
        public bool existeProductoXNegocio(int idNegocio,int idProducto)
        {
            string consulta ="select * from productosxnegocios where idNegocio_prXneg = "+idNegocio+
                " AND idproducto_prXneg = "+idProducto;
           return ad.existe(consulta);

        }
    }
}
