using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class NegocioProductos
    {
        DaoProductos dao = new DaoProductos();

        public DataTable obtenerTablaProductosDeUnNegocio(string nombreNegocio)
        {
            daoNegocios daoNegocio = new daoNegocios();
            NegocioC negocio = new NegocioC();            
            negocio.NombreNegocio = nombreNegocio;
            int idNegocio = daoNegocio.obtenerID(negocio);
            DataTable tablaProductos = dao.obtenerTablaProductosDeUnNegocio(idNegocio);

            if(tablaProductos.Rows.Count == 0 || tablaProductos == null)
            {
                tablaProductos = new DataTable();
                tablaProductos.Columns.Add("idProducto_pr");
                tablaProductos.Columns.Add("nombre_pr");
                tablaProductos.Columns.Add("nombre_sec");
                tablaProductos.Columns.Add("descripcion_pr");
                tablaProductos.Columns.Add("precio_pr");
                tablaProductos.Columns.Add("stock_pr");
                tablaProductos.Columns.Add("nombre_prov");
                
                tablaProductos.Rows.Add(tablaProductos.NewRow());

            }

            return tablaProductos;
        }
        public bool altaProducto(string nombre,int seccion,string descripcion,float precio,int stock,string urlImagen)
        {
            string idSeccion;
            Productos producto = new Productos();
            producto.IdProducto_pr = dao.obtenerUltimoId() + 1;
            producto.Nombre_pr = nombre;
            if(seccion == 0) { idSeccion = "NULL"; }
            else { idSeccion = seccion.ToString(); }
            producto.Descripcion_pr = descripcion;
            producto.Precio_pr = precio;
            producto.Stock_pr = stock;
            producto.Activo_pr = true;
            producto.UrlImagen_pr = urlImagen;

            bool alta = false;
            if (!dao.existeProducto(producto.IdProducto_pr))
            {
               if(dao.altaProducto(producto,idSeccion) == 1)
               {
                   alta = true;
               }
            }
            return alta;
        }
        public bool existeProducto(int idProducto)
        {
            return dao.existeProducto(idProducto);
        }
        public int obtenerIdDelProducto(string nombreDelProducto)
        {
            string idProducto = dao.obtenerIdDelProducto(nombreDelProducto);
            if (string.IsNullOrEmpty(idProducto))
            {
                return -1;
            }
            return Convert.ToInt32(idProducto);
        }
        public bool modificarProducto(string nombre, int idSeccion, string descripcion, float precio, int stock, string urlImagen)
        {
            bool accionExitosa = false;
            int idDelProducto = obtenerIdDelProducto(nombre);

            if(idDelProducto != -1)
            {
                Productos producto = new Productos();
                producto.IdProducto_pr = idDelProducto;
                producto.Nombre_pr = nombre;
                producto.IdSeccion_pr = idSeccion;
                producto.Descripcion_pr = descripcion;
                producto.Precio_pr = precio;
                producto.Stock_pr = stock;
                producto.UrlImagen_pr = urlImagen;

                if(dao.modificarProducto(producto) == 1)
                {
                    accionExitosa = true;
                }
            }
            return accionExitosa;
        }
    }
}
