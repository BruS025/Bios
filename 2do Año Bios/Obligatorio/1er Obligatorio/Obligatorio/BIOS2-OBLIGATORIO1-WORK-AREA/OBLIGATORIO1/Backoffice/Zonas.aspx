<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Zonas.aspx.cs" Inherits="Zonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Zonas</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="titulo">
            <h1><strong>Zonas</strong></h1>
        </div>  
    </header>
    <div class="recuadro" runat="server">
        <section runat="server" id="depNom">
            <h4 class="texto">Departamento y nombre</h4>
            <asp:DropDownList CssClass="dropDownList" ID="ddlDepartamentos" runat="server" AutoPostBack="True">
                <asp:ListItem Value="G">Artigas</asp:ListItem>
                <asp:ListItem Value="A">Canelones</asp:ListItem>
                <asp:ListItem Value="E">Cerro Largo</asp:ListItem>
                <asp:ListItem Value="L">Colonia</asp:ListItem>
                <asp:ListItem Value="Q">Durazno</asp:ListItem>
                <asp:ListItem Value="N">Flores</asp:ListItem>
                <asp:ListItem Value="O">Florida</asp:ListItem>
                <asp:ListItem Value="P">Lavalleja</asp:ListItem>
                <asp:ListItem Value="B">Maldonado</asp:ListItem>
                <asp:ListItem Value="S">Montevideo</asp:ListItem>
                <asp:ListItem Value="I">Paysandú</asp:ListItem>
                <asp:ListItem Value="J">Río Negro</asp:ListItem>
                <asp:ListItem Value="F">Rivera</asp:ListItem>
                <asp:ListItem Value="C">Rocha</asp:ListItem>
                <asp:ListItem Value="H">Salto</asp:ListItem>
                <asp:ListItem Value="M">San José</asp:ListItem>
                <asp:ListItem Value="K">Soriano</asp:ListItem>
                <asp:ListItem Value="R">Tacuarembó</asp:ListItem>
                <asp:ListItem Value="D">Treinta y Tres</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TxtNombre" Width="50px" runat="server" CssClass="campo"></asp:TextBox>
            <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="buscar" OnClick="btBuscar_Click" />
     </section>
     <section runat="server" id="prop">
         <h4 class="texto">Nombre oficial</h4>
          <asp:TextBox ID="TxtNombreOficial" runat="server" CssClass="campo"></asp:TextBox>
          <h4 class="texto">Cantidad de habitantes</h4>
          <asp:TextBox ID="TxtHabitantes" runat="server" CssClass="campo"></asp:TextBox>
          <h4 class="texto">Servicios</h4>
          <asp:TextBox ID="txtServicio" runat="server" CssClass="campo" ToolTip="Ingrese el servicio que desea agregar o quitar"></asp:TextBox>
          <asp:Button ID="btServicio" runat="server" Text="+" Width="40px" Height="22px" CssClass="botonCrear" OnClick="btServicio_Click" />
          <asp:Button ID="btQuitar" runat="server" Text="-" Width="40px" Height="22px" CssClass="botonSalir" OnClick="btQuitar_Click" />
     </section>
     <section runat="server" id="secServicios">
        <br />
        <asp:ListBox ID="lbServicios" Width="300px" runat="server"></asp:ListBox>
     </section>
    </div>
    <div class="recuadro" runat="server" id="botones">
        <br />
        <asp:Label ID="lbResultado" runat="server" CssClass="resultado"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btCrearZona" runat="server" Text="Crear" Width="100px" CssClass="botonCrear" OnClick="btCrearZona_Click" />
        <asp:Button ID="btModificarZona" runat="server" Text="Modificar" Width="100px" CssClass="botonModificar" OnClick="btModificarZona_Click" />
        <asp:Button ID="btEliminarZona" runat="server" Text="Eliminar" Width="100px" CssClass="botonSalir" OnClick="btEliminarZona_Click" />
    </div>
</asp:Content>

