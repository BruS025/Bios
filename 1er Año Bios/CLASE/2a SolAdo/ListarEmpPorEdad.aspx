<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarEmpPorEdad.aspx.cs" Inherits="ListarEmpPorEdad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Listar Empleados Mayores de:</strong><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Parámetro @edad:"></asp:Label>
        <asp:TextBox ID="txtEdad" runat="server" Width="87px"></asp:TextBox><br />
        <br />
        <asp:ListBox ID="ltEmpleado" runat="server" Height="208px" Width="400px"></asp:ListBox><br />
        <br />
        &nbsp;<asp:Button ID="btnListar" runat="server" Text="Listar" /><br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
