<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Empleados</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="titulo">
            <h1><strong>Empleados</strong></h1>
        </div>  
    </header>
    <div id="buscar" class="recuadro" runat="server">
        <section style="margin-top:20px">
           <asp:TextBox ID="txtBuscar" runat="server" MaxLength="10"></asp:TextBox>
           <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="buscar" OnClick="btBuscar_Click" />
        </section>
    </div>
    <div runat="server" class="recuadro" id="crear">
        <section>
            <h4 class="texto">Nombre</h4>
            <asp:TextBox ID="TxtNombre" ReadOnly="true" runat="server" CssClass="campo"></asp:TextBox>
            <br />    
        </section>
        <section runat="server" id="contra">
        <h4 class="texto">Contraseña</h4>
            <asp:TextBox ID="TxtContraseña" runat="server" TextMode="Password" CssClass="campo"></asp:TextBox> 
        </section>
    </div>
    <div class="recuadro">
        <br />
        <asp:Label ID="lbResultado" runat="server" CssClass="resultado"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btCrearEmpleado" runat="server" Text="Crear" Width="100px" CssClass="botonCrear" OnClick="btCrearEmpleado_Click" />
        <asp:Button ID="btModificarEmpleado" runat="server" Text="Modificar" Width="100px" CssClass="botonModificar" OnClick="btModificarEmpleado_Click" />
        <asp:Button ID="btEliminarEmpleado" runat="server" Text="Eliminar" Width="100px" CssClass="botonSalir" OnClick="btEliminarEmpleado_Click" />
    </div>
</asp:Content>

