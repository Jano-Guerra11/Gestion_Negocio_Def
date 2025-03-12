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
    }
}
