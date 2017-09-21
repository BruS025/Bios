<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoClienteModificar.aspx.cs" Inherits="Obligatorio2.ClienteModificar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Modificar cliente</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Modificar cliente</b></h1>
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

            <div class="col-xs-12 col-sm-7 col-md-5 col-lg-4 col-sm-offset-2 col-md-offset-3 col-lg-offset-3 text-center">               
                <asp:Label ID="lbModificarClienteDocumentoIngresado" runat="server" Text="Documento:" Font-Bold="True" Font-Size="Large" Height="32px"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModClienteDocBuscado" runat="server" MaxLength="8" Font-Size="Large" Height="32px"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1 text-center">               
                <asp:Button ID="btModificarClienteBuscar" runat="server" Text="Buscar" OnClick="btModificarClienteBuscar_Click" Font-Size="Small" Width="100px" />
                <br />
                <br />
                </div>

            <div class="clearfix visible-lg-block"></div>
            <div class="clearfix visible-md-block"></div>


            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarClienteDocumento" runat="server" Text="Documento:" Width="100px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModClienteDoc" runat="server" Visible="False" BackColor="#CCCCCC" ReadOnly="True" MaxLength="8" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>       

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarClienteTelefono" runat="server" Text="Teléfono:" Width="100px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModClienteTel" runat="server" Visible="False" MaxLength="10" Font-Bold="False" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="clearfix visible-sm-block"></div>


            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarClienteDireccion" runat="server" Text="Dirección:" Width="100px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModClienteDir" runat="server" Visible="False" MaxLength="30" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarClienteDescuento" runat="server" Text="Descuento:" Width="100px" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModClienteDes" runat="server" Visible="False" MaxLength="2" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbModificarClienteResultado" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btModificarClienteCancelar" runat="server" Text="Cancelar" Width="100px" OnClick="btModificarClienteCancelar_Click" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btModificarClienteAceptar" runat="server" Text="Aceptar" Width="100px" OnClick="btModificarClienteAceptar_Click" Visible="False" Font-Size="Small" />
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
