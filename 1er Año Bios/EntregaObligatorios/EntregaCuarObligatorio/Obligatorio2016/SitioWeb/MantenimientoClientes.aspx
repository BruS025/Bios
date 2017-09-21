<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoClientes.aspx.cs" Inherits="MantenimientoClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            font-size: large;
            font-family: "Arial Narrow";
        }
        .style4
        {
            text-decoration: underline;
            color: #00CC00;
            font-size: 15pt;
            text-align: center;
        }
        .style11
        {
            font-size: small;
        }
        .style14
        {
            font-size: large;
            text-align: left;
        }
        .style29
        {
            height: 26px;
            width: 517px;
        }
        .style40
        {
            height: 26px;
            text-align: center;
            width: 96px;
        }
        .style42
        {
            width: 96px;
            height: 13px;
        }
        .style43
        {
            width: 517px;
            height: 13px;
        }
        .style51
        {
            height: 26px;
            text-align: center;
        }
        .style56
        {
            width: 96px;
            text-align: center;
            height: 35px;
        }
        .style57
        {
            width: 517px;
            height: 35px;
        }
        .style58
        {
            height: 49px;
            text-align: center;
            width: 96px;
        }
        .style59
        {
            width: 517px;
            height: 49px;
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style3">
    
        <p class="style4" 
            style="margin-left: 6px; width: 1030px; height: 33px; margin-top: 0px;">
            <strong style="text-align: left">MANTENIMIENTO DE CLIENTES</strong></p>
    
    </div>
    <table style="width:60%;" border="1" align="center">
        <tr>
            <td class="style14" colspan="2" style="text-align: center">
                <asp:Label ID="lblMensaje" runat="server" Height="28px" 
                    style="font-size: 15pt; color: #FF0000" 
                    Text="lblMensaje"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style42">
                </td>
            <td class="style43">
                </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Cédula de Identidad :</strong></span><br />
                </td>
            <td class="style57">
                <asp:TextBox ID="txtCedula" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Height="30px" 
                     style="text-align: center" Text="BUSCAR " 
                    Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Dirección :</strong></span></td>
            <td class="style57">
                <asp:TextBox ID="txtDir" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Teléfono :</strong></span><br class="style11" />
                </td>
            <td class="style57">
                <asp:TextBox ID="txtTel" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                <span class="style11"><strong>Nombre Completo :</strong></span><br 
                    class="style11" />
                </td>
            <td class="style57">
                <asp:TextBox ID="txtNombre" runat="server" Height="25px" 
                    style="font-size: small; color: #0066FF" Width="300px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style40">
                </td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style58">
                </td>
            <td class="style59">
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
            <td class="style51" colspan="2">
               
                <asp:HyperLink ID="lnkVolver" runat="server" NavigateUrl="~/Default.aspx" 
                    style="font-size: large" Width="235px">Volver al Menú Principal</asp:HyperLink>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
