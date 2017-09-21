<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 566px; height: 151px;" border="1">
            <tr>
                <td style="width: 17238px">
                    <asp:Label ID="lblnumero" runat="server" Text="Numero"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtnumero" runat="server" BackColor="#00C0C0"></asp:TextBox>
                    </td>
                <td style="width: 413px">
                    <asp:Button ID="btnmostrar" runat="server" OnClick="btnmostrar_Click" Text="Buscar y Cargar Materia (Conectado)" Width="224px" /><br />
                    <asp:Button ID="btnMostrarDes" runat="server" OnClick="btnMostrarDes_Click" Text="Buscar y Cargar Materia (DesConectado)" Width="245px" /></td>
            </tr>
            <tr>
                <td style="width: 17238px">
                    <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtnombre" runat="server" BackColor="#00C0C0"></asp:TextBox></td>
                <td style="width: 413px">
                    </td>
            </tr>
            <tr>
                <td style="width: 17238px">
                    <asp:Label ID="lblcarga" runat="server" Text="Carga Horaria" Width="95px"></asp:Label></td>
                <td style="width: 190px">
                    <asp:TextBox ID="txtcarga" runat="server" BackColor="#00C0C0"></asp:TextBox></td>
                <td style="width: 413px">
                    </td>
            </tr>
            <tr>
                <td style="width: 17238px">
                </td>
                <td style="width: 190px">
                </td>
                <td style="width: 413px">
                </td>
            </tr>
            <tr>
                <td style="width: 17238px; height: 21px;">
                </td>
                <td style="height: 21px; width: 190px;">
                </td>
                <td style="height: 21px; width: 413px;">
                    <asp:Button ID="btnagregar" runat="server" OnClick="btnagregar_Click" Text="Agregar (Conectado con SQL)" Width="186px" /><br />
                    <asp:Button ID="btnagregarSp" runat="server" OnClick="btnagregarsp_Click" Text="Agregar (Conectada con SP)" Width="180px" /></td>
            </tr>
            <tr>
                <td style="width: 17238px">
                </td>
                <td style="width: 190px">
                    </td>
                <td style="width: 413px">
                    </td>
            </tr>
            <tr>
                <td style="width: 17238px">
                </td>
                <td style="width: 190px">
                </td>
                <td style="width: 413px">
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnmodificar_Click" Text="Modificar Materia  (Conectada Sin SP)" Width="233px" /></td>
            </tr>
            <tr>
                <td style="width: 17238px; height: 21px;">
                </td>
                <td style="width: 190px; height: 21px;">
                </td>
                <td style="width: 413px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 17238px">
                </td>
                <td style="width: 190px">
                </td>
                <td style="width: 413px">
                    <asp:Button ID="btnParamOutPut" runat="server" Text="Consulta con Parametros de Salida (Conectado)" OnClick="btnParamOut_Click" Width="290px" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblresultado" runat="server" Width="595px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="lnkdataset" runat="server" PostBackUrl="~/actalizardataset.aspx">Ir a Actualizacion DataSet</asp:LinkButton></td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 438px" border="1">
            <tr>
                <td style="width: 55px">
                    <asp:Button ID="btnListarMaterias" runat="server" OnClick="btnlistar_Click" Text="Listar Materias (Conectado)" Width="180px" /></td>
                <td style="width: 415px; text-align: center">
                    <asp:ListBox ID="lstmaterias" runat="server" Height="137px" Width="358px"></asp:ListBox></td>
            </tr>
            <tr>
                <td style="width: 55px">
                </td>
                <td style="width: 415px">
                </td>
            </tr>
            <tr>
                <td style="width: 55px">
                    <asp:Button ID="BtnListarAlumnos" runat="server" OnClick="btnalumos_Click" Text="Listar Alumnos (Conectado)" Width="180px" /></td>
                <td style="width: 415px; text-align: center">
                    <asp:ListBox ID="LBAlumnos" runat="server" Height="137px" Width="358px"></asp:ListBox>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 55px">
                </td>
                <td style="width: 415px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 55px">
                    <asp:Button ID="btngrilla" runat="server" OnClick="btngrilla_Click" Text="Listar Materias (Desconectado)" Width="190px" /></td>
                <td style="width: 415px; text-align: center">
        <asp:GridView ID="grdmaterias" runat="server" Width="365px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
