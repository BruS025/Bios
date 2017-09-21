<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarTodoEmp.aspx.cs" Inherits="ListarTodoEmp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Listado de Todos los Empleados<br />
        </strong>
        <br />
        <asp:ListBox ID="ltEmpleado" runat="server" Height="208px" Width="400px"></asp:ListBox><br />
        <br />
        <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" /><br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
