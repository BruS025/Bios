<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ABMApartamento.aspx.cs" Inherits="ABMApartamento" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
<div>
        <table style="width: 749px; empty-cells: show;" border="1" align="center" >
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td style="width: 407px; " class="style3" colspan="2">
                    <strong><span style="font-size: large; text-align: center">Mantenimiento Apartamento</span></strong></td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label1" runat="server" Text="Padron:"></asp:Label>
                </td>
                <td style="text-align: left;" class="style2">
                    <asp:TextBox ID="txtPadron" runat="server" Width="147px" >0</asp:TextBox>
                </td>
                <td style="width: 350px; text-align: left;">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
                        onclick="BtnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td style="width: 207px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="372px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Fecha de Construcción"></asp:Label>
                </td>
                <td style="width: 207px; height: 185px;" colspan="2">
                    <asp:Calendar ID="Calendario" runat="server" Height="136px" Width="172px"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Alquiler:"></asp:Label>
                </td>
                <td style="width: 207px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtAlquiler" runat="server" Width="119px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label7" runat="server" Text="Portero"></asp:Label>
                </td>
                <td style="width: 207px; text-align: left;" colspan="2">
                    <asp:CheckBox ID="chkPortero" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label8" runat="server" Text="Piso"></asp:Label>
                </td>
                <td style="width: 207px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtPiso" runat="server" Width="81px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" class="style3">
                    <asp:Label ID="Label9" runat="server" Text="Gastos Comunes"></asp:Label>
                </td>
                <td style="width: 207px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtGastosComunes" runat="server" Width="113px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Dueño</td>
                <td style="width: 600px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtDuenioCedula" runat="server" Width="154px"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnBuscoDuenio" runat="server" Text="Buscar Dueño" 
                        onclick="btnBuscoCliente_Click" />
                &nbsp; <asp:Label ID="lblDuenio" runat="server" Width="180px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td style="width: 207px" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td style="width: 450px" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                        Text="Agregar" />
                &nbsp;
                    <asp:Button ID="BtnModificar" runat="server" 
                        Text="Modificar" onclick="BtnModificar_Click" />
                &nbsp;
                    <asp:Button ID="BtnEliminar" runat="server" 
                        Text="Eliminar" onclick="BtnEliminar_Click" />
                &nbsp;
                    <asp:Button ID="BtnLimpiar" runat="server" 
                        Text="Limpiar / Deshacer" onclick="BtnLimpiar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td style="width: 207px" colspan="2">
                    <asp:Label ID="lblError" runat="server" Width="467px"></asp:Label></td>
            </tr>
            </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>
