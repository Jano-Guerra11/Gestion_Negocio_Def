﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoPermisosXUsuarios
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable tablaPermisosDeCadaUsuario(string nombreNegocio)
        {
            string consulta = "select Cast(idUsuario_Us AS VARCHAR(10)) AS 'idUsuario_Us', nombre_us, nombre_r," +
                "MAX(CASE WHEN idPermiso_Per = 1 AND TienePermiso_PerXus = 'True' THEN 'SI' ELSE 'NO' END ) AS 'PRODUCTOS'," +
                "MAX(CASE WHEN idPermiso_Per = 2 AND TienePermiso_PerXus = 'True' THEN 'SI' ELSE 'NO' END ) AS 'INVENTARIO'," +
                "MAX(CASE WHEN idPermiso_Per = 3 AND TienePermiso_PerXus = 'True' THEN 'SI' ELSE 'NO' END ) AS 'VENTAS'," +
                "MAX(CASE WHEN idPermiso_Per = 4 AND TienePermiso_PerXus = 'True' THEN 'SI' ELSE 'NO' END ) AS 'REPORTES'," +
                "MAX(CASE WHEN idPermiso_Per = 5 AND TienePermiso_PerXus = 'True' THEN 'SI' ELSE 'NO' END ) AS 'ADMINISTRACION' " +
                " from usuarios inner join permisosXusuarios on usuarios.idUsuario_us = permisosXusuarios.idUsuario_PerXus" +
                " inner join permisos on permisos.idPermiso_Per = permisosXusuarios.idPermiso_PerXus " +
                " inner join roles on roles.idRol_r = usuarios.idRol_us inner join negociosXusuarios on " +
                "negociosXusuarios.idUsuario_nXu = usuarios.idUsuario_us inner join negocios on " +
                "negocios.idNegocio_n = negociosXusuarios.idNegocio_nXu WHERE nombre_n = '"+nombreNegocio+"'" +
                "GROUP BY  Cast(idUsuario_Us AS VARCHAR(10)), nombre_us, nombre_r";
           return ad.obtenerTabla(consulta,"permisosDeCadaUsuario");
        }

        public bool existePermisoXusuario(permisosXusuarios perXus)
        {
            string consulta = "select * from permisosXusuarios WHERE idUsuario_PerXus = "
                + perXus.IdUsuario_perXus + " AND idPermiso_PerXus = " + perXus.IdPermiso_perXus;
           return ad.existe(consulta);
        }

        public int modificarUnPermisoDelUsuario(int idDelPermiso,int idDelUsuario,string trueOrFalse)
        {
            string consulta = "update permisosXusuarios SET TienePermiso_PerXus = '"+trueOrFalse+"' " +
                "WHERE idUsuario_PerXus = " + idDelUsuario + " AND idPermiso_PerXus = " + idDelPermiso;
           return ad.ejecutarConsulta(consulta);
        }
        public int altaUnPermisoDelUsuario(permisosXusuarios perXus)
        {
            Debug.WriteLine("id del usuario: " + perXus.IdUsuario_perXus);
            string consulta = "insert into permisosXusuarios (idUsuario_PerXus,idPermiso_PerXus,tienePermiso_PerXus) " +
                "values (" + perXus.IdUsuario_perXus + "," + perXus.IdPermiso_perXus + ",'" + perXus.TienePermiso_perXus + "')";
            return ad.ejecutarConsulta(consulta);
        }
        

        
    }
}
