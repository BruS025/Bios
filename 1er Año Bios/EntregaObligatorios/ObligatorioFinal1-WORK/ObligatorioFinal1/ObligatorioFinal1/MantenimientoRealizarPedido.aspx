﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MantenimientoRealizarPedido.aspx.cs" Inherits="ObligatorioFinal1.WebForm5" %>

<%@ Register Src="~/verPlato.ascx" TagPrefix="uc1" TagName="verPlato" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
    <title>Realizar pedidos</title>

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
        <h2><strong>Realizar pedidos</strong></h2>
    </div>  
</header>

<div class="container">
    <div class="row">

    <div class="col-md-12">

        <div class="col-md-2">
            <asp:Label ID="idV" ForeColor="Black" runat="server" Height="34px" Text="Filtrar platos" Font-Size="Large"></asp:Label>                      
        </div>

        <div class="col-md-2">
            <asp:DropDownList ID="ddlEspecializacion" AutoPostBack="true" runat="server" Height="34px" DataTextField="Tipo" DataValueField="IdEspe" OnSelectedIndexChanged="ddlEspecializacion_SelectedIndexChanged" ></asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:DropDownList ID="ddlCasas" runat="server" AutoPostBack="True" Height="34px" DataTextField="Nombre" DataValueField="RUT" OnSelectedIndexChanged="ddlCasas_SelectedIndexChanged" ></asp:DropDownList>
        </div>

        <br />
        <br />
        <br />

        <div class="col-md-12">
            <div class="col-md-6">
                <asp:Label ID="Label1" ForeColor="Black" runat="server" Height="34px" Text="Listado de productos:" Font-Size="Large"></asp:Label>                      
            </div>

            <div class="col-md-6">
                <asp:Label ID="Label2" ForeColor="Black" runat="server" Height="34px" Text="Carrito:" Font-Size="Large" Visible="true"></asp:Label>                      
            </div>
        </div>

        <div class="col-md-12">
            <div class="col-md-6">
                <asp:ListBox ID="listadoPlatos" runat="server" OnSelectedIndexChanged="listadoPlatos_SelectedIndexChanged" DataTextField="Nombre" DataValueField="Id" Font-Size="Medium" AutoPostBack="true" Width="100%"></asp:ListBox>
            </div>

            <div class="col-md-6">
                <asp:ListBox ID="listadoCarrito" runat="server" DataTextField="Nombre" DataValueField="Id" Font-Size="Medium" AutoPostBack="true" Visible="true" Width="100%"></asp:ListBox>
            </div>           
       </div>

        <div class="col-md-12">
            <div class="col-md-6">
                <br />
                <div class="col-md-3" runat="server">
                    <asp:LinkButton ID="btAgregarListado" runat="server" OnClick="btAgregarListado_Click" CssClass="btn-primary" ForeColor="White" BackColor="Transparent" Font-Size="Large" Height="34px">
                        <span aria-hidden="true" class="glyphicon glyphicon-plus-sign"></span>
                    </asp:LinkButton>
                    <button type="button" visible="true" id="verPlatoSeleccionado" runat="server" class="btn-primary" data-toggle="modal" data-target="#detallesPlato"><span aria-hidden="true" class="glyphicon glyphicon-camera"></span></button>
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div class="col-md-3" runat="server">

                    <asp:LinkButton ID="btAgregarCarrito" runat="server" OnClick="btAgregarCarrito_Click" CssClass="btn-primary" ForeColor="White" BackColor="Transparent" Font-Size="Large" Height="34px">
                        <span aria-hidden="true" class="glyphicon glyphicon-plus-sign"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btQuitarCarrito" runat="server" OnClick="btQuitarCarrito_Click" CssClass="btn-primary" ForeColor="White" BackColor="Transparent" Font-Size="Large" Height="34px">
                        <span aria-hidden="true" class="glyphicon glyphicon-minus-sign"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btLimpiar" runat="server" CssClass="btn-primary" ForeColor="White" OnClick="btLimpiar_Click" BackColor="Transparent" Font-Size="Large" Height="34px">
                        <span aria-hidden="true" class="glyphicon glyphicon-floppy-remove"></span>
                    </asp:LinkButton>

                </div>
            </div>
        </div>

        <div class="col-md-12">
            <div class="col-md-2 col-md-offset-5">
                <br />
                <asp:Label ID="lbCantidadTexto" runat="server" Text="Cantidad: "></asp:Label>
                <asp:Label ID="lbCantidad" runat="server" Text="000"></asp:Label>
            </div>
        </div>

        <div class="col-md-12">
            <br />
            <asp:Button ID="btVender" CssClass="btn btn-md btn-primary" runat="server" Text="Comprar!" OnClick="btVender_Click" Height="34px" />
        </div>

        <div class="col-md-12">
           <br />
           <p class="text-center"><asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label></p> 
           <br />
       </div>

    </div>
    </div>
</div>     

<div class="modal fade" id="detallesPlato" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" runat="server"><asp:Label ID="lable" runat="server" Text="Plato"></asp:Label></h4>
      </div>
      <div class="modal-body">      
          <div class="form-group" >

              <uc1:verPlato runat="server" ID="verPlato" />

            <br />
          </div>      
      </div>
    </div>
  </div>
</div>

 <script>

     $('#detallesPlato').on('show.bs.modal', function (event) {
         var button = $(event.relatedTarget)
         var recipient = button.data('whatever')
         var modal = $(this)
     })       
   
 </script>

</asp:Content>
