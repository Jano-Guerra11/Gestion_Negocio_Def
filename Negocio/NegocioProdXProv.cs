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
            if (negProv.existeProveedor(idProveedor))
            {
               alta = (dao.altaProductosXProveedores(idProveedor,idProducto,idNegocio)==1)? true:false;

            }
            return alta;
        }
    }
}
