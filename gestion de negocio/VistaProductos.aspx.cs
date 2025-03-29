using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace gestion_de_negocio
{
    public partial class VistaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                validarUsuario();
                fileUpload();
                cargarGridProductos();
                cargarDdlProveedores("0");
                cargarDdlSecciones("0");
            }
        }
        public void validarUsuario()
        {
            if (!validarCookiesUsuarioRecordado() &&
                !validarSessionsIniciadoNoRecordado())
            {
                //usuario no inicado ni recordado
                Response.Redirect("login.aspx");
            }
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
        public void fileUpload()
        {

            if (imgProducto.ImageUrl == "")
            {
                flUpProducto.Visible = true;
                btnGuardarImagen.Visible = true;
                imgProducto.Visible = false;
            }
            else { flUpProducto.Visible = false;
                btnGuardarImagen.Visible = false;
                imgProducto.Visible = true;
            }
        }
        public void cargarDdlProveedores(string idProvSeleccionado)
        {

            NegocioProveedores negProv = new NegocioProveedores();
            DataTable proveedores = negProv.obtenerTodosLosProveedores();
            ddlProveedores.Items.Clear();
            ddlProveedores.DataSource = proveedores;
            ddlProveedores.DataTextField = "nombre_prov";
            ddlProveedores.DataValueField = "idProveedor_prov";
            ddlProveedores.DataBind();
            ddlProveedores.SelectedValue = idProvSeleccionado;// tiene que ser el proveedor asignado
        }
        public void cargarDdlSecciones(string idSeccionSeleccionada)
        {
            NegocioSecciones negSec = new NegocioSecciones();
           int idNegocio = obtenerIdNegocioIniciado();
            DataTable secciones = negSec.obtenerTablaSecciones(idNegocio);
            ddlSecciones.Items.Clear();
            ddlSecciones.DataSource = secciones;
            ddlSecciones.DataTextField = "nombre_sec";
            ddlSecciones.DataValueField = "idSeccion_sec";
            ddlSecciones.DataBind();
            ddlSecciones.SelectedValue = idSeccionSeleccionada;
        }
        private int obtenerIdNegocioIniciado()
        {
            NegocioNegocios Neg = new NegocioNegocios();
            return Neg.obtenerID(Session["nombreNegocio"].ToString());
        }
        public void cargarGridProductos()
        {
            string nombreNegocio = Session["nombreNegocio"].ToString();
            NegocioProductos negProd = new NegocioProductos();
            grdProductos.DataSource = negProd.obtenerTablaProductosDeUnNegocio(nombreNegocio);
            grdProductos.DataBind();
        }
        protected void btnEsconder_Click(object sender, EventArgs e)
        {
            mostrarYesconderAlta();
        }
        public void mostrarYesconderAlta()
        {
            if (btnEsconder.Text == "<")
            {
                pnlContenedor.CssClass = "contenedor_Productos-esconderAlta";
                btnEsconder.Text = ">";

            }
            else
            {
                pnlContenedor.CssClass = "contenedor_Productos";
                btnEsconder.Text = "<";
            }
        }
      //---------------------------------------------------------------------------------------
        protected void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            if (flUpProducto.HasFile)
            {
                string extension = obtenerExtensionDelArchivo();
                
                if (extensionValida(extension))
                {
                    crearYguardarRutaDeLaImagen();
                    cargarImagen();
                }
            }
        }
        private string obtenerExtensionDelArchivo()
        {
            return Path.GetExtension(flUpProducto.FileName).ToLower();
        }
        private bool extensionValida(string extension)
        {
            string[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".gif" };
            bool valida = extensionesValidas.Any(ex => ex == extension);
            return valida;
        }
        private void crearYguardarRutaDeLaImagen()
        {
            // Creo la ruta absoluta en el servidor usando Server.MapPath
            string carpetaDestino = Server.MapPath("~/imagenes/"); // Ruta física completa

            string rutaCompleta = Path.Combine(carpetaDestino, flUpProducto.FileName);
            flUpProducto.SaveAs(rutaCompleta);
        }
        private void cargarImagen()
        {
            imgProducto.ImageUrl = "/imagenes/" + flUpProducto.FileName;
            fileUpload();
        }
       //----------------------------------------------------------------------------------------
        protected void btnAgregarSeccion_Click(object sender, EventArgs e)
        {
            if(btnAgregarSeccion.Text == "+")
            {
                btnAgregarSeccion.Text = "Agregar";
                txtNuevaSeccion.Visible = true;
                lblMensajeAltaSeccion.Text = "";
            }
            else
            {
                btnAgregarSeccion.Text = "+";
                txtNuevaSeccion.Visible= false;

                bool alta = agregarNuevaSeccion();
                procesarResultadoDeAltaSeccion(alta);
            }
        }
        private bool agregarNuevaSeccion()
        {
            NegocioSecciones negSec = new NegocioSecciones();
            NegocioNegocios neg = new NegocioNegocios();
            int idNegocio = obtenerIdNegocioIniciado();
            return negSec.altaSeccion(txtNuevaSeccion.Text, idNegocio);
        }
        private void procesarResultadoDeAltaSeccion(bool resultadoDeLaAccion)
        {
            NegocioSecciones negSec = new NegocioSecciones();
            if(resultadoDeLaAccion)
            {
                lblMensajeAltaSeccion.Text = "Agregada";
                string idNuevaSec = negSec.obtenerIdSeccion(txtNuevaSeccion.Text).ToString();
                cargarDdlSecciones(idNuevaSec);
            }
            else lblMensajeAltaSeccion.Text = "No se pudo agregar";

        }

      //---------------------------------------------------------------------------------------
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NegocioNegocios negneg = new NegocioNegocios();
            NegocioProductos negProd = new NegocioProductos();
            NegocioProdXProv negProdXProv = new NegocioProdXProv();
           
            int idProducto = negProd.obtenerIdDelProducto(txtNombre.Text);
            bool accionExitosa = false;
            int accionRealizada = 0;
            int idNegocioIniciado = obtenerIdNegocioIniciado();
          
            int.TryParse(ddlSecciones.SelectedValue, out int idSeccion);
            int.TryParse(txtPrecio.Text, out int precio);
            int.TryParse(txtStock.Text, out int stock);
            int.TryParse(ddlProveedores.SelectedValue, out int idProveedor);
            
            // primero cargo el objeto y despues verifico si existe o no 
            if (idProducto == -1)
            {
                
                accionExitosa = negProd.altaProducto(txtNombre.Text, idSeccion,
                    txtDescripcion.Text,precio, stock, imgProducto.ImageUrl,idNegocioIniciado);

                int nuevoIdProducto = negProd.obtenerIdDelProducto(txtNombre.Text);
                accionExitosa = negProdXProv.altaProductoXProveedor(idProveedor,nuevoIdProducto,idNegocioIniciado);
                
                   accionRealizada = accionExitosa? 1 : 0;
            }
            else
            {
                accionExitosa = negProd.modificarProducto(txtNombre.Text, idSeccion,
                    txtDescripcion.Text,precio, stock, imgProducto.ImageUrl);
                //if(idProveedor != )
                // modificar producto xproveedor tambien 
                
                
                   accionRealizada = accionExitosa? 2 : 0;  
            }

            switch (accionRealizada)
            {
                case 1:
                    lblMensajeAltaObaja.Text = "Producto agregado correctamente";
                    break;
                case 2:
                    lblMensajeAltaObaja.Text = "Producto modificado correctamente";
                    break;
                default:
                    lblMensajeAltaObaja.Text = "ERROR no se pudo completar la acción";
                    break;
            }
            cargarGridProductos();

        }
        private Productos crearProductoRegistrado()
        {
            Productos prodNuevo = new Productos();
            NegocioProductos negProd = new NegocioProductos();
            prodNuevo.IdProducto_pr = negProd.obtenerIdDelProducto(txtNombre.Text);

            
        }
      // ----------------------------------------------------------------------------------------
        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if(btnAgregarProveedor.Text == "Agregar Proveedor")
            {
                btnAgregarProveedor.Text = "Guardar Proveedor";
                txtNombreProv.Visible = true;
                txtRazonSocialProv.Visible = true;
                txtTelefonoProv.Visible = true;
                txtMailProv.Visible = true;
            }
            else
            {
                NegocioProveedores negProv = new NegocioProveedores();
                NegocioNegocios neNeg = new NegocioNegocios();
                int idNegocio = neNeg.obtenerID(Session["nombreNegocio"].ToString());

                if (negProv.altaProveedor(idNegocio,txtNombreProv.Text,txtRazonSocialProv.Text,
                    txtTelefonoProv.Text,txtMailProv.Text))
                {
                    btnAgregarProveedor.Text = "Agregar Proveedor";
                    txtNombreProv.Visible = false;
                    txtRazonSocialProv.Visible = false;
                    txtTelefonoProv.Visible = false;
                    txtMailProv.Visible = false;
                    lblMensajeErrorAgregarProveedor.Text = "Proveedor cargado";
                }
                else { lblMensajeErrorAgregarProveedor.Text = "Error"; }
            }
                    
        }
    }
    
}