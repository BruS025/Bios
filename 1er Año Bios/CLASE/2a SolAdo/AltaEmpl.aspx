<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaEmpl.aspx.cs" Inherits="AltaEmpl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Alta de un Empleado sin Todos los Datos<br />
        </strong>
        <br />
        <table>
            <tr>
                <td style="width: 100px">
                    CI:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCI" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Nombre:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Edad:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAlta" runat="server"  Text="Agregar" OnClick="btnAlta_Click" /></td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
