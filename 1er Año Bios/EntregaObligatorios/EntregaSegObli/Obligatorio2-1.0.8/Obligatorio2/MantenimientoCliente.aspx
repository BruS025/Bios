<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoCliente.aspx.cs" Inherits="Obligatorio2.MantenimientoClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Mantenimiento de clientes</title>
    	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Mantenimiento de clientes</b></h1>
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

            <div class="hidden-xs col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center ">               
                <asp:Label ID="lbGestionClientesBuscar" runat="server" Text="Buscar cliente:" Font-Size="Large" Font-Bold="True"></asp:Label>
                &nbsp;<asp:TextBox ID="txtClientesBuscar" runat="server" MaxLength="30" Font-Size="Large"></asp:TextBox>               
                &nbsp;<asp:Button ID="btGestionClientesBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btGestionClientesBuscar_Click" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Button ID="btGestionClientesAgregar" runat="server" Text="Agregar" Width="100px" OnClick="btGestionClientesAgregar_Click" Font-Size="Small" />
                &nbsp;<asp:Button ID="btMantenimientoClienteModificar" runat="server" OnClick="btMantenimientoClienteModificar_Click" Text="Modificar" Width="100px" Font-Size="Small" />
                &nbsp;<asp:Button ID="btGestionClientesEliminar" runat="server" Text="Eliminar" Width="100px" OnClick="btGestionClientesEliminar_Click" Font-Size="Small" />
                <br />
                <br />
            </div>

            <div class="hidden-xs col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
            <asp:GridView ID="gridListadoClientes" runat="server" CellPadding="4" Height="100px" Width="600px" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Cédula" HeaderText="Cédula" SortExpression="Cédula" />
                    <asp:BoundField DataField="Dirección" HeaderText="Dirección" SortExpression="Dirección" />
                    <asp:BoundField DataField="Teléfono" HeaderText="Teléfono" SortExpression="Teléfono" />
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Bottom" />
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

            <div class="hidden-sm hidden-md hidden-lg col-xs-12 text-center">               
            <asp:GridView ID="gridListadoClientesMobile" runat="server" CellPadding="4" Height="100px" Width="95%" ForeColor="#333333" GridLines="None" Visible="False" ShowHeaderWhenEmpty="True" ShowFooter="True" HorizontalAlign="Center" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Cédula" HeaderText="Cédula" SortExpression="Cédula" />
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" SortExpression="Descuento" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Bottom" />
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
                <asp:Button ID="btMantenimientoClientesVolver" runat="server" OnClick="btMantenimientoClientesVolver_Click" Text="Volver" Width="100px" />
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbMantenimientoClientesResultado" runat="server"></asp:Label>
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
