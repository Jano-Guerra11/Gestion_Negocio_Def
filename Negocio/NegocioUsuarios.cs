using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuarios
    {
        DaoUsuarios dao = new DaoUsuarios();
        public bool existeUsuario(Usuarios usuario)
        {
            bool existe = false;
            if (dao.existeUsuario(usuario))
            {
                existe = true;
            }
            return existe;
        }

        public int obtenerID(Usuarios usuario)
        {
            return dao.obtenerID(usuario);
        }
        public bool existeNombreUsuario(string nombre)
        {
            return dao.existeNombreUsuario(nombre);
        }

        public string obtenerRolDelUsuario(int idDeUsuario)
        {
            string rol = "no existe el usuario";
            DataTable datos = dao.obtenerInfoUsuario(idDeUsuario);
            if(datos.Rows.Count > 0)
            {
                rol = datos.Columns["idRol_us"].ToString();
            }
            return rol;
        }
    }
}
