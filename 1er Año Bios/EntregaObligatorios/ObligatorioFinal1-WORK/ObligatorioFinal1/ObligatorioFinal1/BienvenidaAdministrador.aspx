<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BienvenidaAdministrador.aspx.cs" Inherits="ObligatorioFinal1.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Bienvenida administrador</title>

    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
<header>
    <div class="container" runat="server">
        <h2><strong>Bienvenida administrador</strong></h2>
    </div>  
</header>

<div class="container" runat="server">
    <div class="row">

        <br />
        <br />
        <br />

    <div class="col-md-12" runat="server">

        <div class="col-md-3 col-md-offset-2" runat="server">
            <asp:Button ID="btCasa" CssClass="btn btn-lg btn-primary" runat="server" Text="Casas" Height="100px" Width="170px" OnClick="btCasa_Click" />
        </div>

        <div class="col-md-3" runat="server">
            <asp:Button ID="btPlato" CssClass="btn btn-lg btn-primary" runat="server" Text="Platos" Height="100px" Width="170px" OnClick="btPlato_Click" />
        </div>

        <div class="col-md-3" runat="server">
            <asp:Button ID="btAdministradores" CssClass="btn btn-lg btn-primary" runat="server" Text="Administradores" Height="100px" Width="170px" OnClick="btAdministradores_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

    </div>

    <div class="col-md-12" runat="server">

        <div class="col-md-3 col-md-offset-2" runat="server">
            <asp:Button ID="btListarPedidos" CssClass="btn btn-lg btn-primary" runat="server" Text="Pedidos" Height="100px" Width="170px" OnClick="btListarPedidos_Click" />
        </div>

        <div class="col-md-3" runat="server">
            <asp:Button ID="btEntrega" CssClass="btn btn-lg btn-primary" runat="server" Text="Entrega" Height="100px" Width="170px" OnClick="btEntrega_Click" />
        </div>

        <div class="col-md-3" runat="server">
            <asp:Button ID="btSalir" CssClass="btn btn-lg btn-primary" runat="server" Text="Salir" Height="100px" Width="170px" OnClick="btSalir_Click" />
        </div>

    </div>

    <div class="col-md-12" runat="server">
        <br />
        <p class="text-center"><asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
        <br />
        </div>

    </div>
</div> 

</asp:Content>
