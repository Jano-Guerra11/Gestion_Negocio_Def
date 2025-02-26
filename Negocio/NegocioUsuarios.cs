using Dao;
using Entidades;
using System;
using System.Collections.Generic;
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
    }
}
