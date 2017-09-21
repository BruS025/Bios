<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bienvenida.aspx.cs" Inherits="Bienvenida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bienvenida</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="titulo">
            <h1><strong>Bienvenida</strong></h1>
        </div>  
    </header>
    <div class="recuadro">
        <asp:Button ID="btEmpleados" runat="server" Text="Empleados" CssClass="boton" OnClick="btEmpleados_Click" />
        <asp:Button ID="btApartamentos" runat="server" Text="Apartamento" CssClass="boton" OnClick="btApartamentos_Click" />
        <asp:Button ID="btCasas" runat="server" Text="Casa" CssClass="boton" OnClick="btCasas_Click" />
        <asp:Button ID="btLocales" runat="server" Text="Locales" CssClass="boton" OnClick="btLocales_Click" />
        <asp:Button ID="btZonas" runat="server" Text="Zonas" CssClass="boton" OnClick="btZonas_Click" />
    </div>
</asp:Content>

