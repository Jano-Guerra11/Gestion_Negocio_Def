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
                cargarGridUsuarios();
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
        public void cargarGridUsuarios()
        {
            NegocioPerXUsu negPxU = new NegocioPerXUsu();
            DataTable tabla = negPxU.tablaPermisosDeCadaUsuario();
            Debug.WriteLine("------yo-------------" + tabla.Rows.Count);
            grdUsuarios.DataSource = tabla;
            grdUsuarios.DataBind();
        }
        protected void grdUsuarios_DataBound(object sender,EventArgs e)
        {
            Debug.WriteLine("-------------------" + grdUsuarios.Rows.Count);
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
                Label lblidUsuario = (Label)e.Row.FindControl("lbl_it_idUsuario");
                Debug.WriteLine("---------------" + idEnString);
                lblidUsuario.Text = idEnString;
            }
        }
    }
}
