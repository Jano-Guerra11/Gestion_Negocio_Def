using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class DaoProveedores
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerTodosLosProveedores()
        {
            string consulta = "select * from proveedores";
            return ad.obtenerTabla(consulta,"Proveedores");
        }
        public int altaProveedor(Proveedores nuevoProveedor)
        {
            string consulta = "insert into proveedores(idProveedor_prov,idNegocio_prov,nombre_prov,razonSocial_prov," +
                " telefono_prov,mail_prov) " +
                "values("+nuevoProveedor.IdProveedor_prov+","+nuevoProveedor.IdNegocio_prov+",'"+nuevoProveedor.Nombre_prov+"','"+nuevoProveedor.RazonSocial_prov+"'," +
                "'"+nuevoProveedor.Telefono_prov+"','"+nuevoProveedor.Mail_prov+"')";
           return ad.ejecutarConsulta(consulta);
        }
        public bool existeProveedor(int idPRoveedor)
        {
            string consulta = "select * from proveedores WHERE idProveedor_prov = "+idPRoveedor;
            return ad.existe(consulta);
        }
        public DataTable obtenerTablaConUltimoId()
        {
            string consulta = "SELECT COALESCE(MAX(idProveedor_prov),0) FROM proveedores;";
           return ad.obtenerTabla(consulta,"ultimoIdProv");
        }
        public DataTable obtenerTablaConIdProveedor(string telefono)
        {
            string consulta = "select idProveedor_prov from proveedores where telefono_Prov = '" + telefono+"'";
            return ad.obtenerTabla(consulta,"idProv");
        }
    }
}
