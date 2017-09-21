<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Practico.aspx.cs" Inherits="Practico" %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
        </asp:Menu>
    
        <br />
        <uc1:WebUserControl ID="WebUserControl1" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbResultado" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
