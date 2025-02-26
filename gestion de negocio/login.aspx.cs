using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_de_negocio
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("registracion.aspx");
        }

        protected void cvIniciarSesion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valido = false;
            if (iniciarSesion())
            {
                valido = true;
            }
            args.IsValid = valido;
            
        }
        public bool iniciarSesion()
        {
            bool UsuarioValido = false;
            Usuarios usuarios = new Usuarios();
            NegocioC negocio = new NegocioC();
            NegociosXUsuarios NxU = new NegociosXUsuarios();
            NegocioUsuarios negocioUsuarios = new NegocioUsuarios();
            NegocioNegocios negNeg = new NegocioNegocios();
            NegocioNxU negNxU = new NegocioNxU();

            usuarios.NombreUsuario = txtNombreUsuario.Text;
            usuarios.Contrasenia = txtPassword.Text;
            negocio.NombreNegocio = txtNombreNegocio.Text;
            NxU.IdUsuario = negocioUsuarios.obtenerID(usuarios); /*atravez del nombre que es unico*/
            NxU.IdNegocio = negNeg.obtenerID(negocio); /*atravez del nombre que es unico*/

            if (negocioUsuarios.existeUsuario(usuarios) &&
              negNeg.existeNegocio(negocio) && negNxU.existeNxU(NxU))
            {
                UsuarioValido = true;
            Debug.WriteLine("xxxxxxxxxxxxx usuario valido");
            }
            return UsuarioValido;
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (iniciarSesion())
            {
                Debug.WriteLine("------------- inicio correcto ---------");
            }
        }
    }
}