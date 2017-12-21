<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RepasoBios.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <meta charset="utf-8" />
        <b id="docs-internal-guid-e13d783c-6c81-7fe8-6c73-89309d0adde2" style="font-weight:normal;"><span style="font-size:11pt;font-family:Arial;color:#000000;background-color:transparent;font-weight:400;font-style:normal;font-variant:normal;text-decoration:none;vertical-align:baseline;white-space:pre;white-space:pre-wrap;">Se desea realizar un listado de todos los cheques que sean de un cliente y cuenta determinado<br />
        <br />
        Cliente
        <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Cuenta<asp:TextBox ID="txtCuenta" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btConsultaCheques" runat="server" OnClick="btConsultaCheques_Click" Text="Button" />
        </span></b>
    
    </div>
    </form>
</body>
</html>
