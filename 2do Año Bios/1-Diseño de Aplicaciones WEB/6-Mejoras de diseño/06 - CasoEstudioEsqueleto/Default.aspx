<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="style1">Ejemplos de Hoja de Estilos En Cascada</span><br />
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/Css/PaginaConEstilo.htm">Uso CSS</asp:HyperLink>
        <br />
        <br />
    
        <span class="style1">Ejemplos de MasterPages Themes Skins</span><br />
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/MasterPages - Themes - Skins/WFListados.aspx">Ejemplo de Uso 
        de mas de un tipo de Navegador</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/MasterPages - Themes - Skins/WFEjemplo.aspx">Ejemplo de Uso 
        de Themes y Skins</asp:HyperLink>
        <br />
        <br />
    
        <br />
    
    </div>
    </form>
</body>
</html>
