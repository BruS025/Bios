<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="verPlato.ascx.cs" Inherits="ObligatorioFinal1.verPlato" %>

    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

<div class="col-md-12">

    <div class="col-md-6">
        <asp:Label ID="lbNombrePlato" runat="server" Text="Nombre del plato:"></asp:Label>
    </div>

    <div class="col-md-6">
        <asp:Label ID="nombrePlato" runat="server" Text="Boñiato"></asp:Label>
        <br />
        <br />
    </div>
    
</div>

<div class="col-md-12">

    <div class="col-md-6">
        <asp:Label ID="lbPrecioPlato" runat="server" Text="Precio del plato: $"></asp:Label>
    </div>

    <div class="col-md-6">
        <asp:Label ID="precioPlato" runat="server" Text="0"></asp:Label>
        <br />
        <br />
    </div>
    
</div>

<img class="img-circle glyphicon-align-center center-block" src="/Imagenes/logo.png" id="fotoMostrar" alt="Card image cap" runat="server" width="368" height="300" />
