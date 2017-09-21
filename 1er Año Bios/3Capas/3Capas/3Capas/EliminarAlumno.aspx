<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarAlumno.aspx.cs" Inherits="_3Capas.EliminarAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbCiEliminar" runat="server" Text="Ci"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCiEliminar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBuscarEliminar" runat="server" OnClick="btBuscarEliminar_Click" Text="Buscar" />
        <br />
        <br />
        <asp:Label ID="lbNombreEliminar" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombreEliminar" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbGeneracionEliminar" runat="server" Text="Generacion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtGeneracionEliminar" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="lbNomCalleEliminar" runat="server" Text="Nombre Calle"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNomCalleEliminar" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbNroPuertaEliminar" runat="server" Text="Nro Puerta"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNroPuertaEliminar" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btEliminarAlumno" runat="server" Text="Eliminar" />
        <br />
        <br />
        <asp:Label ID="lbResultadoEliminarAlumno" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
