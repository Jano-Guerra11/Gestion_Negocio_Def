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
            if (validarCredenciales())
            {
                crearVariablesSession();
                UsuarioValido = true;
                if (chbxRecordarme.Checked)
                {
                    crearCookies();
                }            
            }
            return UsuarioValido;
        }
        public bool validarCredenciales()
        {
            var usuario = obtenerUsuarioConDatosDeLogin();
            var negocio = obtenerNegocioConDatosDeLogin();
            var negXus = obtenerNegXusuarios(usuario,negocio);
            return (ExisteUsuario(usuario) && ExisteNegocio(negocio) && ExisteNegXusu(negXus)) ? true : false;
        }
        public Usuarios obtenerUsuarioConDatosDeLogin()
        {
            NegocioUsuarios neg = new NegocioUsuarios();
            Usuarios usuario = new Usuarios();
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Contrasenia = txtPassword.Text;
            usuario.IdUsuario = neg.obtenerID(usuario);
            return usuario;
        }
        public NegocioC obtenerNegocioConDatosDeLogin()
        {
            NegocioC negocio = new NegocioC();
            negocio.NombreNegocio = txtNombreNegocio.Text;
            return negocio;
        }
        public NegociosXUsuarios obtenerNegXusuarios(Usuarios usuario,NegocioC negocio)
        {
            return new NegociosXUsuarios
            {
                IdUsuario = usuario.IdUsuario,
                IdNegocio = new NegocioNegocios().obtenerID(negocio.NombreNegocio)
            };
        }
        public bool ExisteUsuario(Usuarios usuario)
        {
            NegocioUsuarios neg = new NegocioUsuarios();
            return neg.existeUsuario(usuario);
        }
        public bool ExisteNegocio(NegocioC negocio)
        {
            NegocioNegocios neg = new NegocioNegocios();
            return neg.existeNegocio(negocio);
        }
        public bool ExisteNegXusu(NegociosXUsuarios nXu)
        {
            NegocioNxU neg = new NegocioNxU();
            return neg.existeNxU(nXu);
        }
        public void crearVariablesSession()
        {
            NegocioUsuarios negUs = new NegocioUsuarios(); 
            var negocio = obtenerNegocioConDatosDeLogin();
            var usuario = obtenerUsuarioConDatosDeLogin();
            var negXus = obtenerNegXusuarios(usuario,negocio);

            Session["idNegocio"] = negocio.IdNegocio;
            Session["rolUsuario"] = negUs.obtenerRolDelUsuario(usuario.IdUsuario);
            Session["nombreUsuario"] = usuario.NombreUsuario;
            Session["nombreNegocio"] =negocio.NombreNegocio;
        }
        public void crearCookies()
        {
            Usuarios usuario = obtenerUsuarioConDatosDeLogin();
            NegocioC negocio = obtenerNegocioConDatosDeLogin();

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