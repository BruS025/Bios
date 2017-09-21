<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Venta.aspx.cs" Inherits="VentaDeProducto" EnableViewState="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            
            text-align: center;
        }
        .style2
        {
           
            text-align: center;
        }
        .style3
        {
            
          
            text-align: center;
        }
        .style4
        {            text-align: center;
        }
        .style7
        {
           
            text-align: center;
        }
        .style10
        {
            color: #0066FF;
        }
        .style11
        {
       
            text-align: center;
            height: 28px;
        }
        .style14
        {
            text-align: center;
            height: 27px;
        }
        .style17
        {
         
        }
        .style21
        {

            text-align: center;
            height: 35px;
        }
        .style24
        {
            font-family: "Arial Narrow";
            font-size: 15pt;
            text-decoration: underline;
            color: #00CC00;
            text-align: center;
        }
        .style25
        {
            height: 35px;
        }
        .style26
        {
            height: 28px;
        }
        .style27
        {
            text-align: center;
            height: 29px;
        }
        .style28
        {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p class="style24">
        <strong>VENTA</strong></p>
    <table style="width:50%;" align="center" border="1">
        <tr>
            <td class="style14" colspan="2">
                <asp:Label ID="lblMensaje" runat="server" Height="30px" 
                    style="text-align: center; color: #FF0000; "></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style21">
                Cliente:</td>
            <td class="style25">
                <asp:DropDownList ID="ddlClientes" runat="server" Width="300px" 
                    CssClass="style10" Height="40px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                Fecha de Venta :</td>
            <td class="style26" >
                Día:
                <asp:DropDownList ID="ddlDiaVenta" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mes:
                <asp:DropDownList ID="ddlMesVenta" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Año:
                <asp:DropDownList ID="ddlAnioVenta" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Fecha de Pago :</td>
            <td >
                Día:
                <asp:DropDownList ID="ddlDiaPago" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mes:
                <asp:DropDownList ID="ddlMesPago" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Año:
                <asp:DropDownList ID="ddlAnioPago" runat="server" CssClass="style10" 
                    Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                Selecciones Productos Para La venta</td>
        </tr>
        <tr>
            <td class="style27">
                Producto:</td>
            <td class="style28">
                <asp:DropDownList ID="ddlProductos" runat="server" Width="300px" Height="40px" 
                    style="color: #0066FF">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Catidad:</td>
            <td class="style17">
                <asp:TextBox ID="txtCantidad" runat="server" Height="30px" CssClass="style10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnAgregar" runat="server"  
                    Text="Agregar Linea" Width="138px" />
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:GridView ID="GVLineasVenta" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style4">
                <asp:Button ID="btnVender" runat="server" 
                    Text="Concretar Venta" Width="138px" />
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td >
                <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default.aspx">Volver al Menú Principal</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
