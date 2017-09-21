<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WFEjemplo.aspx.cs" Inherits="WFEjemplo" Theme="MiCSS.css" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="../Css/MiCSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TxTPrueba" runat="server">Texto de Prueba</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Hace Tarea" />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Elemento 1</asp:ListItem>
            <asp:ListItem>Elemento 2</asp:ListItem>
            <asp:ListItem>Elemento 3</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <p>
            <a href="../Default.aspx">Principal</a></p>
        <br />
    
    </div>
    </form>
</body>
</html>
