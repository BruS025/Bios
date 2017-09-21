<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Articulos.Pedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 623px">
    <form id="form1" runat="server">
    <div style="height: 623px">
    
        <asp:Label ID="lbTituloPedido" runat="server" Text="Pedidos"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lbFecha" runat="server" Text="Fecha"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbDescripcion" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDescuento" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbTotal" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbSubTotal" runat="server" Text="Sub Total"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSubTotal" runat="server"></asp:TextBox>
&nbsp;
        <br />
        <br />
        <asp:Label ID="lbCliente" runat="server" Text="Cliente"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbCantidad" runat="server" Text="Cantidad"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCantidadaG" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbPrecio" runat="server" Text="Precio"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrecioGuar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtGuardar" runat="server" OnClick="BtGuardar_Click" Text="Guardar" />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridMostrar" runat="server" Height="138px" Width="942px">
        </asp:GridView>
    
        <asp:Label ID="LbResultado" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtGuarPedi" runat="server" OnClick="BtGuarPedi_Click" style="height: 26px" Text="Guardar Pedido" />
    
    </div>
    </form>
</body>
</html>
