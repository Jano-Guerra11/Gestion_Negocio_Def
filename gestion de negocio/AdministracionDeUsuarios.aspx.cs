using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using System.Diagnostics;

namespace gestion_de_negocio
{
    public partial class Administracion : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDlNegocios();
                cargarDdlRoles();
                cargarGridUsuarios();
            }
        }

        public void cargarDDlNegocios()
        {
            NegocioNegocios negNeg = new NegocioNegocios();
            DataTable dt = negNeg.obtenerTablaNegocios();
            ddlNegociosRegistrados.Items.Clear();
            ddlNegociosRegistrados.DataSource = dt;
            ddlNegociosRegistrados.DataTextField = "nombre_n";
            ddlNegociosRegistrados.DataValueField = "idNegocio_n";
            ddlNegociosRegistrados.DataBind();
            ddlNegociosRegistrados.Items.Add(new ListItem("", "0"));
            ddlNegociosRegistrados.SelectedValue = "0";
        }
        public void cargarGridUsuarios()
        {
            NegocioPerXUsu negPxU = new NegocioPerXUsu();
            DataTable tabla = negPxU.tablaPermisosDeCadaUsuario();
           
            grdUsuarios.DataSource = tabla;
            Debug.WriteLine("Datos cargados: " + tabla.Rows.Count);
            grdUsuarios.DataBind();
        }
        public void cargarDdlRoles()
        {
            NegocioRoles negRol = new NegocioRoles();
            DataTable tablaRoles = new DataTable();
            ddlRoles.Items.Clear();
            ddlRoles.DataSource = tablaRoles;
            ddlRoles.DataBind();
            ddlRoles.DataTextField = "nombre_r";
            ddlRoles.DataValueField = "idRol_r";
            ddlRoles.Items.Add(new ListItem("", "0"));
            ddlRoles.SelectedValue = "0";
        }
        protected void grdUsuarios_DataBound(object sender,EventArgs e)
        {
            if (grdUsuarios.Rows.Count == 0)
            {
               
                TableCell celda = new TableCell();
                celda.Text = "No hay datos Disponibles";
                celda.ColumnSpan = grdUsuarios.Columns.Count;
                celda.HorizontalAlign = HorizontalAlign.Center;

                GridViewRow row = new GridViewRow(0,0,DataControlRowType.DataRow,DataControlRowState.Normal);
                row.Cells.Add(celda);
                grdUsuarios.Controls[0].Controls.Add(row);
            }
        }

        protected void grdUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                int idEnInt = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idUsuario_Us"));
                string idEnString = idEnInt.ToString();
                Label lblId = (Label)e.Row.FindControl("lbl_it_IdUsuario");
                lblId.Text = idEnString;    

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
            if (!negNeg.altaNegocio(txtNuevoNegocio.Text))
            {
                lblMensajeErrorAgregarNegocio.Text = "Negocio existente";
            }
            else
            {
                lblMensajeErrorAgregarNegocio.Text = string.Empty;
                cargarDDlNegocios();
                txtNuevoNegocio.Text = string.Empty;
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

        }

        protected void ddlNegociosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
