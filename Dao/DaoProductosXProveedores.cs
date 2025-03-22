using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoProductosXProveedores
    {
        AccesoDatos ad = new AccesoDatos();
        public int altaProductosXProveedores(int idProveedor,int idProducto,int idNegocio)
        {
            string consulta = "insert into productosxproveedores(idProveedor_pxp,idProducto_pxp,idNegocio_pxp) " +
                "values("+idProveedor+","+idProducto+","+idNegocio+")";
            return ad.ejecutarConsulta(consulta);
        }
    }
}
