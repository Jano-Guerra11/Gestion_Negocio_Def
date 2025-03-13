using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        public int altaProducto(Productos producto,string idseccion)
        {
            string consulta = "INSERT INTO productos(idProducto_pr,nombre_pr,idSeccion_pr,descripcion_pr," +
                "precio_pr,stock_pr,activo_pr,urlImagen_pr) " +
                "values("+producto.IdProducto_pr+",'"+producto.Nombre_pr+"',"+idseccion+",'" +
                producto.Descripcion_pr+"',"+producto.Precio_pr+","+producto.Stock_pr+",'"+producto.Activo_pr+"','" +
                producto.UrlImagen_pr + "')";
            Debug.WriteLine(consulta);
           return ad.ejecutarConsulta(consulta);
        }
        public bool existeProducto(int idProducto)
        {
            string consulta = "select * from productos where idProducto_pr = " + idProducto;
            return ad.existe(consulta);
        }
        public int obtenerUltimoId()
        {
            string consulta = "select MAX(idProducto_pr) from productos";
            return ad.obtenerMaximo(consulta);
        }
        public string obtenerIdDelProducto(string nombreDelProducto)
        {
            string consulta = "select idProducto_pr from productos where nombre_pr ='" + nombreDelProducto + "'";
           return ad.obtenerUnDatoEnString(consulta);
        }
        public int modificarProducto(Productos producto)
        {
            string consulta = "UPDATE productos set nombre_pr = '"+producto.Nombre_pr+"', "+
               "idSeccion_pr = "+producto.IdSeccion_pr+", descripcion_pr ='"+producto.Descripcion_pr+"',"+
               "precio_pr = "+producto.Precio_pr+", stock_pr = "+producto.Stock_pr+", "+
               "urlImagen_pr ='"+producto.UrlImagen_pr+"' where idproducto_pr = "+producto.IdProducto_pr;
           return ad.ejecutarConsulta(consulta);
        }
    }
}
