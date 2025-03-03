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
            <main class="administracionYpermisos">
           
            <section class="agregarUsuario table-bordered">

             <div class="h1">create an account</div>
             <div class="form-floating">
             <asp:TextBox class="form-control" ID="txtUNRegistro" runat="server" TextMode="singleLine" ControlToValidate="txtUNRegistro"></asp:TextBox>
             <label for="floatingPassword">UserName</label>
             <asp:CustomValidator ID="cvNombreUsuario" runat="server" ValidationGroup="registro" Text="Nombre de usuario existente" ControlToValidate="txtUNRegistro" ForeColor="Red" OnServerValidate="cvNombreUsuario_ServerValidate"></asp:CustomValidator>
             <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ValidationGroup="registro" ControlToValidate="txtUNRegistro"></asp:RequiredFieldValidator>
             </div>
            <div class="">
        <asp:DropDownList ID="ddlNegociosRegistrados" runat="server"  class="form-select" ControlToValidate="ddlNegociosRegistrados">
            <asp:ListItem Value="-1">Negocio al que pertenece ---</asp:ListItem>
        </asp:DropDownList>   
        <asp:RequiredFieldValidator ID="rfvDdlNegocios" runat="server" ControlToValidate="ddlNegociosRegistrados" InitialValue="-1" ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
   </div>
        <div class="input-group mb-3">
            <asp:TextBox CssClass="form-control" ID="txtNuevoNegocio" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn btn-outline-secondary" ID="btnAgregarNegocio" runat="server" Text="Agregar negocio" OnClick="btnAgregarNegocio_Click"/>
            <asp:RegularExpressionValidator ID="revNegocio" runat="server" ControlToValidate="txtNuevoNegocio" ForeColor="Red" ValidationExpression="^[^']*$">no se permite el caracter &quot; &#39; &quot;</asp:RegularExpressionValidator>
            <asp:Label ID="lblMensajeErrorAgregarNegocio" runat="server" Text=""></asp:Label>
        </div>
     <div class="form-floating">
     <asp:TextBox class="form-control" ID="txtPassword1"  runat="server" TextMode="Password" ControlToCompare="txtPassword1"></asp:TextBox>
     <label for="floatingPassword">Password</label>
    </div>
     <div class="form-floating">
      <asp:TextBox class="form-control" ID="txtPassword2"  runat="server" TextMode="Password"></asp:TextBox>
      <label for="floatingPassword">Repeat password</label>
         <asp:CompareValidator ID="cvPasswordRegistro" runat="server" Text="Tienen que ser iguales" ControlToValidate="txtPassword2" ControlToCompare="txtPassword1" ValidationGroup="registro"></asp:CompareValidator>
     </div>
    <div class="paddingLogin">
        <asp:Button class="btn btn-primary" ID="btnRegistrarse" runat="server" Text="Create account" OnClick="btnRegistrarse_Click" /></div>
    <div class="paddingLogin">
</section>
           
            <section class="administrarPermisos">
                <asp:GridView class="table table-striped" ID="grdUsuarios" runat="server" AutoGenerateColumns="False" OnDataBound="grdUsuarios_DataBound" OnRowDataBound="grdUsuarios_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_idUsuario" runat="server" Text="<%# Bind(IdUsuario_Us) %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOMBRE">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nombreUsuario" runat="server" Text="<%# Bind(nombre_Us) %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rol">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Rol" runat="server" Text='<%# Bind("nombre_r") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Productos">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_PerProductos" runat="server" Text='<%# Bind("PRODUCTOS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inventario">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_PerInventario" runat="server" Text='<%# Bind("INVENTARIO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ventas">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_PerVentas" runat="server" Text='<%# Bind("VENTAS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reportes">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_PerReportes" runat="server" Text='<%# Bind("REPORTES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Administracion">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_PerAdministracion" runat="server" Text='<%# Bind("ADMINISTRACION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    </Columns>
                </asp:GridView>
                <div>
                    holaaa
                </div>
            </section>

            </main>
        </div>
    </form>
</body>
</html>
