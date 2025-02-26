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
           
            // conseguimos la info que genero la funcion __doPostBack
            string idDelControl = Request["__EVENTTARGET"];
            string accion = Request["__EVENTARGUMENT"];
            Debug.WriteLine("--<> "+idDelControl);
            Debug.WriteLine("--<> " + accion);
           
        }
       
    }
}