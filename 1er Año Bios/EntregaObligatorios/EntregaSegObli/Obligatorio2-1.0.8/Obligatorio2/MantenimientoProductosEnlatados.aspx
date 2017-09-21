<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoProductosEnlatados.aspx.cs" Inherits="Obligatorio2.MantenimientoProductosEnlatados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Mantenimiento de productos enlatados</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Mantenimiento de productos enlatados</b></h1>
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
                <asp:Label ID="lbGestionEnlatadosBuscar" runat="server" Text="Buscar producto:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:TextBox ID="txtManProdEnlatados" runat="server" MaxLength="30" Font-Size="Large"></asp:TextBox>
                &nbsp;&nbsp;<asp:Button ID="btGestionEnlatadosBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btGestionEnlatadosBuscar_Click" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btGestionEnlatadosAgregar" runat="server" Text="Agregar" Width="100px" OnClick="btGestionEnlatadosAgregar_Click" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btMantenimientoProductosEnlatadosModificar" runat="server" Text="Modificar" Width="100px" OnClick="btMantenimientoProductosEnlatadosModificar_Click" Font-Size="Small" />
                &nbsp;&nbsp;<asp:Button ID="btMantenimientoEnlatadosEliminar" runat="server" Text="Eliminar" Width="100px" OnClick="btMantenimientoEnlatadosEliminar_Click" Font-Size="Small" />
                <br />
                <br />
             </div>

            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 text-center col-md-offset-2 col-lg-offset-2 hidden-xs">               
                <asp:GridView ID="gridListadoProductosEnlatados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="700px" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código de barras" SortExpression="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Vencimiento" HeaderText="Fecha de vencimiento" SortExpression="Vencimiento" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:CheckBoxField DataField="Abrefácil" HeaderText="Abrefácil" />
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

            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 text-center hidden-sm hidden-md hidden-lg">               
                <asp:GridView ID="gridListadoProductosEnlatadosMobile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="95%" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código de barras" SortExpression="Código" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:CheckBoxField DataField="Abrefácil" HeaderText="Abrefácil" />
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
                <asp:Label ID="lbGestionEnlatadosResultado" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btMantenimientosProductosEnlatadosVolver" runat="server" OnClick="btMantenimientosProductosEnlatadosVolver_Click" Text="Volver" Width="100px" Font-Size="Small" />
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
