<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Obligatorio2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Menú principal</title>
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

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 text-center col-lg-offset-1">               
                <asp:Label ID="lbEmpresa" runat="server" Text="Empresa" Font-Bold="True" Font-Size="X-Large" Width="200px" BackColor="Red" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btMenuDatosEmpresa" runat="server" OnClick="btMenuDatosEmpresa_Click" Text="Modificar" Width="200px" BackColor="#B50000" BorderStyle="None" Font-Size="Large" ForeColor="White" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 text-center">               
                <asp:Label ID="lbClientes" runat="server" Text="Usuarios" Font-Bold="True" Font-Size="X-Large" Width="200px" BackColor="Red" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btMenuMantenimientoClientes" runat="server" Text="Clientes" Width="200px" OnClick="btMenuMantenimientoClientes_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
                </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 text-center">               
                <asp:Label ID="lbProductos" runat="server" Text="Productos" Font-Bold="True" Font-Size="X-Large" Width="200px" BackColor="Red" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btMenuListarProductos" runat="server" Text="Listar" Width="200px" OnClick="btMenuListarProductos_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
                <asp:Button ID="btMenuMantenimientoProductosEnlatados" runat="server" Text="Enlatados" Width="200px" OnClick="btMenuMantenimientoProductosEnlatados_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
                <asp:Button ID="btMenuMantenimientoProductosCongelados" runat="server" Text="Congelados" Width="200px" OnClick="btMenuMantenimientoProductosCongelados_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 text-center">               
                <asp:Label ID="lbGanancias" runat="server" Text="Ganancias" Font-Bold="True" Font-Size="X-Large" Width="200px" BackColor="Red" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btMenuCalcularTotalXproducto" runat="server" Text="Por producto" Width="200px" OnClick="btMenuCalcularTotalXproducto_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
                <asp:Button ID="btMenuCalcularTotalMensual" runat="server" Text="Mensuales" Width="200px" OnClick="btMenuCalcularTotalMensual_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
            </div>

            <div class="clearfix visible-sm-block"></div>
            <div class="clearfix visible-md-block"></div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 text-center">               
                <asp:Label ID="lbVentas" runat="server" Text="Ventas" Font-Bold="True" Font-Size="X-Large" Width="200px" BackColor="Red" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btMenuVentaDeProducto" runat="server" Text="Venta de productos" Width="200px" OnClick="btMenuVentaDeProducto_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
                <br />
                <asp:Button ID="btMenuPagoFactura" runat="server" Text="Pago de facturas" Width="200px" OnClick="btMenuPagoFactura_Click" BackColor="#B50000" BorderStyle="None" Font-Size="large" ForeColor="White" />
                <br />
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