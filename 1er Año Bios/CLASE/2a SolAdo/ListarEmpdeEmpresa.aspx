<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarEmpdeEmpresa.aspx.cs" Inherits="ListarEmpdeEmpresa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Listado de Empleados de una Empresa</strong><br />
        <br />
        Empresa:&nbsp;
        <asp:DropDownList ID="cbEmpresa" runat="server" Width="144px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:GridView ID="gvEmpleado" runat="server" Width="336px">
        </asp:GridView>
        <br />
        &nbsp;
        <asp:Button ID="btnListar" runat="server"  Text="Listar"  />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
