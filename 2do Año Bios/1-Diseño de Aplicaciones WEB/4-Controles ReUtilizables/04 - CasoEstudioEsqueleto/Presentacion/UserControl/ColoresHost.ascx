<%@ Control Language="C#" AutoEventWireup="true" CodeFile="coloresHost.ascx.cs" Inherits="UserControl_coloresHost" %>

<div style="text-align:center">
    Ejemplo con manejo de Host del control
    <br />
    <br />
    <div>             
        <asp:Button ID="btnAtras" runat="server" Text="<<" OnClick="btnAtras_Click" />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="btnAdelante" runat="server" Text=">>" OnClick="btnAdelante_Click" />
        <br />
        <br />
    </div>
    <div>
        <asp:Button ID="btnAplicar" runat="server" Text="Aplicarme" OnClick="btnAplicar_Click" />
        <br />
        <br />
        <asp:Button ID="btnAplicarHost" runat="server" Text="Aplicar Host" OnClick="btnAplicarHost_Click" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>
</div>


