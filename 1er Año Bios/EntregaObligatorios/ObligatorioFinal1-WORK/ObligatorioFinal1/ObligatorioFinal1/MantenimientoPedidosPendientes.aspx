<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantenimientoPedidosPendientes.aspx.cs" Inherits="ObligatorioFinal1.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Listado de pedidos pendientes</title>

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
        <h2><strong>Mantenimiento de pedidios pendientes</strong></h2>
    </div>  
</header>

<div class="container" runat="server">
    <div class="row">

    <div class="col-md-12" runat="server">

        <br />

        <div class="col-md-2" runat="server">
            <button type="button" visible="false" id="lineas" runat="server" class="btn-md btn-primary"><span aria-hidden="true" class="glyphicon glyphicon-info-sign"></span> Ver lineas</button>
        </div>

    </div>

    <div class="col-md-12" id="divPlato" runat="server">                      

        <br />      

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
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="FechaEntrega" HeaderText="Fecha Entrega" />      
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Total" HeaderText="Total" />                           

          </Columns>

          <FooterStyle BackColor="DarkTurquoise" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="LightBlue" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="White" ForeColor="#333333" />
          <SelectedRowStyle BackColor="LightGray" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="White" />

        </asp:GridView>
       </div>

    </div>

    <div class="col-md-12" runat="server">
        <br />
        <p class="text-center"><asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
        <br />
    </div>

</div>
</div>  

<div class="modal fade" id="verLineas" tabindex="-1" role="dialog">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" runat="server"><asp:Label ID="Label1" runat="server" Text="Ver compra"></asp:Label></h4>
      </div>
      <div class="modal-body">      
          <div class="form-group" >

              <div class="col-md-12">
                <div class="col-md-2">                  
                    <asp:Label ID="lbCasa" Visible="false" runat="server" Text="Casa:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="nombreCasa" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-2">                  
                    <asp:Label ID="lbCantidad" Visible="false" runat="server" Text="Cantidad:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="cantidad" runat="server" Text=""></asp:Label>
                </div>
               </div>
              <div class="col-md-12">                  
                <div class="col-md-4">                
                    <img class="img-circle glyphicon-align-center center-block" src="/Imagenes/logo.png" id="fotoPlato" alt="Card image cap" runat="server" width="100" height="100" visible="false" />
                    <br />
                    <br />
                </div>
              </div>

              <br />
              <br />
              <br />

        <div class="col-md-12" runat="server">
            <asp:GridView ID="GridLineas" runat="server" AllowPaging="true" OnPageIndexChanging="GridLineas_PageIndexChanging" OnSelectedIndexChanging="GridLineas_SelectedIndexChanging"        
        AutoGenerateColumns="False" RowStyle-Height="34px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
        Visible="True" Width="100%" ShowFooter="false" ShowHeaderWhenEmpty="True" PageSize="10" Font-Size="Large" CaptionAlign="Top" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" PagerSettings-Mode="NextPrevious">

        <AlternatingRowStyle BackColor="White" />

          <Columns>

            <asp:TemplateField HeaderStyle-BorderWidth="2px" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Size="Medium" ControlStyle-CssClass="btn-primary btn-md" HeaderText="Seleccionar">
                <ItemTemplate>

                <asp:LinkButton ID="btnSeleccionarLinea" runat="server" OnClick="btnSeleccionarLinea_Click" CommandName="select" CssClass="btn btn-md btn-danger" ForeColor="Black" BackColor="Transparent">
                    <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                </asp:LinkButton>
         
                </ItemTemplate>

            </asp:TemplateField>

            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Id" HeaderText="Id"/>
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Nombre" HeaderText="Nombre" />     
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Precio" HeaderText="Precio" />        
            <asp:BoundField HeaderStyle-BorderWidth="2px" ItemStyle-Font-Size="Medium" DataField="Foto" HeaderText="Foto" Visible="true" HeaderStyle-Width="10%" ItemStyle-CssClass="Shorter" />                         

          </Columns>

          <FooterStyle BackColor="DarkTurquoise" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="LightBlue" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="White" ForeColor="#333333" />
          <SelectedRowStyle BackColor="LightGray" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="DarkTurquoise" ForeColor="White" />

        </asp:GridView>
       </div>

              <br />
              <br />
            </div>  
          
       <div class="col-md-12">
           <br />
           <br />
           <p class="text-center"><asp:Label ID="lbError2" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
       </div>
              
      </div>
      <div class="modal-footer">                                      
      </div>
    </div>
  </div>
</div>

<script>

    function vpi() { $('#verLineas').modal('show') }
    function vpi2() {$('#verLineas').modal('hide')
                     $('.modal-backdrop').remove();}

     $('#verLineas').on('show.bs.modal', function (event) {
         var button = $(event.relatedTarget) // Button that triggered the modal
         var recipient = button.data('whatever')
         var modal = $(this)
     })

</script>

</asp:Content>
