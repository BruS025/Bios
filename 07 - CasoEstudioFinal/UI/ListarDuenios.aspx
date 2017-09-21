<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeFile="ListarDuenios.aspx.cs" Inherits="ListarDuenios" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
<div class="style3">
        <div class="style3">
        <strong><span style="font-size: large; text-decoration: underline">
            <br />
            <br />
            <br />
            <br />
        </span></strong>
            <table style="width:100%;">
                <tr >
                    <td colspan="3">
        <strong><span style="font-size: large; text-decoration: underline">
            Listado de Dueños</span></strong></td>
                </tr>
                <tr >
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr >
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:20%;"> &nbsp;</td>
                    <td style="width:60%;"> <asp:GridView ID="GVPropietarios" runat="server" 
                            Width="518px" AutoGenerateSelectButton="True" 
                            onselectedindexchanged="GVPropietarios_SelectedIndexChanged" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    <td colspan="3">
        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        Viviendas de:
                    <asp:Label ID="lblDuenio" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:20%;"> &nbsp;</td>
                    <td style="width:60%;"> 
                        <asp:GridView ID="GVViviendas" runat="server" 
                            Width="518px" 
                            onselectedindexchanged="GVPropietarios_SelectedIndexChanged" 
                            BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                            CellPadding="4" GridLines="Horizontal">
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView> </td>
                    <td style="width:20%;">&nbsp;</td>
                </tr>
            </table>

        </div>
        <div class="style3">
        <br />
            <br />
    
        </div>
    
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

