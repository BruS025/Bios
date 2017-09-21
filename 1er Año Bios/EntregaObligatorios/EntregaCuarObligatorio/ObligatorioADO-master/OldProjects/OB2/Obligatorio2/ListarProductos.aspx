<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarProductos.aspx.cs" Inherits="Obligatorio2.ListarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
	<title>Listado de productos</title>
	<meta name="viewport" content="width=device-width,user-scalable=no,initial-scalable=1.0,maximum-scale=1.0,minimum-scale=1.0"/>
	<link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/estilos.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <div class="container">
            <h1><b>Listado de productos</b></h1>
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
                <asp:Label ID="lbTipoProductos" runat="server" Text="Seleccione tipo de productos a desplegar:" Font-Bold="True" Font-Size="Large"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlTipoProductos" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoProductos_SelectedIndexChanged" Font-Size="Large">
                <asp:ListItem Selected="True" Value="0">Productos congelados</asp:ListItem>
                <asp:ListItem Value="1">Productos enlatados</asp:ListItem>
                </asp:DropDownList>      
                <br />
                <br />
            </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">               
                <asp:Label ID="lbListadoProductosError" runat="server" Visible="False" Font-Size="Small"></asp:Label>
                <br />
                </div>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center hidden-xs">               
                <asp:GridView ID="gridEnlatados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="700px" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
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
                <asp:GridView ID="gridCongelados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="700px" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código de barras" SortExpression="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Vencimiento" HeaderText="Fecha de vencimiento" SortExpression="Vencimiento" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />
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
                <asp:GridView ID="gridEnlatadosMobile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="95%" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código de barras" SortExpression="Código" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
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
                <asp:GridView ID="gridCongeladosMobile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Visible="False" Width="95%" ShowFooter="True" ShowHeaderWhenEmpty="True" PageSize="50" AutoGenerateColumns="False" Font-Size="Large">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Código" HeaderText="Código de barras" SortExpression="Código" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
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
                <asp:Button ID="btListarProductosVolver" runat="server" Text="Volver" Width="100px" OnClick="btListarProductosVolver_Click" Font-Size="Small" />
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
