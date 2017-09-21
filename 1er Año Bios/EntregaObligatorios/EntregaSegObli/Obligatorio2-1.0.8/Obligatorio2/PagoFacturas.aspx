<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoFacturas.aspx.cs" Inherits="Obligatorio2.PagoFacturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Pago de facturas</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/>
</head>
<body>
    <form id="form1" runat="server">

           <header>
        <div class="container">
            <h1><b>Pago de facturas</b></h1>
        </div>  
    </header>

    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Image ID="ImagenLogo" runat="server" Height="274px" ImageUrl="~/Imagenes/logoObligatorio2.jpg" Width="345px" />
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbFacturaBuscar" runat="server" Text="Buscar factura:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtFacturaBusqueda" runat="server" MaxLength="9" Font-Size="Large"></asp:TextBox>
                &nbsp;<asp:Button ID="btFacturaBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btFacturaBuscar_Click" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbTipoFactura" runat="server" Text="Seleccione tipo de facturas a desplegar:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlTipoFactura" runat="server" AutoPostBack="True" Font-Size="Large" OnSelectedIndexChanged="ddlTipoFactura_SelectedIndexChanged" Width="160px">
                    <asp:ListItem Selected="True" Value="0">Pendientes</asp:ListItem>
                    <asp:ListItem Value="1">Finalizadas</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="col-md-12 col-lg-12 text-center hidden-xs hidden-sm">               
                <asp:GridView ID="gridFacturaPagas" runat="server" CellPadding="4" Height="100px" Width="95%" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" Font-Size="Large" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NumeroVenta" HeaderText="Número de factura" />
                        <asp:BoundField DataField="DocumentoCliente" HeaderText="Documento" />
                        <asp:BoundField DataField="CodigoBarra" HeaderText="Código" />
                        <asp:BoundField DataField="FechaVenta" HeaderText="Fecha de venta" />
                        <asp:BoundField DataField="FechaPago" HeaderText="Fecha de pago" />
                        <asp:BoundField DataField="TotalVenta" HeaderText="Importe" />
                        <asp:BoundField DataField="CantidadProducto" HeaderText="Cantidad" />
                        <asp:CheckBoxField DataField="Pago" HeaderText="Estado factura" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>

            <div class="col-md-12 col-lg-12 text-center hidden-xs hidden-sm">               
                <asp:GridView ID="gridFacturaAgendadas" runat="server" CellPadding="4" Height="100px" Width="95%" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" Font-Size="Large" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NumeroVenta" HeaderText="Número de factura" />
                        <asp:BoundField DataField="DocumentoCliente" HeaderText="Documento" />
                        <asp:BoundField DataField="CodigoBarra" HeaderText="Código" />
                        <asp:BoundField DataField="FechaVenta" HeaderText="Fecha de venta" />
                        <asp:BoundField DataField="TotalVenta" HeaderText="Importe" />
                        <asp:BoundField DataField="CantidadProducto" HeaderText="Cantidad" />
                        <asp:CheckBoxField DataField="Pago" HeaderText="Estado factura" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br />
            </div>

            <div class="col-sm-12 text-center hidden-xs hidden-md hidden-lg">               
                <asp:GridView ID="gridTablet" runat="server" CellPadding="4" Height="95%" Width="95%" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" Font-Size="Large" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NumeroVenta" HeaderText="Número de factura" />
                        <asp:BoundField DataField="DocumentoCliente" HeaderText="Documento" />
                        <asp:BoundField DataField="CodigoBarra" HeaderText="Código" />
                        <asp:BoundField DataField="TotalVenta" HeaderText="Importe" />
                        <asp:CheckBoxField DataField="Pago" HeaderText="Estado factura" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br />
            </div>

            <div class="col-xs-12 text-center hidden-sm hidden-md hidden-lg">               
                <asp:GridView ID="gridPhone" runat="server" CellPadding="4" Height="95%" Width="95%" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" Font-Size="Large" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NumeroVenta" HeaderText="N° factura" />
                        <asp:BoundField DataField="TotalVenta" HeaderText="Importe" />
                        <asp:CheckBoxField DataField="Pago" HeaderText="Estado" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbFacturaResultado" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btFacturaVolver" runat="server" OnClick="btFacturaVolver_Click" Text="Volver" Width="100px" Font-Size="Small" />
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btFacturaPagar" runat="server" Text="Pagar" Width="100px" OnClick="btFacturaPagar_Click" Visible="False" Font-Size="Small" />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
    </div>

<div class="color1 navbar navbar-inverse navbar-fixed-bottom">
    <div class="container">
        <div class="navbar-text pull-left">
            <p><em>Obligatorio 2 - Año 1 - Analista de sistemas. 2016</em></p>
        </div>
    </div>
</div>

</form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
