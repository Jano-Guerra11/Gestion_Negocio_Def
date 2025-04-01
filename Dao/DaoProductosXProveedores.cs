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
        
        public int modificarProveedor(int idProveedor, int idProducto, int idNegocio)
        {
            string consulta = "UPDATE productosxproveedores set idProveedor_pxp = "+idProveedor+
                " where idProducto_pxp =" +idProducto+ " AND idNegocio_pxp= "+idNegocio;
          return  ad.ejecutarConsulta(consulta);
        }
        public bool existeProductoXProveedor(int idProducto,int idProveedor,int idNegocio)
        {
            string consulta = "select * from productosxproveedores where idProveedor_pxp = "+idProveedor+
                " AND idProducto_pxp = "+idProducto+" AND idNegocio_pxp = "+idNegocio;
           return ad.existe(consulta);
        }
    }
}
