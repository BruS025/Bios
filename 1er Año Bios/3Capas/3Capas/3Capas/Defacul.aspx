<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defacul.aspx.cs" Inherits="_3Capas.Defacul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox ID="lstListar" runat="server"></asp:ListBox>
        <asp:Button ID="bListar" runat="server" OnClick="bListar_Click" Text="Listar Alumnos" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LnkbAgregarAlumno" runat="server" OnClick="LnkbAgregarAlumno_Click">Agregar Alumnos</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbModificarAlumno" runat="server" PostBackUrl="~/Paginas/ModificarAlumno.aspx">Modificar Alumno</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbEliminarAlumno" runat="server" PostBackUrl="~/Paginas/Alumno/EliminarAlumno.aspx">Eliminar Alumno</asp:LinkButton>
        <br />
        <asp:ListBox ID="lstMaterias" runat="server"></asp:ListBox>
        <asp:Button ID="btListMatConectado" runat="server" OnClick="Button1_Click" Text="Listar Materias Conectado" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkBAgregarMateria" runat="server" OnClick="lnkBAgregarMateria_Click">Agregar Materia</asp:LinkButton>
        <br />
        <br />
    </form>
</body>
</html>
