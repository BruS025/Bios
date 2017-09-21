<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarAlumno.aspx.cs" Inherits="_3Capas.AgregarAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbCI" runat="server" Text="C.I"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCiAlumno" runat="server" EnableTheming="False"></asp:TextBox>
        <br />
        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombreAlumno" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbGeneracion" runat="server" Text="Generacion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtGeneracionAlumno" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbNomCalle" runat="server" Text="Nombre Calle"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombreCalleAlumno" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbNroPuerta" runat="server" Text="Nro Puerta"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNroPuertaAlumno" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btGuardarAlumno" runat="server" OnClick="btGuardarAlumno_Click" Text="Guardar" />
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbVolverAgregarAlumno" runat="server" OnClick="lnkbVolverAgregarAlumno_Click">Volver</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lbResultadoGuardarAlumno" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
