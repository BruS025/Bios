<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarSueldos.aspx.cs" Inherits="ListarSueldos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>Sueldo Maximo y Sueldo Minimo de todos los Empleados<br />
        </strong>
    
    </div>
        <table>
            <tr>
                <td style="width: 100px">
                    Minimo:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtMinimo" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Maximo:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtMaximo" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular"  /></td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
