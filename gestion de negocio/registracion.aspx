<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registracion.aspx.cs" Inherits="gestion_de_negocio.registracion" %>

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
        <main class="table-responsive">
     <section class="table-bordered">
         <div class="h1">create an account</div>
          <div class="form-floating">
        <asp:TextBox class="form-control" ID="txtUNRegistro" runat="server" TextMode="singleLine"></asp:TextBox>
        <label for="floatingPassword">UserName</label>
        </div>
         <div class="form-floating">
             <asp:TextBox class="form-control" ID="txtBNRegistro"  runat="server" TextMode="singleLine"></asp:TextBox>
          <label for="floatingPassword">Bussines name</label>
        </div>
          <div class="form-floating">
          <asp:TextBox class="form-control" ID="txtPassword1"  runat="server" TextMode="Password"></asp:TextBox>
          <label for="floatingPassword">Password</label>
         </div>
          <div class="form-floating">
           <asp:TextBox class="form-control" ID="txtPassword2"  runat="server" TextMode="Password"></asp:TextBox>
           <label for="floatingPassword">Repeat password</label>
          </div>
         <div class="paddingLogin">
             <asp:CheckBox ID="chbxRecordarme2" runat="server" text="Remember user"/></div>
         <div class="paddingLogin">
             <asp:Button class="btn btn-primary" ID="btnRegistrarse" runat="server" Text="Create account" /></div>
         <div class="paddingLogin">
             <asp:LinkButton ID="lbVolverALogin" runat="server" OnClick="lbVolverALogin_Click">Already have an account? Log in</asp:LinkButton></div>
     </section>

 </main>
    </form>
</body>
</html>
