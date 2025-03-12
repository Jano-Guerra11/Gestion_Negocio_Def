using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoProductos
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerTablaProductosDeUnNegocio(int idNegocio)
        {
            string consulta = "select idProducto_pr,nombre_pr,nombre_sec,descripcion_pr,precio_pr," +
                "stock_pr,nombre_prov from productos INNER JOIN productosXnegocios on " +
                "productos.idProducto_pr = productosXnegocios.idProducto_prXneg LEFT JOIN " +
                "productosXproveedores on productos.idProducto_pr = productosXproveedores.idProducto_pXp LEFT JOIN " +
                "proveedores on productosXproveedores.idProveedor_pXp = proveedores.idProveedor_prov LEFT JOIN " +
                "secciones ON productos.idSeccion_pr = secciones.idSeccion_sec " +
                "where activo_pr = 'true' and idNegocio_prXneg = " + idNegocio;

               return ad.obtenerTabla(consulta,"tablaProductos");
        }
    }
}
