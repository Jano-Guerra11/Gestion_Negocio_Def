using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_de_negocio
{
    public partial class registracion : System.Web.UI.Page
    {
        /*poner required fields validators*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDlNegocios();
            }
        }

        public void cargarDDlNegocios()
        {
            NegocioNegocios negNeg = new NegocioNegocios();
            DataTable dt = negNeg.obtenerTablaNegocios();
            ddlNegociosRegistrados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = dr["nombre_n"].ToString();
                item.Value = dr["idNegocio_n"].ToString();
                ddlNegociosRegistrados.Items.Add(item);
            }
        }

        protected void lbVolverALogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void cvNombreUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            if (negUs.existeNombreUsuario(args.Value))
            {
                args.IsValid = false;
            }
            else { args.IsValid = true; }           
        }

        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {
            NegocioNegocios negNeg = new NegocioNegocios();
            NegocioProveedores negPRov = new NegocioProveedores();
            NegocioSecciones negSec = new NegocioSecciones();

            string nombreNuevoNegocio = txtNuevoNegocio.Text;
            if (!negNeg.altaNegocio(nombreNuevoNegocio))
            {
                lblMensajeErrorAgregarNegocio.Text = "Negocio existente";
            }
            else
            {    // negocio creado 
                lblMensajeErrorAgregarNegocio.Text = string.Empty;
                cargarDDlNegocios();
               int idNeg = negNeg.obtenerID(nombreNuevoNegocio);
                // doy de alta el proveedor por defecto
                negPRov.altaProveedor(idNeg,"sin proveedor","-","-","-");
                // doy de alta la seccion predeterminada
                negSec.altaSeccion("sin seccion",idNeg);
               
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

        }
    }
}