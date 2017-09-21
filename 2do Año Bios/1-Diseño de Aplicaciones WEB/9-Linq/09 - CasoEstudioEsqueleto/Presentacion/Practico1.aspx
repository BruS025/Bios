<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Practico1.aspx.cs" Inherits="Practico1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 597px">
    
        <asp:Button ID="btnMail30" runat="server" OnClick="btnMail30_Click" Text="Mail &gt; 30" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUsuariosNombre" runat="server" OnClick="btnUsuariosNombre_Click" Text="Usuarios por Nombre" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAndresito" runat="server" OnClick="btnAndresito_Click" Text="Mail Andresito" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="mail &gt; 10 o &quot; &quot;" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Nombre Envia Recibe" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" Text="Nombre que envio y cantidad" OnClick="Button6_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button7" runat="server" Text="nombre que envio &gt; 3 mail y cant" OnClick="Button7_Click" />
    
        <br />
        <asp:GridView ID="gvMostrar" runat="server" OnSelectedIndexChanged="Page_Load">
        </asp:GridView>
        <br />
        <br />
        <br />
        LINQ TO ADO<br />
        <br />
        Generar mediante Linq to Ado (DataSet) las siguientes consultas:
        <br />
        1.- Mostrar los mails con el nombre real de su usuario de envío
        <asp:Button ID="ado1" runat="server" OnClick="ado1_Click" Text="1" />
        <br />
        2.- Determinar la cantidad de mails recibidos por cada usuario
        <asp:Button ID="ado2" runat="server" OnClick="ado2_Click" style="height: 26px" Text="2" />
        <br />
        3.- Mostrar solo los usuarios con más de 3 mails recibidos <asp:Button ID="ado3" runat="server" Text="3" />
        <br />
        4.- Mostrarla cantidad total de mails que tienen asunto de más de 10 caracteres o texto del mail vacío<asp:Button ID="ado4" runat="server" Text="4" />
        <br />
        <asp:GridView ID="gvAdoMostrar" runat="server">
        </asp:GridView>
        <br />
        Grilla caso 2<br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField AccessibleHeaderText="NombreCompleto" DataField="NombreCompleto" />
                <asp:BoundField AccessibleHeaderText="Texto" DataField="Texto" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
