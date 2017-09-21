<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoClienteAgregar.aspx.cs" Inherits="Obligatorio2.AgregarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Agregar cliente</title>
    <meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Agregar cliente</b></h1>
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

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center ">               
                <asp:Label ID="lbAgregarClienteCI" runat="server" Text="Documento:" Width="160px" Font-Size="Large" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                <br />
                <asp:TextBox ID="txtAgregarClienteDoc" runat="server" MaxLength="8" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbAgregarClienteDireccion" runat="server" Text="Dirección:" Width="160px" Font-Size="Large" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                <br />
                <asp:TextBox ID="txtAgregarClienteDir" runat="server" MaxLength="30" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbAgregarClienteTelefono" runat="server" Text="Teléfono:" Width="160px" Font-Size="Large" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                <br />
                <asp:TextBox ID="txtAgregarClienteTel" runat="server" MaxLength="11" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbAgregarClienteDescuento" runat="server" Text="Descuento (%):" Width="160px" Font-Size="Large" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                <br />
                <asp:TextBox ID="txtAgregarClienteDesc" runat="server" MaxLength="2" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btAgregarClienteCancelar" runat="server" Text="Cancelar" OnClick="btAgregarClienteCancelar_Click" Width="100px" Font-Size="Small" />
                &nbsp;&nbsp;
                <asp:Button ID="btAgregarClienteNuevo" runat="server" OnClick="btAgregarClienteNuevo_Click" Text="Aceptar" Width="100px" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbAgregarClienteResultado" runat="server" Font-Size="Small"></asp:Label>
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
