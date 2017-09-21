<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Locales.aspx.cs" Inherits="Locales" %>
<%@ Register Src="~/Controles/ZonaControl.ascx" TagPrefix="uc" TagName="ZonasControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Locales</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="titulo">
            <h1><strong>Locales</strong></h1>
        </div>  
    </header>
    <div class="recuadro" runat="server">
    <section runat="server" id="buscar">
            <h4 class="texto">Ingrese un número de padrón</h4>       
            <asp:TextBox ID="txtBuscar" Width="100px" runat="server" CssClass="campo" ></asp:TextBox>
            <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="buscar" OnClick="btBuscar_Click" />
     </section>
     <section runat="server" id="cuadroPropiedad">
            <h4 class="texto">
                Padrón
                <asp:TextBox ID="txtPadron" Width="100px" runat="server" CssClass="campo" ></asp:TextBox>
            </h4>   
             <h4 class="texto">
                 Zona
                <uc:ZonasControl ID="ZonasControl1" runat="server" />
             </h4>
            <h4 class="texto">
                Direccion
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="campo"></asp:TextBox>
            </h4>
            <h4 class="texto">
                Tipo de accion
                <asp:DropDownList CssClass="dropDownList" ID="ddlTipoAccion" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="Alquiler">Alquiler</asp:ListItem>
                    <asp:ListItem Value="Permuta">Permuta</asp:ListItem>
                    <asp:ListItem Value="Venta">Venta</asp:ListItem>
                </asp:DropDownList>
            </h4>
            <h4 class="texto">
                Baños
                <asp:TextBox ID="txtBaños" runat="server" Width="40px" CssClass="campo" ></asp:TextBox>
                Habitaciones
                <asp:TextBox ID="txtHabitaciones" runat="server" Width="40px" CssClass="campo" ></asp:TextBox>
            </h4>
            <h4 class="texto">
                Tamaño propiedad
                <asp:TextBox ID="txtMetrosCuadradosP" runat="server" Width="60px" CssClass="campo" ></asp:TextBox>
            </h4>
            <h4 class="texto">
                Habilitacion 
                <asp:CheckBox ID="Habilitacion" runat="server" CssClass="campo"></asp:CheckBox>
            </h4>
            <h4 class="texto">
                Precio
                <asp:TextBox ID="txtPrecio" runat="server" Width="100px" CssClass="campo" ></asp:TextBox>
            </h4>
     </section>
    </div>
    <div class="recuadro" runat="server" id="botones">
        <br />
        <asp:Label ID="lbResultado" runat="server" CssClass="resultado"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btCrearLocal" runat="server" Text="Crear" Width="100px" CssClass="botonCrear" OnClick="btCrearLocal_Click" />
        <asp:Button ID="btModificarLocal" runat="server" Text="Modificar" Width="100px" CssClass="botonModificar" OnClick="btModificarLocal_Click" />
        <asp:Button ID="btEliminarLocal" runat="server" Text="Eliminar" Width="100px" CssClass="botonSalir" OnClick="btEliminarLocal_Click" />
    </div>
</asp:Content>

