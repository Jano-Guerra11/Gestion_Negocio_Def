using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using System.Diagnostics;
using Entidades;

namespace gestion_de_negocio
{
    public partial class Administracion : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                validarUsuario();
                cargarDDlNegocios();
                cargarDdlRoles();
                cargarGridUsuarios();
            }
        }
        public void validarUsuario()
        {
           
            if(Request.Cookies["nombreUsuario"] !=null &&
                Request.Cookies["ContrasenaUsuario"] !=null &&
                Request.Cookies["negocio"]!=null)
            {
                //usuario valido
                lblUsuarioIniciado.Text = "Usuario: "+ Request.Cookies["nombreUsuario"].Value;
                lblNegocioIniciado.Text = "Negocio: " + Request.Cookies["negocio"].Value;
            }
            else
            {
                Response.Redirect("login.aspx");
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
            string nombreNegocio = Request.Cookies["negocio"].Value;
            NegocioPerXUsu negPxU = new NegocioPerXUsu();
            DataTable tabla = negPxU.tablaPermisosDeCadaUsuario(nombreNegocio);         
            grdUsuarios.DataSource = tabla;         
            grdUsuarios.DataBind();
        }
        public void cargarDdlRoles()
        {
            NegocioRoles negRol = new NegocioRoles();
            DataTable tablaRoles = negRol.obtenerRoles();
            ddlRoles.Items.Clear();
            ddlRoles.DataSource = tablaRoles;
            ddlRoles.DataTextField = "nombre_r";
            ddlRoles.DataValueField = "idRol_r";
            ddlRoles.DataBind();
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
            Debug.WriteLine("--- pase pasew");
            if (negUs.existeNombreUsuario(args.Value))
            {
                args.IsValid = false;
            }
            else { args.IsValid = true; }
        }

        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {
            NegocioNegocios negNeg = new NegocioNegocios();
            if(txtNuevoNegocio.Text != "")
            {
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
            else { lblMensajeErrorAgregarNegocio.Text = "no se permiten espacios en blanco"; }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            NegocioNxU negNXu = new NegocioNxU();
            Usuarios nuevoUsuario = new Usuarios();
            NegociosXUsuarios negXusu = new NegociosXUsuarios();

            nuevoUsuario.NombreUsuario = txtUNRegistro.Text;
            nuevoUsuario.Contrasenia = txtPassword2.Text;
            nuevoUsuario.RolUsuario = Convert.ToInt32(ddlRoles.SelectedValue);
            nuevoUsuario.IdUsuario = negUs.obtenerNuevoId();
            negXusu.IdUsuario = nuevoUsuario.IdUsuario;
            negXusu.IdNegocio = Convert.ToInt32(ddlNegociosRegistrados.SelectedValue);

            if (negUs.altaUsuario(nuevoUsuario) && negNXu.altaNegXUsu(negXusu)
                && darDeAltaTodosLosPermisosDelUsuario(nuevoUsuario.IdUsuario, nuevoUsuario.RolUsuario))
            {
                // usuario y sus permisos cargador correctamente
            } 
           
        }
        public bool darDeAltaTodosLosPermisosDelUsuario(int idUsuario, int idRol)
        {
            int contadorDeAltas = 0;
            bool alta = false;
            NegocioRolesXpermisos negRolXPer = new NegocioRolesXpermisos();
            DataTable permisosDelRol = negRolXPer.tablaDePermisosSegunRol(idRol);
            
            permisosXusuarios perXus = new permisosXusuarios();
            NegocioPerXUsu negPerXus = new NegocioPerXUsu();

            foreach(DataRow dr in permisosDelRol.Rows)
            {
                if(negPerXus.altaUnPermisoDelUsuario(idUsuario, Convert.ToInt32(dr["idPermiso_rxp"]),
                    dr["tienePermiso_rxp"].ToString()))
                {
                    contadorDeAltas += 1;
                }
            }
            if(contadorDeAltas == permisosDelRol.Rows.Count)
            {
                alta = true;
            }
            return alta;
        }

        protected void ddlNegociosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void btn_it_Admin_Click(object sender, EventArgs e)
        {
            modificarPermiso(sender,"Administracion");
        }

        protected void btn_it_Reportes_Click(object sender, EventArgs e)
        {
            modificarPermiso(sender, "Reportes");
        }

        protected void btn_it_Ventas_Click(object sender, EventArgs e)
        {
            modificarPermiso(sender, "Ventas");
        }

        protected void btn_it_Inventario_Click(object sender, EventArgs e)
        {
            modificarPermiso(sender, "Inventario");
        }

        protected void btn_it_Productos_Click(object sender, EventArgs e)
        {
            modificarPermiso(sender, "Productos");
        }
        public void modificarPermiso(object sender,string nombreDelPermiso)
        {
            NegocioPermisos negPer = new NegocioPermisos();
            NegocioPerXUsu negPxU = new NegocioPerXUsu();
            Button btn = (Button)sender;
            GridViewRow filaDelControl = (GridViewRow)btn.NamingContainer;
            int idDelUsuario = Convert.ToInt32(((Label)filaDelControl.FindControl("lbl_it_idUsuario")).Text);
            int idDelPermiso = negPer.obtenerIdPorNombre(nombreDelPermiso);

            if (btn.Text == "SI")
            {
                negPxU.modificarUnPermisoDelUsuario(idDelPermiso, idDelUsuario, "false");
            }
            else
            {
                negPxU.modificarUnPermisoDelUsuario(idDelPermiso, idDelUsuario, "true");
            }
            cargarGridUsuarios();
        }

        protected void ddl_it_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // modificar rol 
        }
    }
}
