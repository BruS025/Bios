<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoProductosEnlatados.aspx.cs" Inherits="MantenimientoProductosEnlatados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: 15pt;
            color: #33CC33;
            text-align: center;
            font-family: "Arial Narrow";
            text-decoration: underline;
        }
        .style56
        {
            width: 155px;
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
            width: 396px;
            text-align: center;
        }
        .style62
        {
            width: 155px;
            height: 26px;
        }
        .style63
        {
            width: 396px;
            height: 26px;
            text-align: center;
        }
        .style66
        {
            width: 396px;
            text-align: center;
            height: 59px;
        }
        .style67
        {
            width: 155px;
            text-align: center;
            height: 59px;
        }
        .style69
        {
            width: 155px;
            height: 26px;
            text-align: center;
        }
        .style70
        {
            width: 155px;
            text-align: center;
        }
        .style73
        {
            width: 155px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
            <strong style="text-align: center">MANTENIMIENTO DE PRODUCTOS ENLATADOS</strong></div>
    <table style="width:60%;" align="center" border="1">
        <tr>
            <td class="style57" colspan="2">
                <asp:Label ID="lblMensaje" runat="server" Height="30px" 
                    style="text-align: center; color: #FF0000; font-weight: 700; font-size: large" 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style73">
                &nbsp;</td>
            <td class="style60">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Código de Barras :</strong></span><br />
                </td>
            <td >
                <asp:TextBox ID="txtBarras" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC" Width="300px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Height="30px" 
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
                <asp:TextBox ID="txtNombre" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC; text-align: left;" Width="300px" 
                    Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style67">
                <span class="style11"><strong style="text-align: center">Fecha de Vencimiento :</strong></span></td>
            <td class="style66">
                Día:
                <asp:DropDownList ID="ddlDia" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
&nbsp;&nbsp; Mes:
                <asp:DropDownList ID="ddlMes" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
&nbsp; Año:
                <asp:DropDownList ID="ddlAnio" runat="server" Height="28px" 
                    style="color: #0000FF; font-size: small; text-align: center" Width="80px" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style70">
                <span class="style11"><strong style="text-align: center">Precio :</strong></span></td>
            <td class="style60">
                <asp:TextBox ID="txtPrecio" runat="server" Height="30px" 
                    style="font-size: large; color: #0033CC" Width="500px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style69">
            </td>
            <td class="style63">
                <asp:CheckBox ID="chkAbreFacil" runat="server" style="text-align: center" 
                    Text="Abre Fácil" Enabled="False" />
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
                <asp:Button ID="btnAlta" runat="server" Height="30px"  
                    style="text-align: center" Text="ALTA " Width="90px" 
                    Enabled="False" />
            &nbsp;<asp:Button ID="btnModificar" runat="server" Height="30px" 
                    style="text-align: center" Text="MODIFICAR " Width="90px" 
                     Enabled="False" />
            &nbsp;<asp:Button ID="btnBaja" runat="server" Height="30px"  
                    style="text-align: center" Text="BAJA " Width="90px" 
                    Enabled="False" />
                &nbsp;<asp:Button ID="btnLimpiar" runat="server" Height="30px" 
                    Text="LIMPIAR" Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style73">
                &nbsp;</td>
            <td class="style60">
                <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver al Menú Principal</asp:LinkButton>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
