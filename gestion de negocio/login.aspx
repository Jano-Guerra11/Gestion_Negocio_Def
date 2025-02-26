<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="gestion_de_negocio.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/lib/twitter-bootstrap/css/bootstrap.css" rel="stylesheet"/>
    <link href="estilos.css" rel="stylesheet"/>
    <title>Login</title>
</head>
<body>
<script src="Scripts/bootstrap.bundle.min.js"></script>
    <form id="form1" runat="server">
        <main class="table-responsive">
            <section class="table-bordered">
                <div class="h1">Login</div>
                 <div class="form-floating">
               <asp:TextBox class="form-control" runat="server" TextMode="singleLine" ID="txtNombreUsuario"></asp:TextBox>
               <label for="floatingPassword">UserName</label>
               </div>
                <div class="form-floating">
                    <asp:TextBox class="form-control" id="txtPassword"  runat="server" TextMode="Password"></asp:TextBox>
                 <label for="floatingPassword">Password</label>
                     <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" />
               </div>
               <div class="form-floating">
                   <asp:TextBox class="form-control" id="txtNombreNegocio"  runat="server" TextMode="Password"></asp:TextBox>
                   <label for="floatingPassword">Bussines Name</label>
                   </div>
                <div>
                    <asp:CheckBox ID="chbxRecordarme" runat="server" text="Remember user"/></div>
                <div>
                    <asp:Button class="btn btn-primary" ID="btnIniciarSesion" runat="server" Text="Login" OnClick="btnIniciarSesion_Click" />
                    <asp:Label ID="lblMensajeDeInicio" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div>
                    <asp:LinkButton ID="lbRegistrarse" runat="server" OnClick="lbRegistrarse_Click">¿no tiene cuenta? Registrese!</asp:LinkButton></div>
            </section>

        </main>
    </form>
    <script src="Scripts/jquery.min.js"></script>
</body>
</html>
