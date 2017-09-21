<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ZonaControl.ascx.cs" Inherits="Controles_ZonaControl" %>
<asp:DropDownList CssClass="dropDownList" ID="ddlDepartamentos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamentos_SelectedIndexChanged">
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

<asp:DropDownList ID="nombreZona" runat="server" AutoPostBack="True" CssClass="dropDownList" DataTextField="NombreOficial" DataValueField="Nombre">
</asp:DropDownList>