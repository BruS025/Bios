<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarArticulos.aspx.cs" Inherits="Articulos.ListarArticulos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 547px">
    <form id="form1" runat="server">
    <div style="height: 542px">
    
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="DESCONECTADO"></asp:Label>
        <br />
        <br />
    
        <br />
        <br />
        <asp:GridView ID="GridArticulos" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="BtListar" runat="server" OnClick="Button1_Click" Text="Listar" />
        <br />
        <br />
        <br />
        <asp:Label ID="lbResultado" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
