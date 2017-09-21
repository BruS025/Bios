<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ListarViviendas.aspx.cs" Inherits="ListarViviendas" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
    <div style="text-align: center">
        <span class="style3" ><strong>
        <br />
        <br />
        <br />
        </strong></span><br />
    
   
            <table style="width:100%;">
                <tr >
                    <td colspan="4">
        <strong><span style="font-size: large; text-decoration: underline">
            Listado de 
        <span class="style3" >Viviendas</span></span></strong></td>
                </tr>
                <tr >
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr >
                    <td colspan="2" style="width:50%;">
                        Seleccione:
        <asp:DropDownList ID="DdlTipo" runat="server">
            <asp:ListItem>Todo</asp:ListItem>
            <asp:ListItem>Solo Casas</asp:ListItem>
            <asp:ListItem>Solo Aptos</asp:ListItem>
        </asp:DropDownList>
                        
                        </td>
                    <td colspan="2" style="width:50%;">
                       <asp:Button ID="BtnListar" runat="server" OnClick="BtnListar_Click" Text="Listar" /></td>
                </tr>
                <tr >
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr >
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:20%;"> &nbsp;</td>
                    <td style="width:60%;" colspan="2"> 
                        <asp:GridView ID="GvViviendas" runat="server" 
                            Width="518px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView> </td>
                    <td style="width:20%;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
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
    </style>
</asp:Content>

