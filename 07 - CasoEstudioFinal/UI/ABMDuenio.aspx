<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ABMDuenio.aspx.cs" Inherits="ABMDuenio" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
<div>
    
        <table style="width: 605px" border="1" align="center" >
            <tr>
                <td class="style1" style="text-align: center" colspan="3">
                    <asp:Label ID="Label3" runat="server" Font-Size="30pt" Text="Agregar Personas" 
                        style="font-size: large; font-weight: 700"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;Cedula</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: center;">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" Width="112px" />
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;Nombre</td>
                <td style="width: 460px; text-align: left;">
                    <asp:TextBox ID="txtNombre" runat="server" Width="191px"></asp:TextBox>
                </td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px; text-align: left">
                    &nbsp;</td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
                <td style="width: 460px; text-align: left;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 604px">
                    &nbsp;</td>
                <td style="width: 460px">
                    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                        Text="Agregar" />
                &nbsp;
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        Text="Modificar" />
                &nbsp;
                    <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                        Text="Eliminar" />
                </td>
                <td style="width: 460px">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar / Deshacer" Width="114px" />
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    <asp:Label ID="lblError" runat="server" Width="260px"></asp:Label>
                </td>
            </tr>
            </table>
      </div>
</asp:Content>