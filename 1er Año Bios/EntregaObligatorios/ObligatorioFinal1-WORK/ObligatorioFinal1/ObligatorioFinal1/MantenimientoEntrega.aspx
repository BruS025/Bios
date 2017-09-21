<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantenimientoEntrega.aspx.cs" Inherits="ObligatorioFinal1.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Mantenimiento de pedidos</title>

    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href = "css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/login.css"/>
    <link rel="shortcut icon" href="Imagenes/favicon.ico"/> 
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    

<header>
    <div class="container">
        <h2><strong>Mantenimiento de pedidos</strong></h2>
    </div>  
</header>

    <div class="container">
    <div class="row">

    <div class="col-md-12" runat="server">
        <br />
        <div class="col-md-2" runat="server">
            <asp:Button ID="confirmar" runat="server" Text="Confirmar" Visible="false" CssClass="btn-md btn-primary" OnClick="confirmar_Click" />
            <br />
            <br />
        </div>
    </div>

        <div class="col-md-12" runat="server">
        <asp:GridView ID="GridPedidos" runat="server" AllowPaging="true" OnPageIndexChanging="GridPedidos_PageIndexChanging" OnSelectedIndexChanging="GridPedidos_SelectedIndexChanging"        
        AutoGenerateColumns="False" RowStyle-Height="34px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
        Visible="True" Width="100%" ShowFooter="false" ShowHeaderWhenEmpty="True" PageSize="10" Font-Size="Large" CaptionAlign="Top" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" PagerSettings-Mode="NextPrevious">

        <AlternatingRowStyle BackColor="White" />

          <Columns>

            <asp:TemplateField HeaderStyle-BorderWidth="2px" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Medium" ControlStyle-CssClass="btn-primary btn-md" HeaderText="Seleccionar">
                <ItemTemplate>

                <asp:LinkButton ID="btnSeleccionar" runat="server" OnClick="btnSeleccionar_Click" CommandName="select" CssClass="btn btn-md btn-danger" ForeColor="Black" BackColor="Transparent">
                    <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                </asp:LinkButton>
         
                </ItemTemplate>

            </asp:TemplateField>

            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Id" HeaderText="Id"/>
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="FechaPedido" HeaderText="Fecha Pedido" />       
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Total" HeaderText="Total" />       
            <asp:CheckBoxField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Estado" HeaderText="Estado" />                    

          </Columns>

          <FooterStyle BackColor="DarkTurquoise" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="LightBlue" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="White" ForeColor="#333333" />
          <SelectedRowStyle BackColor="LightGray" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="White" />

        </asp:GridView>
       </div>

    <div class="col-md-12" runat="server">
        <br />
        <p class="text-center"><asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
        <br />
    </div>

    </div>

</div>    

</asp:Content>
