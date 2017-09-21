<%@ Page Language="C#" AutoEventWireup="true" CodeFile="05-ControlRepeater.aspx.cs" Inherits="_05_ControlRepeater" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">




        .style1
        {
            color: #FF0000;
            font-weight: bold;
            text-align: center;
        }
        .style2
        {
            color: #006600;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    <div> 
    <p class="style1">
        Ejemplo de Uso de Repeater</p>
            <p class="style2">
                Listado de todas las Familias</p>
        <asp:Repeater ID="rtArticulos" runat="server" OnItemCommand="rtArticulos_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr bgcolor="Blue">
                        <td>
                            Codigo:<asp:TextBox ID ="TxtCodigo" runat="server" Text = '<%# Bind("Codigo") %>'></asp:TextBox>
                            <br />
                        </td>
                        <td>
                            Nombre: <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                            <br />
                        </td>
                        <td>
        <asp:Button ID="Button1" runat ="server" CommandName="Borrar" style="text-align : center" Text="Borrar" />
        <asp:Button ID="Button2" runat="server" CommandName ="Listar" style="text-align:center" Text ="Listar Articulos" />
                        </td>
                        </tr>
                </table>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <table>
                    <tr bgcolor="Red">
                        <td>
                            Codigo:<asp:TextBox ID ="TxtCodigo" runat="server" Text = '<%# Bind("Codigo") %>'></asp:TextBox>
                            <br />
                        </td>
                        <td>
                            Nombre: <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                            <br />
                        </td>
                        <td>
        <asp:Button ID="Button1" runat ="server" CommandName="Borrar" style="text-align : center" Text="Borrar" />
        <asp:Button ID="Button2" runat="server" CommandName ="Listar" style="text-align:center" Text ="Listar Articulos" />
                        </td>
                        </tr>
                </table>
            </AlternatingItemTemplate>
        </asp:Repeater>
        <p>
                &nbsp;</p>
        <p class="style2">
                Articulos de una Familia</p>
        <p class="style2">
                <asp:GridView ID="gvArticulos" runat="server">
                </asp:GridView>
        </p>
        <p>
                &nbsp;</p>
    <asp:Label ID="LblError" runat="server"></asp:Label>
    <br />
    <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        
    </div>
    </form>

 

</body>
</html>
