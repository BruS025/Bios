<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarEmpPorEdad.aspx.cs" Inherits="SolAdo.ListarEmpPorEdad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Listar empleados por edad</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">

            <h2 class="text-center">Listar Empleados Mayores de:</h2>
            <hr />
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <asp:Label ID="Label4" runat="server" Text="Parámetro @edad:"></asp:Label>
                    <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <asp:ListBox ID="ltEmpleado" runat="server" Height="208px" CssClass="form-control"></asp:ListBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                     <asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="btn btn-default" OnClick="btnListar_Click" />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-link">Volver</asp:LinkButton>
                </div>
            </div>
           
            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        </section>
    <div style="text-align: center">
        <strong></strong><br />
        <br />
        
        <br />
        
        <br />
        &nbsp;<br />
        <br />
        
        <br />
       </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>
