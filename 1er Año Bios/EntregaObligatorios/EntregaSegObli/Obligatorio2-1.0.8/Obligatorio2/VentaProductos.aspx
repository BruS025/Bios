<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VentaProductos.aspx.cs" Inherits="Obligatorio2.VentaDeProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Venta de productos</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    </head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Venta de productos</b></h1>
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
                <asp:Label ID="lbVentaProductosDocumento" runat="server" Text="Documento:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlVentaProductosClientes" runat="server" Width="170px" AutoPostBack="True" OnSelectedIndexChanged="ddlVentaProductosClientes_SelectedIndexChanged" Font-Bold="False" Font-Size="Large"></asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbVentaProductosDescuento" runat="server" Text="Descuento (%):" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:Label ID="lbVentaProductosDescuentoResultado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
                </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbVentaproductosSeleccion" runat="server" Text="Producto:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlVentaProductosProducto" runat="server" Width="190px" AutoPostBack="True" OnSelectedIndexChanged="ddlVentaProductosProducto_SelectedIndexChanged" Font-Size="Large"></asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbVentaProductosMoneda0" runat="server" Text="Nombre:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lbVentaProductosNombreProductoResultado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbVentaProductosExtra" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:Label ID="lbVentaProductosExtraResultado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:Label ID="lbVentaProductosExtraKg" runat="server" Visible="False" Font-Bold="True" Font-Size="Large">Kg</asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbVentaProductosMoneda" runat="server" Text="Precio del producto: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:Label ID="lbVentaProductoPrecioResultado" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="restar" runat="server" Text="-" Width="30px" Font-Size="Large" Height="30px" OnClick="restar_Click" />
                &nbsp;&nbsp;<asp:Label ID="cantidadProducto" runat="server" Font-Bold="True" Font-Size="Large" Text="1" ></asp:Label>
                &nbsp;&nbsp;<asp:Button ID="sumar" runat="server" Text="+" Width="30px" Font-Size="Large" Height="30px" OnClick="Sumar_Click" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbPrecioTotal" runat="server" Font-Bold="True" Font-Size="Large" Text="Precio total:" ></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                <asp:Label ID="monedaCantidad" runat="server" Font-Bold="True" Font-Size="Large" Text="$" ></asp:Label>           
                <asp:Label ID="precioTotalCantidad" runat="server" Font-Bold="True" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbventaProdError" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btVentaProductosCancelar" runat="server" Text="Volver" Width="100px" OnClick="btVentaProductosCancelar_Click" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btVentaProductosAceptar" runat="server" Text="Agendar" Width="100px" OnClick="btVentaProductosAceptar_Click" Font-Size="Small" />   
                &nbsp;&nbsp;<asp:Button ID="btVentaProductosAceptarPagada" runat="server" Text="Pagar" Width="100px" OnClick="btVentaProductosAceptarPagada_Click" Font-Size="Small" />
                <br />
                <br />
                <br />
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
