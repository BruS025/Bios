<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoProductosCongelados.aspx.cs" Inherits="MantenimientoProductosCongelados" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: medium;
            color: #33CC33;
            text-align: center;
            height: 33px;
        }
        .style56
        {
            width: 223px;
            text-align: center;
            height: 35px;
        }
        .style11
        {
            font-size: small;
        }
        .style57
        {            text-align: center;
        }
        .style60
        {
            width: 572px;
            text-align: center;
        }
        .style62
        {
            width: 223px;
            height: 26px;
        }
        .style63
        {
            width: 572px;
            height: 26px;
            text-align: center;
        }
        .style66
        {
            width: 572px;
            text-align: center;
            height: 59px;
        }
        .style67
        {
            width: 223px;
            text-align: center;
            height: 59px;
        }
        .style69
        {
            width: 223px;
            height: 20px;
            text-align: center;
            font-size: small;
        }
        .style70
        {
            width: 223px;
            text-align: center;
        }
        .style75
        {
            width: 572px;
            text-align: center;
            height: 21px;
        }
        .style76
        {
            width: 572px;
            text-align: center;
            height: 17px;
        }
        .style77
        {
            font-family: "Arial Narrow";
            font-size: 15pt;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
            <strong style="text-align: center"><span class="style77">MANTENIMIENTO DE PRODUCTOS 
            CONGELADOS</span><br />
            </strong></div>
    <table style="width:60%;" align="center" border="1">
        <tr>
            <td class="style57" colspan="2">
                <asp:Label ID="lblMensaje0" runat="server" Height="30px" 
                    style="text-align: center; color: #FF0000; font-weight: 700; font-size: large" 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style75">
                </td>
            <td class="style75">
                </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Código de Barras :</strong></span><br />
                </td>
            <td >
                <asp:TextBox ID="txtBarras0" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC" Width="300px"></asp:TextBox>
                <asp:Button ID="btnBuscar0" runat="server" Height="30px" 
                     style="text-align: center" Text="BUSCAR " 
                    Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                <strong><span class="style11">Nombre</span></strong><span class="style11"><strong 
                    style="text-align: center"> :</strong></span><br class="style11" />
                </td>
            <td >
                <asp:TextBox ID="txtNombre0" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC; text-align: left;" Width="300px" 
                    Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style67">
                <span class="style11"><strong style="text-align: center">Fecha de Vencimiento :</strong></span></td>
            <td class="style66">
                Día:
                <asp:DropDownList ID="ddlDia0" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
&nbsp;&nbsp; Mes:
                <asp:DropDownList ID="ddlMes0" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
&nbsp; Año:
                <asp:DropDownList ID="ddlAnio0" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style70">
                <span class="style11"><strong style="text-align: center">Precio :</strong></span></td>
            <td class="style60">
                <asp:TextBox ID="txtPrecio0" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC" Width="500px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style69">
                <strong style="text-align: center">Peso :</strong></td>
            <td >
                <asp:TextBox ID="txtPeso" runat="server" Height="25px" 
                    style="font-size: large; color: #0033CC" Width="130px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style62">
            </td>
            <td class="style63">
            </td>
        </tr>
        <tr>
            <td class="style62">
                &nbsp;</td>
            <td class="style63">
                <asp:Button ID="btnAlta0" runat="server" Height="30px"  
                    style="text-align: center" Text="ALTA " Width="90px" 
                    Enabled="False" />
            &nbsp;<asp:Button ID="btnModificar0" runat="server" Height="30px" 
                    style="text-align: center" Text="MODIFICAR " Width="90px" 
                   Enabled="False" />
            &nbsp;<asp:Button ID="btnBaja" runat="server" Height="30px" 
                    style="text-align: center" Text="BAJA " Width="90px" 
                    Enabled="False" />
                &nbsp;<asp:Button ID="btnLimpiar0" runat="server" Height="30px" 
                     Text="LIMPIAR" Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style76">
                </td>
            <td class="style76">
                <asp:LinkButton ID="lnkVolver0" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver al Menú Principal</asp:LinkButton>
            </td>
        </tr>
        </table>
    </form>
    </body>
</html>
