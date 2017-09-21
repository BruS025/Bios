<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ListarCantidadesViviendas.aspx.cs" Inherits="ListarCantidadesViviendas" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
    <div style="text-align: center">
        <span class="style3" ><strong>
        <br />
        <br />
        <br />
        </strong></span><br />
    
   
            <table style="width:100%;">
                <tr >
                    <td colspan="3">
        <strong><span style="font-size: large; text-decoration: underline">
                        Listado con Variables OutPut</span></strong></td>
                </tr>
                <tr >
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr >
                    <td colspan="3">
                       <asp:Button ID="BtnListar" runat="server" Text="Listar" onclick="BtnListar_Click" 
                             /></td>
                </tr>
                <tr >
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:20%;"> &nbsp;</td>
                    <td style="width:60%;"> 
                        Cantidad de Apartamentos:
                    <asp:Label ID="lblAptos" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" class="style4">
                        Cantidad de Casas:
                    <asp:Label ID="lblCasas" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

   
         </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            font-size: large;
        }
        .style4
        {
            height: 28px;
        }
    </style>
</asp:Content>

