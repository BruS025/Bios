<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploCalendarioASP.aspx.cs" Inherits="PruebaCalendarioASP" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:CalendarioASP ID="CalendarioASP1" runat="server" />
        <br />
        <br />
        <asp:TextBox ID="txtMostrarFecha" runat="server"></asp:TextBox>
        <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar" />
        <br />
        <br />
        <br />
        <asp:Label ID="lbResultado" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
