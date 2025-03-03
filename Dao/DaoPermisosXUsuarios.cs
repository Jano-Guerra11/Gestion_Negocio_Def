using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoPermisosXUsuarios
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable tablaPermisosDeCadaUsuario()
        {
            string consulta = "select Cast(idUsuario_Us AS VARCHAR(10)) AS 'idUsuario_Us', nombre_us, nombre_r," +
                "MAX(CASE WHEN idPermiso_Per = 1 THEN 'SI' ELSE 'NO' END ) AS 'PRODUCTOS'," +
                "MAX(CASE WHEN idPermiso_Per = 2 THEN 'SI' ELSE 'NO' END ) AS 'INVENTARIO'," +
                "MAX(CASE WHEN idPermiso_Per = 3 THEN 'SI' ELSE 'NO' END ) AS 'VENTAS'," +
                "MAX(CASE WHEN idPermiso_Per = 4 THEN 'SI' ELSE 'NO' END ) AS 'REPORTES'," +
                "MAX(CASE WHEN idPermiso_Per = 5 THEN 'SI' ELSE 'NO' END ) AS 'ADMINISTRACION' " +
                " from usuarios inner join permisosXusuarios on usuarios.idUsuario_us = permisosXusuarios.idUsuario_PerXus" +
                " inner join permisos on permisos.idPermiso_Per = permisosXusuarios.idPermiso_PerXus " +
                " inner join roles on roles.idRol_r = usuarios.idRol_us " +
                "GROUP BY  Cast(idUsuario_Us AS VARCHAR(10)), nombre_us, nombre_r";
           return ad.obtenerTabla(consulta,"permisosDeCadaUsuario");
        }
    }
}
