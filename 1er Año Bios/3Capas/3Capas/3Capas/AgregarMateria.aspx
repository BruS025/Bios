<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMateria.aspx.cs" Inherits="_3Capas.AgregarMateria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LbNombre" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LbCargaHoraria" runat="server" Text="CargaHoraria"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCargaHoraria" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LbId" runat="server" Text="Id"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btAgregarMateria" runat="server" OnClick="btAgregarMateria_Click" Text="Agregar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbVolverAgregarMateria" runat="server" OnClick="lnkbVolverAgregarMateria_Click">Volver</asp:LinkButton>
        <br />
        <asp:Label ID="lbResultadoAgregarMateria" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
