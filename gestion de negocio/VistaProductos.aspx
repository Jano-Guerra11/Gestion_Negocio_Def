<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaProductos.aspx.cs" Inherits="gestion_de_negocio.VistaProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="estilos.css"/>
    <link href="~/lib/twitter-bootstrap/css/bootstrap.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <title></title>
    </head>
<body id="bodyProductos">
    <form id="form1" runat="server">
        <main>
                <div class="usuarioIniciado">
                    <asp:Label ID="lblNegocioIniciado" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblUsuarioIniciado" runat="server" Text=""></asp:Label>
                </div>
            <asp:Panel CssClass="contenedor_Productos" ID="pnlContenedor" runat="server">
           <section class="agregarProducto">
               <div class="contenedor_Imagen">
                   <asp:FileUpload ID="flUpProducto" runat="server" />
                   <asp:Button ID="btnGuardarImagen" runat="server" Text="Guardar imagen" OnClick="btnGuardarImagen_Click" />
                   <asp:Image ID="imgProducto" runat="server" ImageUrl="" />
               </div>

    <table class="info_Producto">
        <!-- -->
        <tr class="fila">
            <th class="table_header thNombre">Nombre</th>
        </tr>
        <tr class="fila">
            <td><asp:TextBox CssClass="txtInfoProducto" ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox></td>
        </tr>
        <!-- -->
         <tr class="fila">
            <th class="table_header">Seccion</th>
         </tr>
         <tr class="fila">
             <td>
                 <asp:DropDownList ID="ddlSecciones" runat="server">
                     <asp:ListItem Value="0">- ninguna -</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Button ID="btnAgregarSeccion" runat="server" Text="+" Font-Bold="True" Font-Size="Large" OnClick="btnAgregarSeccion_Click" />
                 <asp:TextBox ID="txtNuevaSeccion" runat="server" Visible="false"></asp:TextBox>
                 <asp:Label ID="lblMensajeAltaSeccion" runat="server" Text=""></asp:Label>
             </td>
         </tr>
        <!-- 
         <tr class="fila">
            <th class="table_header">categoria/Modelo</th>
        </tr>
        <tr class="fila">
           <td><asp:TextBox CssClass="txtInfoProducto" ID="txtCategoria" runat="server">categoria/modelo del producto</asp:TextBox></td>
        </tr>
        <!-- -->
        <tr class="fila">
            <th  class="table_header">Descripcion</th>
        </tr>
        <tr class="fila">
            <td><asp:TextBox CssClass="txtInfoProducto" ID="txtDescripcion" runat="server" placeholder="Descripcion del producto"></asp:TextBox></td>
        </tr>
        <!-- -->
        <tr class="fila">
            <th  class="table_header">Precio</th>
        </tr>
        <tr class="fila">
            <td><asp:TextBox CssClass="txtInfoProducto" ID="txtPrecio" runat="server" placeholder="0.0$"></asp:TextBox></td>
        </tr>
        <!-- -->
        <tr class="fila">
            <th  class="table_header">Stock</th>
        </tr>
        <tr class="fila">
            <td><asp:TextBox CssClass="txtInfoProducto" ID="txtStock" runat="server" placeholder="20 U"></asp:TextBox></td>
        </tr>
        <!-- -->
         <!-- -->
        <tr class="fila">
            <th  class="table_header">Proveedor</th>
        </tr>
        <tr class="fila">
            <td>
                <asp:DropDownList ID="ddlProveedores" runat="server"></asp:DropDownList>
            <div class="input-group input-group-sm mb-3">
    <asp:TextBox CssClass="form-control" ID="txtNombreProv" runat="server" placeholder="Nombre" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreProv" runat="server" ErrorMessage="*" ControlToValidate="txtNombreProv" Text="*"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtRazonSocialProv" runat="server" placeholder="Razon social" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRazonSocialProv" runat="server" ErrorMessage="*" ControlToValidate="txtRazonSocialProv" Text="*" ValidationGroup="altaProv"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtTelefonoProv" runat="server" placeholder="Telefono" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTelefonoProv" runat="server" ErrorMessage="*" Text="*" ValidationGroup="altaProv" ControlToValidate="txtTelefonoProv"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtMailProv" runat="server" placeholder="mail (opcional)" Visible="False"></asp:TextBox>
    <asp:Button CssClass="btn btn-outline-secondary" ID="btnAgregarProveedor" runat="server" Text="Agregar Proveedor" OnClick="btnAgregarProveedor_Click" />
    <asp:Label ID="lblMensajeErrorAgregarProveedor" runat="server" Text=""></asp:Label>
</div>
                </td>
        </tr>
        <!-- -->
        <tr>
           <td> <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
               <asp:Label ID="lblMensajeAltaObaja" runat="server" Text=""></asp:Label>
           </td>
        </tr>
    </table>  
</section>
            <section class="Productos">
             <asp:Button ID="btnEsconder" runat="server" Text="<" OnClick="btnEsconder_Click" />
            <div class="listadoYfiltrado">
                <div class="contenedor_filtrado">
                <table class="filtrado">
                    <tr class="filaFiltrado">
                        <td class="primeraCelda">Codigo </td>
                       <td class="celdaMedia"> <asp:DropDownList CssClass="ddls" ID="ddlOpCodigo" runat="server">
                           <asp:ListItem Value="=">igual a</asp:ListItem>
                           <asp:ListItem Value="&gt;">mayor a </asp:ListItem>
                           <asp:ListItem Value="&lt;">menor a </asp:ListItem>
                           </asp:DropDownList></td>
                        <td class="ultimaCelda">
                            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox></td>
                        <td class="primeraCelda">Nombre </td><td class="ultimaCelda">
                            <asp:TextBox ID="txtNombreProducto" runat="server"></asp:TextBox></td>
                        <td class="primeraCelda">Seccion </td><td class="ultimaCelda">
                            <asp:DropDownList CssClass="ddls" ID="ddlSeccion" runat="server"></asp:DropDownList>
                        
                                         </td>
                    </tr>
                    <tr class="filaFiltrado">
                        <td class="primeraCelda">Categoria/modelo/tipo</td><td class="ultimaCelda">
                            <asp:DropDownList CssClass="ddls" ID="ddlCategorias" runat="server"></asp:DropDownList>
                            <asp:TextBox ID="txtNuevoTipo" runat="server" placeholder="Escriba la nueva categoria" Visible="false"></asp:TextBox>
                                                      </td>
                        <td class="primeraCelda">Precio</td><td class="celdaMedia" >
                            <asp:DropDownList CssClass="ddls" ID="ddlOpPrecio" runat="server">
                                <asp:ListItem  Value="=">Igual a</asp:ListItem>
                                <asp:ListItem  Value="&gt;">Mayor a</asp:ListItem>
                                <asp:ListItem  Value="&lt;">Menor a</asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="ultimaCelda">
                            <asp:TextBox ID="txtFiltroPrecio" runat="server"></asp:TextBox></td>
                        <td class="primeraCelda">Stock</td><td class="celdaMedia">
                            <asp:DropDownList CssClass="ddls" ID="ddlOpStock" runat="server">
                                <asp:ListItem Value="=">Igual a </asp:ListItem>
                                <asp:ListItem Value="&gt;">Mayor a</asp:ListItem>
                                <asp:ListItem Value="&lt;">Menor a</asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="ultimaCelda">
                            <asp:TextBox ID="txtFiltroStock" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="filaFiltrado">
                        <td class="primeraCelda">Proveedor</td>
                        <td class="celdaMedia">
                            <asp:TextBox ID="txtFiltroProveedor" runat="server"></asp:TextBox></td>
                        <td class="ultimaCelda"><asp:Button class="" ID="btnFiltrar" runat="server" Text="Filtrar Resultados" OnClick="btnFiltrar_Click" /></td>

                    </tr>
                </table>
                </div>
                <div class="contenedor_gridProductos">
                <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CssClass="GridView" >
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_codigo" runat="server" Text='<%# Bind("idProducto_pr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("nombre_pr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Seccion">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_seccion" runat="server" Text='<%# Bind("nombre_sec") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_descripcion" runat="server" Text='<%# Bind("descripcion_pr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_precio" runat="server" Text='<%# Bind("precio_pr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_stock" runat="server" Text='<%# Bind("stock_pr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Proveedor">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_proveedor" runat="server" Text='<%# Bind("nombre_prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
            </section>
            </asp:Panel>
        </main>
    </form>
    
</body>
</html>
