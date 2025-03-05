using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_de_negocio
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
           
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            if (Session["rolUsuario"].ToString() == "administrador")
            {
                Response.Redirect("administracionDeUsuarios.aspx");
            }
        }
    }
}