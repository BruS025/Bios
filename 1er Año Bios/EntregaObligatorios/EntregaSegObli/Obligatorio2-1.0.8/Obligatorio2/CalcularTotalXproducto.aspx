<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcularTotalXproducto.aspx.cs" Inherits="Obligatorio2.CalcularTotalXproducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Ganancias por producto</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Menú principal</b></h1>
        </div>  
    </header>

    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Image ID="ImagenLogo" runat="server" Height="274px" ImageUrl="~/Imagenes/logoObligatorio2.jpg" Width="345px" />
            </div>
        </div>
    </div>

  <div class="container">
        <div class="row">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbCalcularTotalXproductoBuscar" runat="server" Text="Seleccionar producto:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlProductos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged1" Font-Size="Large">
                </asp:DropDownList>
                &nbsp;
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbCalculoNombre" runat="server" Text="Nombre producto: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lbCalculoProductoNombre" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbGananciasError" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbCalculoCantidad" runat="server" Text="Cantidad vendida: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lbCalcularTotalXproductoMostrarCantidad" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbCalculoGanancia" runat="server" Text="Ganancia generada:  $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lbCalcularTotalXproductoMostrarCalculo" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btCalculoProductoVolver" runat="server" OnClick="btCalculoProductoVolver_Click" Text="Volver" Width="100px" Font-Size="Small" />
                <br />
            </div>

        </div>
    </div>

<div class="color1 navbar navbar-inverse navbar-fixed-bottom">
    <div class="container">
        <div class="navbar-text pull-left">
            <p><em>Obligatorio 2 - Año 1 - Analista de sistemas. 2016</em></p>
        </div>
    </div>
</div>

</form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
