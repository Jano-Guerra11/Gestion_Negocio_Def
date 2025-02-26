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
            fileUpload();
            cargarGridLuegoBorrar();


            if (!IsPostBack)
            {
               // Image1.ImageUrl = "/ryzen3 3200G.png";
            }
        }

        public void cargarGridLuegoBorrar()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-UJD6JDV\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True");
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Productos",cn);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"productos");
            grdProductos.DataSource = ds.Tables["productos"];
            grdProductos.DataBind();
            cn.Close();
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
            btnGuardarImagen.Visible=false;
                imgProducto.Visible=true;
            }
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
    }
    
}