<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaFactura.aspx.cs" Inherits="AltaFactura" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style2
        {
            color: #0066CC;
            font-weight: bold;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
        }
        .style5
        {            text-align: left;
        }
        .style6
        {
            width: 34px;
        }
        .style7
        {
            width: 516px;
        }
        .style8
        {
            width: 375px;
        }
        .style9
        {
            height: 23px;
        }
        .style10
        {
            width: 174px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style3">
    
        <h2>
    
        <span class="style2">Alta Facturas</span></h2>
        <br />
        <table align="center" style="width: 48%;">
            <tr>
                <td class="style10">
                    Fecha:</td>
                <td class="style5" colspan="2">
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    Cliente:</td>
                <td class="style5" colspan="2">
        <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style7">
        &nbsp;&nbsp;&nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    Articulo:</td>
                <td class="style5" colspan="2">
                    <asp:TextBox ID="txtCodigoArticulo" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    cantidad</td>
                <td class="style5" colspan="2">
                    <asp:TextBox ID="txtCantidad" runat="server" Width="52px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:Button ID="btnAgregarArticulo" runat="server" 
                        onclick="btnAgregarArticulo_Click" Text="Añadir articulo a la lista" 
                        Width="194px" />
                </td>
            </tr>
            <tr>
                <td class="style9" colspan="4">
                    <br />
                    Lineas de la Factura<br />
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CodArt" HeaderText="Codigo" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            </table>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
            Text="Agregar" Enabled="False" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="386px"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
