<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style16
        {
            font-size: 12pt;
        }
        .style20
        {
            height: 30px;
            font-size: 14pt;
            text-align: center;
            width: 913px;
        }
        .style23
        {
            width: 913px;
        }
        .style26
        {
            height: 15px;
            font-size: 14pt;
            text-align: left;
            width: 913px;
        }
        .style28
        {
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
    </div>
    <table style="width:40%;" align="center">
        <tr>
            <td style="font-weight: 700; text-align: center;" class="style28"> BIENVENIDO!! </td>
        </tr>
        <tr>
            <td class="style23">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkMantClientes" runat="server" 
                    PostBackUrl="~/MantenimientoClientes.aspx" CssClass="style16">Mantenimiento de Clientes</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkMatProdEnlatados" runat="server" 
                    PostBackUrl="~/MantenimientoProductosEnlatados.aspx" CssClass="style16">Mantenimiento de Productos Enlatados</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkMantProdCong" runat="server" 
                    PostBackUrl="~/MantenimientoProductosCongelados.aspx" CssClass="style16">Mantenimiento de Productos Congelados</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkVentaProd" runat="server" 
                    PostBackUrl="~/Venta.aspx" CssClass="style16">Ventas</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkCalcularTotMens" runat="server" CssClass="style16">Venta Anual de Producto</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style26">
                <asp:LinkButton ID="lnkTotalGanXProd" runat="server" 
                    PostBackUrl="~/CalcularTotalXProducto.aspx" CssClass="style16">Listado de Ventas en Un Periodo</asp:LinkButton>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
