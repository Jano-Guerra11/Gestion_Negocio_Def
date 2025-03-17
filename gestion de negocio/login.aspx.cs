using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            if (!IsPostBack)
            {
                llenarDatosDeInicio();
            }    
        }
        public void llenarDatosDeInicio()
        {
            HttpCookie ckNombre = Request.Cookies["nombreUsuario"];
            HttpCookie ckContrasena = Request.Cookies["contrasenaUsuario"];
            HttpCookie ckNegocio = Request.Cookies["negocio"];
            if (ckNombre != null && ckContrasena != null && ckNegocio != null)
            {
                txtNombreUsuario.Text = ckNombre.ToString();
                txtPassword.Text = ckContrasena.ToString();
                txtNombreNegocio.Text = ckNegocio.ToString();
            }
        }
        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarOcultarContrasena();
        }
        public void mostrarOcultarContrasena()
        {
            string contenido = txtPassword.Text;
            if (btnMostrar.Text == "Mostrar")
            {
                ViewState["password"] = txtPassword.Text;
                txtPassword.TextMode = TextBoxMode.SingleLine;
                btnMostrar.Text = "Ocultar";
                txtPassword.Attributes["value"] = contenido;
            }
            else
            {
                ViewState["password"] = txtPassword.Text;
                txtPassword.TextMode = TextBoxMode.Password;
                btnMostrar.Text = "Mostrar";
                txtPassword.Attributes["value"] = contenido;

            }
        }
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (iniciarSesion())
            {
                Response.Redirect("Menu.aspx");
            }
            else { lblMensajeDeInicio.Text = " No se pudo iniciar sesion. Usuario Incorrecto";}
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
            usuarios.IdUsuario = negocioUsuarios.obtenerID(usuarios);
            negocio.NombreNegocio = txtNombreNegocio.Text;
            NxU.IdUsuario = negocioUsuarios.obtenerID(usuarios); 
            NxU.IdNegocio = negNeg.obtenerID(negocio);

            if (negocioUsuarios.existeUsuario(usuarios) &&
              negNeg.existeNegocio(negocio) && negNxU.existeNxU(NxU))
            {
                UsuarioValido = true;
                Session["idNegocio"] = NxU.IdNegocio;
                Session["rolUsuario"] = negocioUsuarios.obtenerRolDelUsuario(NxU.IdUsuario);
                Session["nombreUsuario"] = txtNombreUsuario.Text;
                Session["nombreNegocio"] = txtNombreNegocio.Text;

                if (chbxRecordarme.Checked)
                {
                    crearCookies(usuarios,negocio);
                }
                
            }
            return UsuarioValido;
        }
        public void crearCookies(Usuarios usuario,NegocioC negocio )
        {
            HttpCookie ckUsuario = new HttpCookie("nombreUsuario",usuario.NombreUsuario);
            ckUsuario.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(ckUsuario);
            HttpCookie ckContrasena = new HttpCookie("ContrasenaUsuario",usuario.Contrasenia);
            ckContrasena.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(ckContrasena);
            HttpCookie ckNegocio = new HttpCookie("negocio",negocio.NombreNegocio);
            ckNegocio.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(ckNegocio);
        }
    }
}