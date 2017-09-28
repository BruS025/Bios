<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 773px">
                <tr>
                    <td colspan="3" class="style4" style="text-align: center"><strong>ABM Autos </strong></td>
                </tr>
                <tr>
                    <td>Matricula</td>
                    <td>
                        <asp:TextBox ID="TxtMatricula" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="5">
                        <asp:GridView ID="GVAutos" runat="server" Width="530px"
                            AutoGenerateSelectButton="True"
                            OnSelectedIndexChanged="GVAutos_SelectedIndexChanged">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>Marca</td>
                    <td>
                        <asp:TextBox ID="TxtMarca" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Modelo</td>
                    <td>
                        <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Duenio</td>
                    <td>
                        <asp:DropDownList ID="ddlDuenio" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAlta" runat="server" Text="Agregar"
                            OnClick="BtnAlta_Click" />
                    </td>
                    <td>
                        <asp:Button ID="BtnBaja" runat="server" Text="Borrar" OnClick="BtnBaja_Click" />
                        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>Buscar: <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox> </td>             
                    <td> <asp:Button ID="btBuscar" runat="server" Text="Buscar" OnClick="btBuscar_Click" /> </td>
                </tr>

                <td>Matricula</td>
                    <td>
                        <asp:TextBox ID="txtMatricula2" runat="server"></asp:TextBox>
                    </td>
                    
                <tr>
                    <td>Marca</td>
                    <td>
                        <asp:TextBox ID="txtMarca2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Modelo</td>
                    <td>
                        <asp:TextBox ID="txtModelo2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Duenio</td>
                    <td>
                        <asp:DropDownList ID="ddlDuenio2" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Precio</td>
                    <td>
                        <asp:TextBox ID="txtPrecio2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                        <td colspan="3">
                        <asp:Label ID="LblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Xml ID="XMLDespliego" runat="server" DocumentSource="~/XML/Autos.xml" TransformSource="~/XML/Autos.xslt"></asp:Xml>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
