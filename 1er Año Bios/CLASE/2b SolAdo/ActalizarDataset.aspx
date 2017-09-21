<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActalizarDataset.aspx.cs" Inherits="actalizardataset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 352px; height: 321px">
            <tr>
                <td colspan="1" style="height: 197px; width: 341px;">
                    <asp:GridView ID="grdmaterias" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" Width="422px" Height="239px">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                    <asp:Button ID="btnlistar" runat="server" OnClick="btnlistar_Click" Text="Listar en la grilla" /></td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                    <asp:Button ID="btnborrar" runat="server" OnClick="btnborrar_Click" Text="Borrar carga horaria" Width="139px" /></td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                    <asp:Button ID="btnactualizar" runat="server" OnClick="btnactualizar_Click" 
                        Text="Actualizar base" /></td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                </td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                    <asp:Label ID="lblerror" runat="server" Width="318px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 341px; height: 1px">
                    <asp:LinkButton ID="lnkdefecto" runat="server" PostBackUrl="~/Default.aspx">Ir a Default</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
