<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministracionDeUsuarios.aspx.cs" Inherits="gestion_de_negocio.Administracion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="~/lib/twitter-bootstrap/css/bootstrap.css" rel="stylesheet"/>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="estilos.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="usuarioIniciado">
            <asp:Label ID="lblUsuarioIniciado" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblNegocioIniciado" runat="server" Text=""></asp:Label> 
            </div>
            <main class="administracionYpermisos">
           
            <section class="agregarUsuario table-bordered">

             <div><h2>Crear usuario</h2></div>
             <div class="form-floating">
             <asp:TextBox class="form-control" ID="txtUNRegistro" runat="server" TextMode="singleLine" ControlToValidate="txtUNRegistro"></asp:TextBox>
             <label for="floatingPassword">Nombre de Usuario</label>
             <asp:CustomValidator ID="cvNombreUsuario" runat="server" Text="Nombre de usuario existente" ControlToValidate="txtUNRegistro" ForeColor="Red" OnServerValidate="cvNombreUsuario_ServerValidate" ErrorMessage="nombre de usuario existente" ValidationGroup="registro"></asp:CustomValidator>
             <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ValidationGroup="registro" ControlToValidate="txtUNRegistro" ForeColor="Red">*</asp:RequiredFieldValidator>
             </div>
            <div class="form-floating">
        <asp:DropDownList ID="ddlNegociosRegistrados" runat="server"  class="form-select" ControlToValidate="ddlNegociosRegistrados" OnSelectedIndexChanged="ddlNegociosRegistrados_SelectedIndexChanged">
        </asp:DropDownList>
                 <label for="floatingPassword">Negocio</label>
        <asp:RequiredFieldValidator ID="rfvDdlNegocios" runat="server" ControlToValidate="ddlNegociosRegistrados" InitialValue="0" ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        <div class="input-group mb-3">
            <asp:TextBox CssClass="form-control" ID="txtNuevoNegocio" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn btn-outline-secondary" ID="btnAgregarNegocio" runat="server" Text="Agregar negocio" OnClick="btnAgregarNegocio_Click"/>
            <asp:RegularExpressionValidator ID="revNegocio" runat="server" ControlToValidate="txtNuevoNegocio" ForeColor="Red" ValidationExpression="^[^']*$">no se permite el caracter &quot; &#39; &quot;</asp:RegularExpressionValidator>
            <asp:Label ID="lblMensajeErrorAgregarNegocio" runat="server" Text=""></asp:Label>
        </div>
   </div>
   <div class="form-floating">
       <asp:DropDownList ID="ddlRoles" runat="server"  class="form-select" ControlToValidate="ddlRoles">
</asp:DropDownList>
       <label for="floatingPassword">Rol</label>    
        <asp:RequiredFieldValidator ID="rfvDdlRoles" runat="server" ControlToValidate="ddlRoles" InitialValue="0" ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
   </div>
               
     <div class="form-floating">
     <asp:TextBox class="form-control" ID="txtPassword1"  runat="server" TextMode="Password" ControlToCompare="txtPassword1" ControlToValidate="txtPassword1"></asp:TextBox>
     <label for="floatingPassword">Password</label>
         <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" Text="*" ControlToValidate="txtPassword1" ValidationGroup="registro"></asp:RequiredFieldValidator>
    </div>
     <div class="form-floating">
      <asp:TextBox class="form-control" ID="txtPassword2"  runat="server" TextMode="Password"></asp:TextBox>
      <label for="floatingPassword">Repeat password</label>
         <asp:CompareValidator ID="cvPasswordRegistro" runat="server" Text="Tienen que ser iguales" ControlToValidate="txtPassword2" ControlToCompare="txtPassword1" ValidationGroup="registro"></asp:CompareValidator>
     </div>
    <div class="paddingLogin">
        <asp:Button class="btn btn-primary" ID="btnRegistrarse" runat="server" Text="Create account" OnClick="btnRegistrarse_Click" ValidationGroup="registro" /></div>
   
</section>
                 
       <section class="administrarPermisos">
           <h2 id="h2Permisos">Administrar Permisos</h2>
           <div class="contenedor_GridUsuarios">

                <asp:GridView class="table table-striped" ID="grdUsuarios" runat="server" AutoGenerateColumns="False" OnDataBound="grdUsuarios_DataBound" OnRowDataBound="grdUsuarios_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_idUsuario" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOMBRE">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nombreUsuario" runat="server" Text='<%# Bind("Nombre_Us") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rol">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Rol" runat="server" Text='<%# Bind("nombre_r") %>'></asp:Label>
                                <asp:DropDownList ID="ddl_it_Roles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_it_Roles_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Productos">
                            <ItemTemplate>
                                <asp:Button class="botonGrid" ID="btn_it_Productos" runat="server" OnClick="btn_it_Productos_Click" Text='<%# Bind("PRODUCTOS") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inventario">
                            <ItemTemplate>
                                <asp:Button class="botonGrid" ID="btn_it_Inventario" runat="server" OnClick="btn_it_Inventario_Click" Text='<%# Bind("INVENTARIO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ventas">
                            <ItemTemplate>
                                <asp:Button class="botonGrid" ID="btn_it_Ventas" runat="server" OnClick="btn_it_Ventas_Click" Text='<%# Bind("VENTAS") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reportes">
                            <ItemTemplate>
                                <asp:Button class="botonGrid" ID="btn_it_Reportes" runat="server" Text='<%# Bind("REPORTES") %>' OnClick="btn_it_Reportes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Administracion">
                            <ItemTemplate>
                                <asp:Button class="botonGrid" ID="btn_it_Admin" runat="server" OnClick="btn_it_Admin_Click" Text='<%# Bind("ADMINISTRACION") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    </Columns>
                </asp:GridView>
           </div>
            </section>

            </main>
        </div>
    </form>
</body>
</html>
