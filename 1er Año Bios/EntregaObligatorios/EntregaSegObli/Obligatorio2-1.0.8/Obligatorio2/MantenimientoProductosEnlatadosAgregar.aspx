﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoProductosEnlatadosAgregar.aspx.cs" Inherits="Obligatorio2.MantenimientoProductosEnlatadosAgregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Agregar productos enlatados</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Agregar productos enlatados</b></h1>
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

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-4 text-center">               
                <asp:Label ID="lbMantenimientoProductosEnlatadosCodigo" runat="server" Text="Código de barras:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtManEnACod" runat="server" Width="150px" MaxLength="12" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-4 text-center">               
                <asp:Label ID="lbMantenimientoProductosEnlatadosNombre" runat="server" Text="Nombre:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtManEnANom" runat="server" Width="220px" MaxLength="30" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-4 text-center">               
                <asp:Label ID="lbMantenimientoProductosEnlatadosPrecio" runat="server" Text="Precio: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtManEnAPrecio" runat="server" Width="210px" MaxLength="8" Font-Size="Large"></asp:TextBox>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-12 text-center">               
                <asp:Label ID="lbMantenimientoProductosEnlatadosTipo" runat="server" Text="Tipo de producto:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlManEnATipo" runat="server" Width="150px" Font-Size="Large">
                    <asp:ListItem Selected="True" Value="false">Común</asp:ListItem>
                    <asp:ListItem Value="true">Abrefácil</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbMantenimientoProductosEnlatadosVencimiento" runat="server" Text="Fecha de vencimiento:" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6 text-center col-lg-offset-3 col-md-offset-3 col-sm-offset-3">               
                <asp:Calendar ID="calAEnlatado" runat="server" Width="100%" BackColor="#FFFFCC" BorderColor="#FFCC66" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" SelectedDate="07/25/2016 19:32:14" BorderWidth="1px" ShowGridLines="True">
                    <DayHeaderStyle BackColor="#FFCC66" BorderStyle="None" Height="1px" Font-Bold="True" />
                    <DayStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#FF6666" Font-Bold="True" />
                    <SelectorStyle BackColor="#FF5050" Wrap="True" />
                    <TitleStyle BackColor="Red" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FF99FF" ForeColor="White" />
                </asp:Calendar>
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbManEnlatadosResultado" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                &nbsp;&nbsp;<asp:Button ID="btMantenimientoProductosEnlatadosCancelar" runat="server" Text="Cancelar" OnClick="btMantenimientoProductosEnlatadosCancelar_Click" Width="100px" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btMantenimientoProductosEnlatadosAgregar" runat="server" Text="Agregar" Width="100px" OnClick="btMantenimientoProductosEnlatadosAgregar_Click" Font-Size="Small" />
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
