<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            color: #FF0066;
            text-decoration: underline;
        }
        .style2
        {
            width: 240px;
        }
        .style3
        {
            width: 316px;
        }
        .style4
        {
            width: 316px;
            color: #CC0000;
            font-weight: bold;
            text-decoration: underline;
        }
        .style5
        {
            width: 240px;
            color: #660033;
        }
        .style6
        {
            width: 316px;
            color: #660033;
            font-weight: bold;
            text-decoration: underline;
        }
        .style7
        {
            width: 240px;
            color: #660033;
            font-weight: bold;
        }
        .style8
        {
            width: 316px;
            color: #660033;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    &nbsp;<table style="width: 62%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
    
        <b><span class="style1">Agregar Alumnos a La Universidad</span></b></td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Nombre:</td>
            <td class="style3">
                <asp:TextBox ID="TxtNom" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Apellido:
            </td>
            <td class="style3">
                <asp:TextBox ID="TxtApe" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="BtnAgregarAlumno" runat="server" 
                    onclick="BtnAgregarAlumno_Click" Text="Agregar " />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Nombre Materia :</td>
            <td class="style3">
                <asp:TextBox ID="txtAgregarMateria" runat="server"></asp:TextBox>
                <asp:Button ID="btnAgregarMateria" runat="server" 
                    onclick="BtnAgregarMateria_Click" Text="Agregar " />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                Inscribir Alumnos en Materias</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                Lista Alumnos de la Universidad</td>
            <td class="style8">
                Lista Materia de la Universidad</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:ListBox ID="LbAlumnos" runat="server" Height="87px" Width="228px"></asp:ListBox>
            </td>
            <td class="style4">
                <asp:ListBox ID="LbMaterias" runat="server" Height="79px" Width="284px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:Button ID="BtnInscribir" runat="server"  Text="Inscribir" 
                    onclick="BtnInscribir_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
