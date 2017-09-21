<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Facturacion.aspx.cs" Inherits="Facturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facturas</title>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div>
        <script>
            <%=Mensajes %>
        </script>
    <center>
        <br />
        <h2> GENERAR FACTURAS </h2>
        <br />
        <asp:Label ID="lblNroFactura" runat="server" Text="Nro Factura"></asp:Label>
&nbsp;<asp:TextBox ID="txtNroFactura" type="number" runat="server" Width="35px"></asp:TextBox>
        &nbsp;
        <asp:Button ID="bntBuscarFactura" runat="server" Text="Buscar" OnClick="bntBuscarFactura_Click" />
&nbsp;
        <asp:Label ID="lblCliente" runat="server" Text="Cliente "></asp:Label>
        <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblArtCodigo" runat="server" Text="Código"></asp:Label>
&nbsp;<asp:TextBox ID="txtArtCodigo" type="number" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="bntBuscar" runat="server" Text="Buscar artículo" OnClick="bntBuscar_Click" />
        <br />
        <br />
        <asp:Label ID="lblArticulo" runat="server" Text="Busque un artículo"></asp:Label>
&nbsp;
        <br />
        <br />
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
&nbsp;<asp:TextBox ID="txtCantidad" type="number" runat="server" Width="49px">1</asp:TextBox>
&nbsp;
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar artículo" OnClick="btnAgregar_Click" />
        <br />
        <br />
        <asp:GridView ID="grdLineas" runat="server" OnRowCommand="grdLineas_RowCommand">
            <Columns>
                <asp:ButtonField CommandName="Quitar" Text="Quitar" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar factura" OnClick="btnGrabar_Click" />
        &nbsp;<asp:Button ID="btnEliminar2" runat="server" OnClick="btnEliminar_Click" Text="Eliminar factura" Visible="False" />
        &nbsp;<asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar factura" Visible="False" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </center>
    </div>
    </form>
</body>
</html>
