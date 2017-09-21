<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosEmpresa.aspx.cs" Inherits="Obligatorio2.DatosEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Modificar empresa</title>
    <meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="container">
                <h1><b>Modificar empresa</b></h1>
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

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbDatosEmpresaNombre" runat="server" Text="Nombre:" Width="100px" BorderStyle="None" Font-Size="Large" Font-Bold="True"></asp:Label>
                <br />
                 <br />
                <asp:TextBox ID="txtDatoEmpresaNombre" runat="server" ReadOnly="True" BackColor="#F0F0F0" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" Height="22px" Font-Bold="False" Font-Italic="False" ForeColor="#666666">ComidaRica</asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbDatosEmpresaRUT" runat="server" Text="R.U.T:" Width="100px" BorderStyle="None" Font-Size="Large" Font-Bold="True" ></asp:Label>
                <br />
                 <br />
                <asp:TextBox ID="txtDatoEmpresaRUT" runat="server" Font-Size="Large" Height="22px" MaxLength="12"></asp:TextBox>
                <br />
                <br />
                </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbDatoEmpresaDireccion" runat="server" Text="Dirección:" Width="100px" BorderStyle="None" Font-Size="Large" Font-Bold="True"></asp:Label>
                <br />
                 <br />
                <asp:TextBox ID="txtDatoEmpresaDireccion" runat="server" Font-Size="Large" Height="22px" MaxLength="30"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbDatoEmpresaTelefono" runat="server" Text="Teléfono:" Width="100px" Font-Size="Large" Font-Bold="True"></asp:Label>
                <br />
                 <br />
                <asp:TextBox ID="txtDatoEmpresaTelefono" runat="server" Font-Size="Large" Height="22px" MaxLength="10"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="clearfix visible-sm-block"></div>
            <div class="clearfix visible-md-block"></div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbDatoEmpresaResultado" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btDatosEmpresaCancelar" runat="server" OnClick="btDatosEmpresaCancelar_Click" Text="Cancelar" Width="100px" Font-Size="Small" />
                &nbsp;&nbsp;
                <asp:Button ID="btDatosEmpresaGuardar" runat="server" OnClick="btDatosEmpresaGuardar_Click" Text="Aceptar" Width="100px" Font-Size="Small" />
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
