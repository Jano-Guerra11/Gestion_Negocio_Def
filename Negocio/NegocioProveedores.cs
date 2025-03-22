using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio
{
    public class NegocioProveedores
    {
        DaoProveedores dao = new DaoProveedores();

        public DataTable obtenerTodosLosProveedores()
        {
            return dao.obtenerTodosLosProveedores();
        }

        public int obtenerIdProveedor(string telefono)
        {
            int id = -1;
            DataTable tablaIdProv = dao.obtenerTablaConIdProveedor(telefono);
         
            if (tablaIdProv.Rows.Count > 0)
            {
                id = Convert.ToInt32(tablaIdProv.Rows[0][0]);
            }
            return id;
        }
        public int obtenerUltimoId()
        {
            DataTable TablaUltimoId = dao.obtenerTablaConUltimoId();
            return Convert.ToInt32(TablaUltimoId.Rows[0][0]); 
        }
        public bool altaProveedor(int idNegocio,string nombre,string razonSocial,string telefono,string mail)
        {
            bool altaExitosa = false;
            
            if(obtenerIdProveedor(telefono) == -1)
            {
                Proveedores nuevoProv = new Proveedores();
                if (nombre == "sin proveedor") nuevoProv.IdProveedor_prov = 0;
                else nuevoProv.IdProveedor_prov = obtenerUltimoId() + 1;
                nuevoProv.IdNegocio_prov = idNegocio;
                nuevoProv.Nombre_prov = nombre;
                nuevoProv.RazonSocial_prov = razonSocial;
                nuevoProv.Telefono_prov = telefono;
                nuevoProv.Mail_prov = string.IsNullOrEmpty(mail)? "NULL" : mail;
                   altaExitosa = dao.altaProveedor(nuevoProv) == 1;
            }
               return altaExitosa;
        }
        public bool existeProveedor(int idProveedor)
        {
            return dao.existeProveedor(idProveedor);
        }
    }
}
