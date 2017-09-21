<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantenimientoPedidos.aspx.cs" Inherits="ObligatorioFinal1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <title>Listado de pedidos</title>

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
        <h2><strong>Mantenimiento de pedidios</strong></h2>
    </div>  
</header>

<div class="container">
    <div class="row">

    <div class="col-md-12">
        
        <div class="col-md-3">
            <asp:Label ID="Label1" ForeColor="Black" runat="server" Height="34px" Text="Selecciona una fecha" Font-Size="Large"></asp:Label>
        </div>   
                              
        <div class="col-md-2">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar XML" />
            <br /> 
        </div> 
   </div>
   </div>  

   <div class="col-md-12">
        <div class="col-md-6">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="LightGray" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                <DayHeaderStyle BackColor="LightBlue" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="Black" />
                <SelectedDayStyle BackColor="DarkTurquoise" Font-Bold="True" />
                <SelectorStyle BackColor="White" />
                <TitleStyle BackColor="LightBlue" Font-Bold="True" Font-Size="9pt" ForeColor="White" />
                <TodayDayStyle BackColor="LightBlue" ForeColor="White" />
            </asp:Calendar>
        </div>
    </div>
   
    <br />
    <br /> 

    <div class="col-md-12" runat="server" height="34px">                      

        <br />
        <br />

        <div class="col-md-12">
            <asp:GridView ID="GridPedidos" runat="server" AllowPaging="true" OnPageIndexChanging="GridPedidos_PageIndexChanging"        
                          AutoGenerateColumns="true" RowStyle-Height="34px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
                          Visible="True" Width="100%" ShowFooter="false" ShowHeaderWhenEmpty="True" PageSize="10" Font-Size="Large" CaptionAlign="Top" 
                          HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" PagerSettings-Mode="NextPrevious">

        <AlternatingRowStyle BackColor="White" />

          <Columns>
                               
          </Columns>

          <FooterStyle BackColor="DarkTurquoise" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="LightBlue" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="White" ForeColor="#333333" />
          <SelectedRowStyle BackColor="LightGray" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="White" />

        </asp:GridView>
       </div>

       <div class="col-md-12">
           <br />
           <p class="text-center"><asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
           <br />
       </div>

    </div>
</div>    

</asp:Content>
