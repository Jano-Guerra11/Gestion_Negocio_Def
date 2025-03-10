using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoUsuarios
    {
        AccesoDatos ad = new AccesoDatos();
       
        public bool existeUsuario(Usuarios usuario)
        {
            bool existe = false;
            string consulta = "SELECT * FROM usuarios where idUsuario_us = "+usuario.IdUsuario
                +" and nombre_Us = '"+usuario.NombreUsuario+"' and contrasenia_us = '"+usuario.Contrasenia+"'";
            if(ad.existe(consulta))
            {
                existe = true;
            }     
            return existe;
        }
        public int obtenerID(Usuarios usuario)
        {
            int id = 0;
            string consulta = "SELECT idUsuario_us FROM usuarios where nombre_Us = '" + usuario.NombreUsuario +
                "' and contrasenia_us = '" + usuario.Contrasenia + "'";
            DataTable dt = ad.obtenerTabla(consulta,"idUsuario");
            if(dt.Rows.Count > 0)
            {
              id = Convert.ToInt32(dt.Rows[0][0]);
            }
            return id;

        }
        public DataTable obtenerInfoUsuario(int idUsuario)
        {
            string consulta = "SELECT * FROM Usuarios WHERE idUsuario_us = "+idUsuario;
            return ad.obtenerTabla(consulta, "infoDelUsuario");
        }
        public bool existeNombreUsuario(string nombre)
        {
            string consulta = "select * from usuarios where nombre_us = '" + nombre + "'";
            return ad.existe(consulta);
        }
        
        public int altaUsuario(Usuarios usuario)
        {
            string consulta = "INSERT INTO usuarios (idUsuario_Us,nombre_Us,contrasenia_us,idrol_us) " +
                "values ("+usuario.IdUsuario+",'"+usuario.NombreUsuario+"','"+usuario.Contrasenia+"'," +
                ""+usuario.RolUsuario+")";
            return ad.ejecutarConsulta(consulta);
        }
        public int obtenerIdMaximo()
        {
            string consulta = "select MAX(idUsuario_us) from usuarios";
            return ad.obtenerMaximo(consulta);
        }
    }
}
