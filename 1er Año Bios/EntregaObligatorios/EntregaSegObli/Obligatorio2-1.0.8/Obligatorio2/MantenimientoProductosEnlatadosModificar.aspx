<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoProductosEnlatadosModificar.aspx.cs" Inherits="Obligatorio2.MantenimientoProductosEnlatadosModificar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Modificar producto enlatado</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body style="height: 752px">
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Modificar producto enlatado</b></h1>
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

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-md-offset-3 col-lg-offset-3 text-center">               
                <asp:Label ID="lbModificarEnlatadoBusqueda" runat="server" Text="Código de barras:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModEnBuscar" runat="server" MaxLength="12" Font-Size="Large"></asp:TextBox>
                &nbsp;<asp:Button ID="btModEnBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btModificarEnlatadoBuscar_Click" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="clearfix visible-lg-block"></div>
            <div class="clearfix visible-md-block"></div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarEnlatadoCodigo" runat="server" Text="Código de barras:" Visible="False" Width="200px" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModEnCod" runat="server" Visible="False" Width="150px" BackColor="#CCCCCC" ReadOnly="True" MaxLength="12"></asp:TextBox>
                <br />
                <br />
            </div>


            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarEnlatadoNombre" runat="server" Text="Nombre:" Visible="False" Width="100px" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModEnNom" runat="server" Visible="False" MaxLength="30" Width="220px" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>       

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarEnlatadosPrecio" runat="server" Text="Precio : $" Visible="False" Width="110px" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtModEnPrecio" runat="server" Visible="False" MaxLength="8" Width="210px" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3 text-center">               
                <asp:Label ID="lbModificarEnlatadosTipo" runat="server" Text="Tipo de producto:" Visible="False" Width="200px" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlModEnTipo" runat="server" Width="150px" Visible="False" Font-Size="Large">
                    <asp:ListItem Selected="True" Value="false">Común</asp:ListItem>
                    <asp:ListItem Value="true">Abrefácil</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="clearfix visible-xs-block"></div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbModificarEnlatadosVencimiento" runat="server" Text="Fecha de vencimiento:" Visible="False" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-8 col-sm-8 col-md-6 col-lg-6 col-lg-offset-3 col-md-offset-3 col-sm-offset-2 col-xs-offset-2 text-center">               
                <asp:Calendar ID="calModEnlatado" runat="server" Width="95%" BackColor="#FFFFCC" BorderColor="#FFCC66" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" SelectedDate="07/25/2016 19:32:14" BorderWidth="1px" ShowGridLines="True" Visible="False">
                    <DayHeaderStyle BackColor="#FFCC66" BorderStyle="None" Height="1px" Font-Bold="True" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#FF6666" Font-Bold="True" />
                    <SelectorStyle BackColor="#FF5050" />
                    <TitleStyle BackColor="Red" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FF99FF" ForeColor="White" />
                </asp:Calendar>
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbModificarEnlatadosResultado" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btModificarEnlatadosCancelar" runat="server" Text="Cancelar" OnClick="btMantenimientoProductosEnlatadosCancelar_Click" Width="100px" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btModEnModificar" runat="server" Text="Modificar" Width="100px" OnClick="btMantenimientoProductosEnlatadosModificar_Click" Font-Size="Small" />
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
