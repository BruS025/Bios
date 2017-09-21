<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pasarImagen.ascx.cs" Inherits="PasarImagenes.UserControl.pasarImagen" %>
<p>
    <asp:Button ID="btnAtras" runat="server" Text="&lt; Atras" />
&nbsp;&nbsp;&nbsp;
    <asp:Image ID="mostrarImagenes" runat="server" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAdelante" runat="server" Text="Adelante &gt;" />
</p>
<p>
    <asp:FileUpload ID="FileUpload1" runat="server" />
</p>

