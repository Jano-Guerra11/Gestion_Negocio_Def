﻿using Negocio;
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

namespace gestion_de_negocio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                validarUsuario();
                fileUpload();
                cargarGridProductos();
            }
        }
        public void validarUsuario()
        {

            if (Request.Cookies["nombreUsuario"] != null &&
                Request.Cookies["ContrasenaUsuario"] != null &&
                Request.Cookies["negocio"] != null)
            {
                //usuario valido
                lblUsuarioIniciado.Text = "Usuario: " + Request.Cookies["nombreUsuario"].Value;
                lblNegocioIniciado.Text = "Negocio: " + Request.Cookies["negocio"].Value;
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void fileUpload()
        {
            
            if (imgProducto.ImageUrl=="")
            {
                flUpProducto.Visible = true;
                btnGuardarImagen.Visible = true;
                imgProducto.Visible = false;
            }
            else { flUpProducto.Visible = false;
                btnGuardarImagen.Visible=false;
                imgProducto.Visible=true;
            }
        }
        public void cargarGridProductos()
        {
            string nombreNegocio = Request.Cookies["negocio"].Value;
            NegocioProductos negProd = new NegocioProductos();
            grdProductos.DataSource = negProd.obtenerTablaProductosDeUnNegocio(nombreNegocio);
            grdProductos.DataBind();
        }


        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

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

        protected void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            if (flUpProducto.HasFile)
            {
                //obtengo la extension 
                string extension = Path.GetExtension(flUpProducto.FileName).ToLower();
                string[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".gif" };
                // comparo la extension con las validas
                bool valida = extensionesValidas.Any(ex => ex == extension);
                if (valida)
                {
                    // Creo la ruta absoluta en el servidor usando Server.MapPath
                    string carpetaDestino = Server.MapPath("~/imagenes/"); // Ruta física completa

                    string rutaCompleta = Path.Combine(carpetaDestino, flUpProducto.FileName);
                    flUpProducto.SaveAs(rutaCompleta);

                    imgProducto.ImageUrl = "/imagenes/"+flUpProducto.FileName;
                   fileUpload();
                    // guardar la ruta en la base de datos
                    Debug.WriteLine("ruta de la imagen ---> " + imgProducto.ImageUrl);
                }
            }
        }
        

        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregarSeccion_Click(object sender, EventArgs e)
        {
            agregarAlDdl((Button)sender,txtNuevaSeccion,ddlSeccion);
        }

        public void agregarAlDdl(Button btn,TextBox txt,DropDownList ddl)
        {
            if(btn.Text == "+")
            {
                btn.Text = "Agregar";
                txt.Visible = true;
            }
            else
            {
                btn.Text = "+";
                txt.Visible = false;
                ListItem item = new ListItem(txt.Text, txt.Text);
                if (!yaExiste(item,ddl))
                {
                ddl.Items.Add(item);
                }
                txt.Text = string.Empty;
            }
            // agregar seccion a BD para luego al cargar la paginas se carguen las secciones correctas
        }
        public bool yaExiste(ListItem item,DropDownList ddl)
        {
            bool existe = false;
            foreach(ListItem li in ddl.Items)
            {
                if(li.Text == item.Text)
                {
                    existe = true;
                }
            }
            return existe;
        }

        protected void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            agregarAlDdl((Button)sender, txtNuevoTipo, ddlCategorias);
        }

        protected void btnMostrarFiltrado_Click(object sender, EventArgs e)
        {
           
        }

        protected void grdProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdProductos_DataBound(object sender, EventArgs e)
        {
         
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NegocioProductos negProd = new NegocioProductos();
            int idProducto = negProd.obtenerIdDelProducto(txtNombre.Text);
            int accionRealizada = 0;

            int.TryParse(ddlSecciones.SelectedValue, out int idSeccion);
            int.TryParse(txtPrecio.Text, out int precio);
            int.TryParse(txtStock.Text, out int stock);

            bool accionExitosa = false;

            if (idProducto == -1)
            {
                accionExitosa = negProd.altaProducto(txtNombre.Text, idSeccion,
                    txtDescripcion.Text,precio, stock, imgProducto.ImageUrl);
                // alta productos x negocios
                // incluir un ddl con los proveedores, poder agregar proveedor al igual que seccion
                // alta productos x proveedores
                
                   accionRealizada = accionExitosa? 1 : 0;
            }
            else
            {
                accionExitosa = negProd.modificarProducto(txtNombre.Text, idSeccion,
                    txtDescripcion.Text,precio, stock, imgProducto.ImageUrl);
                
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
    }
    
}