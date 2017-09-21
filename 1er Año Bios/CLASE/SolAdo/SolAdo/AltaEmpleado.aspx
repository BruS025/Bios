<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaEmpleado.aspx.cs" Inherits="SolAdo.AltaEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Alta Empleado</title>
        <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">

            <h2 class="text-center">Alta de un Empleado sin Todos los Datos</h2>
            <hr />
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="form-group">
                        <label for="txtCI">Ci</label>
                        <asp:TextBox ID="txtCI" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtEdad">Edad</label>
                        <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnAlta" runat="server" CssClass="btn btn-default" Text="Agregar" OnClick="btnAlta_Click" />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-link">Volver</asp:LinkButton>
                </div>
            </div>
           
        <br />

        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label><br />
        <br />

        </section>
    
    </form>
    <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>

