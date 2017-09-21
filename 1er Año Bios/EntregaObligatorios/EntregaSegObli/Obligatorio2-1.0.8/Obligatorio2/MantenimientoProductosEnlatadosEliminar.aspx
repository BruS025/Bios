<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoProductosEnlatadosEliminar.aspx.cs" Inherits="Obligatorio2.MantenimientoProductosEnlatadosEliminar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Eliminar producto enlatado</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Eliminar producto enlatado</b></h1>
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
                <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/Imagenes/advertencia.png" Width="20px" />
                &nbsp;<asp:Label ID="lbIconoAdvetencia" runat="server" BorderStyle="None" Font-Overline="False" Font-Strikeout="False" Text="ADVERTENCIA: Si elimina un cliente con ventas, se eliminaran las mismas." Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbProductoEnlatadoEliminarCodigo" runat="server" Text="Código de barras:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtEnEliminar" runat="server" MaxLength="12" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
                </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbProductoEnlatadoEliminarResultado" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btProductoEnlatadoEliminarCancelar" runat="server" OnClick="btProductoEnlatadoEliminarCancelar_Click" Text="Cancelar" Width="100px" Font-Size="Small" />
                &nbsp; <asp:Button ID="btProductoEnlatadoEliminarAceptar" runat="server" OnClick="btProductoEnlatadoEliminarAceptar_Click" Text="Aceptar" Width="100px" Font-Size="Small" />
                <br />
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
