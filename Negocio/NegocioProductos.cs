using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Diagnostics;

namespace Negocio
{
    public class NegocioProductos
    {
        DaoProductos dao = new DaoProductos();

        public DataTable obtenerTablaProductosDeUnNegocio(List<string> datosFiltro,int idNegocio,string opId,
            string opPrecio, string opStock)
        {
           
            DataTable tablaProductos = dao.obtenerTablaProductosDeUnNegocio(idNegocio, datosFiltro[0], datosFiltro[1], datosFiltro[3],
              datosFiltro[4],datosFiltro[5], opId,
                opPrecio, opStock, datosFiltro[2]);

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
        public bool altaProducto(Productos producto, int idNegocio)
        {
            string idSeccion;
            DaoProductosXNegocios daoPrXNeg = new DaoProductosXNegocios();
            int idProducto = dao.obtenerUltimoId() + 1;
            producto.IdProducto_pr = idProducto;
            if(producto.IdSeccion_pr == 0) { idSeccion = "NULL"; }
            else { idSeccion = producto.IdSeccion_pr.ToString(); }
           

            bool alta = false;
            if (!dao.existeProducto(idProducto) &
               !daoPrXNeg.existeProductoXNegocio(idProducto,idNegocio))
            {
                
               int filasAfectadasProd = dao.altaProducto(producto, idSeccion);
                
                int filasAfectadasPxN = daoPrXNeg.altaProductosXnegocios(idNegocio, idProducto);

               if (filasAfectadasProd == 1 && filasAfectadasPxN ==1)
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
        public bool modificarProducto(Productos producto)
        {
            bool accionExitosa = false;

            if(producto.IdProducto_pr != -1)
            {
                if(dao.modificarProducto(producto) == 1)
                {
                    accionExitosa = true;
                }
            }
            return accionExitosa;
        }
    }
}
