using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_de_negocio
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                validarUsuario();
            }
        }
        protected void btnProductos_Click(object sender, EventArgs e)
        {
            validarAccesoA_productos();
        }
        private void validarAccesoA_productos()
        {
            NegocioPerXUsu negPerXus = new NegocioPerXUsu();
            if (negPerXus.usuarioTienePermiso(cargarPermisosXusuario(1)))
            {
                Response.Redirect("VistaProductos.aspx");
            }
        }
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            validarAccesoA_administracion();
        }
        private void validarAccesoA_administracion()
        {
            NegocioPerXUsu negPerXus = new NegocioPerXUsu();
            if (negPerXus.usuarioTienePermiso(cargarPermisosXusuario(5)))
            {
                Response.Redirect("AdministracionDeUsuarios.aspx");
            }

        }
        private permisosXusuarios cargarPermisosXusuario(int idPermiso)
        {
            permisosXusuarios permisosXusuarios = new permisosXusuarios();
            permisosXusuarios.IdUsuario_perXus = Convert.ToInt32(Session["idUsuario"]);
            permisosXusuarios.IdPermiso_perXus = idPermiso;
            return permisosXusuarios;
        }

        public void validarUsuario()
        {
            if (!validarCookiesUsuarioRecordado() &&
                !validarSessionsIniciadoNoRecordado())
            {
                //usuario no inicado ni recordado
                Response.Redirect("login.aspx");
            }
            else if(!validarSessionsIniciadoNoRecordado())
            {
               // el usuario no paso por el login(osea esta recordado), entonces....  
                crearVariablesSesion();
            }
        }
        private void crearVariablesSesion()
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            NegocioNegocios negNeg = new NegocioNegocios();
            string nombreUsuario = Request.Cookies["nombreUsuario"].Value;
            string contraseña = Request.Cookies["ContrasenaUsuario"].Value;
            string nombreNegocio = Request.Cookies["negocio"].Value;
            
            Session["idNegocio"] = negNeg.obtenerID(nombreNegocio);
            Session["idUsuario"] = negUs.obtenerID(nombreUsuario,contraseña);
            Session["nombreUsuario"] = nombreUsuario;
            Session["nombreNegocio"] = nombreNegocio;
       }

        private bool validarCookiesUsuarioRecordado()
        {
            bool recordado = false;
            if (Request.Cookies["nombreUsuario"] != null &&
                Request.Cookies["ContrasenaUsuario"] != null &&
                Request.Cookies["negocio"] != null)
            {
                string nombreUsuario = Request.Cookies["nombreUsuario"].Value;
                string nombreNegocio = Request.Cookies["negocio"].Value;

                lblUsuarioIniciado.Text = "Usuario: " + nombreUsuario;
                lblNegocioIniciado.Text = "Negocio: " + nombreNegocio;
                Session["nombreNegocio"] = nombreNegocio;
                recordado = true;
            }
            return recordado;
        }
        private bool validarSessionsIniciadoNoRecordado()
        {
            bool iniciadoNoRecordado = false;
            if (Session["nombreUsuario"] != null && Session["nombreNegocio"] != null)
            {
                string UsuarioIniciado = Session["nombreUsuario"].ToString();
                string NegocioIniciado = Session["nombreNegocio"].ToString();

                lblUsuarioIniciado.Text = "Usuario: " + UsuarioIniciado;
                lblNegocioIniciado.Text = "Negocio: " + NegocioIniciado;
                iniciadoNoRecordado = true;
            }
            return iniciadoNoRecordado;
        }

       
    }
}