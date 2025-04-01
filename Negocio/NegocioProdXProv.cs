using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProdXProv
    {
        DaoProductosXProveedores dao = new DaoProductosXProveedores();

        public bool altaProductoXProveedor(int idProveedor,int idProducto,int idNegocio)
        {
            bool alta = false;
            NegocioProveedores negProv = new NegocioProveedores();
            NegocioProductos negProd = new NegocioProductos();
            if (negProv.existeProveedor(idProveedor) && negProd.existeProducto(idProducto))
            {
                if (!dao.existeProductoXProveedor(idProducto, idProveedor, idNegocio))
                {
                   alta = (dao.altaProductosXProveedores(idProveedor,idProducto,idNegocio)==1)?true:false;
                }

            }
            return alta;
        }
        public bool modificarProveedorDelProducto(int idProveedor, int idProducto, int idNegocio)
        {
            bool modificado = false;
            NegocioProveedores negProv = new NegocioProveedores();
            NegocioProductos negProd = new NegocioProductos();
            if (negProv.existeProveedor(idProveedor) && negProd.existeProducto(idProducto))
            {
                if (dao.existeProductoXProveedor(idProducto, idProveedor, idNegocio))
                {
                    dao.modificarProveedor(idProveedor,idProducto,idNegocio);
                    modificado = true;
                }
            }
            return modificado;
           
        }
    }
}
