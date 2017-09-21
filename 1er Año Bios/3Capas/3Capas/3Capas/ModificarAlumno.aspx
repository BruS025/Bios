<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarAlumno.aspx.cs" Inherits="_3Capas.ModificarAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 344px">
    <form id="form1" runat="server">
    <div style="height: 338px">
    
        <asp:Label ID="lbCiModAlumno" runat="server" Text="Ci Alumno"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCiModificar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBuscarMod" runat="server" OnClick="btBuscarMod_Click" Text="Buscar" />
        <br />
        <br />
        <asp:Label ID="lbNombreModAlumno" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombreModificar" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbGeneracionMod" runat="server" Text="Generacion"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtGeneracionModificar" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbNomCalleMod" runat="server" Text="Nombre Calle"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNomCalleModificar" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbNroPuertaMod" runat="server" Text="Nro Puerta"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNroPuertaModificar" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btGuardarMod" runat="server" OnClick="btGuardarMod_Click" Text="Guardar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbVolverMoficar" runat="server" OnClick="lnkbVolverMoficar_Click" PostBackUrl="~/Paginas/Defacul.aspx">Volver</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lbResultadoModificar" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
