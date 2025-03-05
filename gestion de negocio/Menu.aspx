<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="gestion_de_negocio.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/lib/twitter-bootstrap/css/bootstrap.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
<link href="estilos.css" rel="stylesheet"/>
    <title>Menu</title>
</head>
<body class="body_menu">
    <form id="form1" runat="server">
     
        <main class="main">
            <section class="contenedor_Menu">
                <asp:Button onmouseover="notifyServer('hover')" onmouseout="notifyServer('leave')"  CssClass="boton_menu" ID="btnProductos" runat="server" Text="Productos" title="Agregar - Eliminar - Modificar - Listar - Categorización de Productos" />    
                <asp:Button CssClass="boton_menu" ID="btnInventario" runat="server" Text="Gestion inventario"  title="Registro de entradas y salidas de inventario" />
                <asp:Button CssClass="boton_menu" ID="btnVentas" runat="server" Text="Gestion ventas"  title="Registro de ventas realizadas"/>
                <asp:Button CssClass="boton_menu" ID="btnReportes" runat="server" Text="Reportes y estadisticas" title="Reportes sobre productos más vendidos.
Reporte de ganancias y pérdidas por períodos específicos.
Visualización de datos con gráficos
" />
                <asp:Button CssClass="boton_menu" ID="btnAdmin" runat="server" Text="Administracion y permisos" title="Gestion de permisos dentro de los usuarios de la empresa" OnClick="btnAdmin_Click" />
            </section>
        </main>
    </form>
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js"></script>
   
        <script>
        // notifyServer es una funcion que se ejecuta cuando ocurre alguno de los eventos describidos en el boton
        // llamo a __doPostBack que envia info al servidor
        function notifyServer(action) {

            console.log("--<< " + action);
            __doPostBack('btnProductos', action);
        }
    </script>
</body>
</html>
