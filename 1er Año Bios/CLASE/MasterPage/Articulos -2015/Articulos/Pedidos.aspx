<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Articulos.Pedidos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 225px;
        }
        .style2
        {
            width: 225px;
            height: 23px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            width: 222px;
        }
        .style5
        {
            height: 23px;
            width: 222px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
         <table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text=" Pedidos"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="Fecha:"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtfecha" runat="server" Width="180px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" ForeColor="Blue" Text="Descripción:"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtDesc" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text="Cliente:"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtCliente" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label10" runat="server" ForeColor="Blue" Text="Lista Articulos:"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlListArticulos" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:Label ID="Label8" runat="server" ForeColor="Blue" Text="Cantidad:"></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style3">
                    <asp:Label ID="Label9" runat="server" ForeColor="Blue" Text="Precio"></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregarItem" runat="server" Text="Agregar Item" 
                        onclick="btnAgregarItem_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    <asp:GridView ID="gvItemsPedido" runat="server">
                    </asp:GridView>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
             </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="Label6" runat="server" ForeColor="Blue" Text="Total:"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtTotal" runat="server" Width="180px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
             </tr>
             <tr>
                <td class="style2">
                    <asp:Label ID="Label7" runat="server" ForeColor="Blue" Text="SubTotal:"></asp:Label>
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtSubTotal" runat="server" Width="180px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style3">
                </td>
             </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="btnGuardarPedido" runat="server" OnClick="btnGuardarPedido_Click" Text="Guardar pedido" />
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
