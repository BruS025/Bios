<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/Controles/ZonaControl.ascx" TagPrefix="uc1" TagName="ZonaControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de propiedades</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</head>
<body>
    <header>
        <div class="titulo">
            <h1><strong>Listado de propiedades</strong></h1>
        </div>  
    </header>

    <form id="form1" runat="server">
    <div>
        <table style="width:100%;text-align:left" class="texto">
            <tr>
                <td style="width:15%">
                </td>
                <td style="text-align:left">
                Tipo de accion:
                <asp:DropDownList CssClass="dropDownList" ID="ddlTipoAccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoAccion_SelectedIndexChanged">
                    <asp:ListItem Value="Alquiler">Alquiler</asp:ListItem>
                    <asp:ListItem Value="Permuta">Permuta</asp:ListItem>
                    <asp:ListItem Value="Venta">Venta</asp:ListItem>
                </asp:DropDownList>

                    &nbsp;</td>
                <td style="width:15%">
                </td>
            </tr>
            <tr>
                <td style="width:15%">
                </td>
                <td style="text-align:left">
                    Zona: 
                        <uc1:ZonaControl runat="server" ID="ZonaControl" />

                &nbsp;Tipo de propiedad: 
                        <asp:DropDownList CssClass="dropDownList" ID="ddlTipoPropiedad" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="Apartamento">Apartamento</asp:ListItem>
                            <asp:ListItem Value="Casa">Casa</asp:ListItem>
                            <asp:ListItem Value="Local">Local</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td style="width:15%">                    
                </td>
            </tr>
            <tr>
                <td style="width:15%">                    
                </td>
                <td>  
                    Rango de precios:
                    Desde
                    $ <asp:TextBox ID="txtDesde" runat="server" Width="100px"></asp:TextBox> 
                    &nbsp;Hasta
                    $ <asp:TextBox ID="txtHasta" runat="server" Width="100px"></asp:TextBox>              
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btBuscar" runat="server" Text="Buscar" CssClass="buscar" OnClick="btBuscar_Click"/>            
                    <asp:Button ID="btLimpiar" runat="server" Text="Limpiar" CssClass="botonSalir" OnClick="btLimpiar_Click" />
                </td>
            </tr>
        </table>
        <div>
        <table style="width:100%">
            <tr>
                <td style="width:15%"></td>
                <td style="width:70%">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableTheming="True">
                        <HeaderTemplate>
                          <table style="width:100%;text-align:left;border:solid;background-color:forestgreen;font-size:22px">
                             <thead>
                                <tr>
                                    <th style="width:15%">Padron</th>
                                    <th style="width:40%">Direccion</th>
                                    <th style="width:20%">Zona</th> 
                                    <th style="width:15%">TipoDeAccion</th> 
                                    <th style="width:10%">Ver</th>                                            
                                </tr>
                            </thead>
                            <tbody>                                                                                       
                        </HeaderTemplate>  
                        <ItemTemplate>
                            <table style="width:100%;text-align:left">
                                <tr>
                                    <td style="width:15%">
                                        <asp:Label ID="lbPadron" runat="server" Text='<%# Bind("Padron") %>'></asp:Label>
                                    </td>
                                    <td style="width:40%">
                                        <asp:Label ID="lbDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                    </td>
                                    <td style="width:20%">
                                        <asp:Label ID="lbZona" runat="server" Text='<%# Bind("Zona.Nombre") %>'></asp:Label>
                                    </td>
                                    <td style="width:15%">
                                        <asp:Label ID="lbTipoDeAccion" runat="server" Text='<%# Bind("TipoDeAccion") %>'></asp:Label>
                                    </td>
                                    <td style="width:10%">
                                        <asp:Button ID="btVer" runat="server" CommandName="Ver" style="text-align: center" Text="Ver" CssClass="buscar"/>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <table style="width:100%;text-align:left;background-color:mediumseagreen">
                                <tr>
                                    <td style="width:15%">
                                        <asp:Label ID="lbPadron" runat="server" Text='<%# Bind("Padron") %>'></asp:Label>
                                    </td>
                                    <td style="width:40%">
                                        <asp:Label ID="lbDireccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                    </td>
                                    <td style="width:20%">
                                        <asp:Label ID="lbZona" runat="server" Text='<%# Bind("Zona.Nombre") %>'></asp:Label>
                                    </td>
                                    <td style="width:15%">
                                        <asp:Label ID="lbTipoDeAccion" runat="server" Text='<%# Bind("TipoDeAccion") %>'></asp:Label>
                                    </td>
                                    <td style="width:10%">
                                        <asp:Button ID="btVer" runat="server" CommandName="Ver" style="text-align: center" Text="Ver"  CssClass="buscar"/>
                                    </td>
                                </tr>
                            </table>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </td>
                <td style="width:15%"></td>
            </tr>
        </table>
        <div style="text-align:center">
        <br />
        <br />
        <asp:Label ID="LBResultado" runat="server" CssClass="resultado"></asp:Label>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
