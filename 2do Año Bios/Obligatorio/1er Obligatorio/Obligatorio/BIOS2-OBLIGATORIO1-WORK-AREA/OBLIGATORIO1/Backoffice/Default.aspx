<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
    <link rel="stylesheet" href="CSS/estilo.css"/>
</head>

<body>
    <header>
        <div class="titulo">
            <h1><strong>Login</strong></h1>
        </div>  
    </header>

    <form id="DefaultForm1" runat="server" class="recuadro">
    <div runat="server">
        <h4 class="texto">Nombre</h4>
        <asp:TextBox ID="TxtNombre" runat="server" CssClass="campo"></asp:TextBox>
        <br />
        <h4 class="texto">Contraseña</h4>
        <asp:TextBox ID="TxtContraseña" runat="server" TextMode="Password" CssClass="campo"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnLogin" runat="server" Text="ENTRAR" CssClass="boton" OnClick="BTLogin_Click" />
        
        <br />
        <br />
        <asp:Label ID="LBResultado" runat="server" CssClass="resultado"></asp:Label>
        
    </div>
    </form>
</body>
</html>

