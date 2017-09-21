<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetallesPropiedad.aspx.cs" Inherits="Consulta" %>
<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de propiedad</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</head>
<body>
    <header>
        <div class="titulo">
            <h1><strong>Consulta de propiedad</strong></h1>
        </div>  
    </header>
    <form id="form1" runat="server">
    <div>
        <h2>AGENDA TU VISITA</h2>
        <table style="width:100%">
            <tr style="width:100%">
                <td style="width:2%"></td>
                <td style="width:25%;vertical-align:top">
                    <h4>Nombre:</h4>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    <h4>Telefono:</h4>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <div >
                        <asp:Calendar ID="CalVisita" runat="server" OnSelectionChanged="CalVisita_SelectionChanged" OnVisibleMonthChanged="CalVisita_VisibleMonthChanged"></asp:Calendar>
                    </div> 
                    <br />
                    Hora:
                    <asp:DropDownList ID="ddlHora" runat="server" CssClass="dropDownList">
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                     </asp:DropDownList>
                     &nbsp;&nbsp; Minuto:
                     <asp:DropDownList ID="ddlMinuto" runat="server">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                     </asp:DropDownList>
                    <br />
                    <br />
                        <asp:Button ID="btAtras" runat="server" Text="Atras" OnClick="btAtras_Click" CssClass="botonSalir" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btVisitar" runat="server" Text="Visitar" OnClick="btVisitar_Click" CssClass="botonModificar" />
                    </td>
                <td style="width:58%">
                    <div>
                        <cc1:VerPropiedad ID="VerPropiedad" runat="server" />
                    </div>
                </td>
                <td style="width:15%"></td>
            </tr>
        </table>
        <br />
        <br />
        <div style="text-align:center">
            <asp:Label ID="lbResultado" runat="server" Text="" CssClass="resultado"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
