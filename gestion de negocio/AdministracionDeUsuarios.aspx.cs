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
using System.Threading;
using System.Drawing;

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
            if(Request.Cookies["nombreUsuario"] != null &&
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
            if(Session["nombreUsuario"] != null && Session["nombreNegocio"] != null)
            {
                string UsuarioIniciado = Session["nombreUsuario"].ToString();
                string NegocioIniciado = Session["nombreNegocio"].ToString();

                lblUsuarioIniciado.Text = "Usuario: " + UsuarioIniciado;
                lblNegocioIniciado.Text = "Negocio: " + NegocioIniciado;
                iniciadoNoRecordado = true;
            }
            return iniciadoNoRecordado;
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
                grdUsuarios.Controls[0].Controls.Add(crearFilaVaciaDeGridView());
            }
        }
        private GridViewRow crearFilaVaciaDeGridView()
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.Cells.Add(crearCeldaSinDatos());
            return row;
        }
        private TableCell crearCeldaSinDatos()
        {
            TableCell celda = new TableCell();
            celda.Text = "No hay datos Disponibles";
            celda.ColumnSpan = grdUsuarios.Columns.Count;
            celda.HorizontalAlign = HorizontalAlign.Center;
            return celda;
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
        //-------------------------------------------------------------------------------
        protected void btnAgregarNegocio_Click(object sender, EventArgs e)
        {           
            if(!esValidoElNombre(txtNuevoNegocio.Text))
            {
                mensajeErrorEnAltaNegocio("no se permiten espacios en blanco");
                return;
            }

            if (!crearNegocio(txtNuevoNegocio.Text))
            {
                mensajeErrorEnAltaNegocio("Negocio existente");
                return;
            }

            procesarNegocioNuevo();
        }
        private bool esValidoElNombre(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre);
        }
        private bool crearNegocio(string nombreNuevoNegocio)
        {
            NegocioNegocios negNeg = new NegocioNegocios();
            return negNeg.altaNegocio(nombreNuevoNegocio);
        }
        private void mensajeErrorEnAltaNegocio(string mensaje)
        {
            lblMensajeErrorAgregarNegocio.Text = mensaje;
        }
        private void procesarNegocioNuevo()
        {
            lblMensajeErrorAgregarNegocio.Text = string.Empty;
            cargarDDlNegocios();
            txtNuevoNegocio.Text = string.Empty;
           
           
           
        }
      // -------------------------------------------------------------------------------
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Usuarios nuevoUsuario = crearCargarObjetoUsuario();
            NegociosXUsuarios negXusu = crearCargarNegXus(nuevoUsuario.IdUsuario);

            if (crearUsuarioAsignarNegocio(nuevoUsuario,negXusu) &&
                darDeAltaTodosLosPermisosDelUsuario(nuevoUsuario.IdUsuario, nuevoUsuario.RolUsuario))
            {                    
                   lblConfirmacionRegistro.Text = "usuario registrado";
                   cargarGridUsuarios();    
            } 
           
        }
        private Usuarios crearCargarObjetoUsuario()
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            Usuarios nuevoUsuario = new Usuarios();
            int idNuevo = negUs.obtenerNuevoId();
            nuevoUsuario.NombreUsuario = txtUNRegistro.Text;
            nuevoUsuario.Contrasenia = txtPassword2.Text;
            nuevoUsuario.RolUsuario = Convert.ToInt32(ddlRoles.SelectedValue);
            nuevoUsuario.IdUsuario = idNuevo;
            return nuevoUsuario;
        }
        private NegociosXUsuarios crearCargarNegXus(int idNuevo)
        {
            NegociosXUsuarios negXusu = new NegociosXUsuarios();
            negXusu.IdUsuario = idNuevo;
            negXusu.IdNegocio = Convert.ToInt32(ddlNegociosRegistrados.SelectedValue);
            return negXusu;
        }
        private bool crearUsuarioAsignarNegocio(Usuarios usuario,NegociosXUsuarios nXu)
        {
            NegocioUsuarios negUs = new NegocioUsuarios();
            NegocioNxU negNxU = new NegocioNxU();
            if (negUs.altaUsuario(usuario) && negNxU.altaNegXUsu(nXu))
            {
                return true;
            }
            return false;
        }

        public bool darDeAltaTodosLosPermisosDelUsuario(int idUsuario, int idRol)
        {
           DataTable permisosDelRol = obtenerTablaConPermisosDelRol(idRol);
            return crearPermisosDelUsuario(idUsuario,permisosDelRol);
        }
        private DataTable obtenerTablaConPermisosDelRol(int idRol)
        {
            NegocioRolesXpermisos negRolXPer = new NegocioRolesXpermisos();
            return negRolXPer.tablaDePermisosSegunRol(idRol);
        } 
        private bool crearPermisosDelUsuario(int idUsuario,DataTable permisosDelRol)
        {
            NegocioPerXUsu negPerXus = new NegocioPerXUsu();
            bool accionExitosa = true;
            foreach (DataRow dr in permisosDelRol.Rows)
            {
                if (!negPerXus.altaUnPermisoDelUsuario(idUsuario, Convert.ToInt32(dr["idPermiso_rxp"]),
                    dr["tienePermiso_rxp"].ToString()))
                {
                    accionExitosa = false;
                }
            }
            return accionExitosa;
        }
      //--------------------------------------------------------------------------------

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
            Button btn = (Button)sender;    
            GridViewRow filaDelControl = obtenerFilaDesdeBoton(btn);
            int idDelUsuario = obtenerIdDesdeFila(filaDelControl);
            int idDelPermiso = obtenerIdDelPermiso(nombreDelPermiso);

            bool nuevoEstado = btn.Text != "SI";
            modificarUnPermisoDelUsuario(idDelUsuario,idDelPermiso,nuevoEstado);
            
            cargarGridUsuarios();
        }
        private GridViewRow obtenerFilaDesdeBoton(Button btn)
        {
            return (GridViewRow)btn.NamingContainer;
        }
        private int obtenerIdDesdeFila(GridViewRow filaDelControl)
        {
          return  Convert.ToInt32(((Label)filaDelControl.FindControl("lbl_it_idUsuario")).Text);
        }
        private int obtenerIdDelPermiso(string nombreDelPermiso)
        {
            NegocioPermisos negPer = new NegocioPermisos();
           return negPer.obtenerIdPorNombre(nombreDelPermiso);
        }
        private void modificarUnPermisoDelUsuario(int idUsuario,int idPermiso,bool estadoDelPermiso)
        {
            NegocioPerXUsu neg = new NegocioPerXUsu();
            neg.modificarUnPermisoDelUsuario(idUsuario,idPermiso,estadoDelPermiso.ToString());
        }
      //----------------------------------------------------------------------------------- 
        protected void ddl_it_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // modificar rol 
        }

        protected void btnAgregarRol_Click(object sender, EventArgs e)
        {
            string nombreRol = txtNombreRol.Text;
            if (!crearNuevoRol(nombreRol))
            {
                mensajeCreacionRol("No se pudo crear el rol", Color.Red);
                return;
            }
            if (!altaTodosLosPermisosDelRol(obtenerIdDelRol(nombreRol)))
            {
                mensajeCreacionRol("No se pudieron crear los permisos del rol", Color.Red);
                return;
            }
              cargarDdlRoles();
              mensajeCreacionRol("Rol creado correctamente",Color.Green);  
        }
        private bool crearNuevoRol(string nombre)
        {
            NegocioRoles negRoles = new NegocioRoles();
           return negRoles.altaRol(nombre);
        }
        private int obtenerIdDelRol(string nombreRol)
        {
            NegocioRoles negRoles = new NegocioRoles();
          return negRoles.obtenerIdRol(nombreRol);
        }
        private void mensajeCreacionRol(string mensaje,Color color)
        {
            lblMensajeRol.ForeColor = color;
            lblMensajeRol.Text = "Rol creado correctamente";
            txtNombreRol.Text = string.Empty;
        }
        public bool altaTodosLosPermisosDelRol(int idRol)
        {
            NegocioRolesXpermisos negRxP = new NegocioRolesXpermisos();
            string[] permisos = { "Productos", "Inventario", "Ventas", "Reportes", "Administracion" };

            int permisosAsignados = AsignarPermisosAlRol(negRxP, idRol, permisos);

            return permisosAsignados == permisos.Length;
        }

        private int AsignarPermisosAlRol(NegocioRolesXpermisos negRxP, int idRol, string[] permisos)
        {
            int count = 0;
            for (int i = 0; i < permisos.Length; i++)
            {
                if (AsignarPermiso(negRxP, idRol, i + 1, permisos[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private bool AsignarPermiso(NegocioRolesXpermisos negRxP, int idRol, int idPermiso, string nombrePermiso)
        {
            CheckBox checkBox = obtenerCheckBoxDelPermiso(nombrePermiso);
            bool estaChequeado = checkBox?.Checked ?? false;

            return negRxP.altaUnPermisoDelRol(idRol, idPermiso, estaChequeado);
        }

        private CheckBox obtenerCheckBoxDelPermiso(string nombrePermiso)
        {
            return (CheckBox)FindControl("chkBx" + nombrePermiso);
        }
    }
}
