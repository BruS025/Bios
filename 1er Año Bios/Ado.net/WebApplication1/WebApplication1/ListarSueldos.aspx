<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarSueldos.aspx.cs" Inherits="SolAdo.ListarSueldos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Listar Sueldos</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <section class="container">

            <h2 class="text-center">Sueldo Maximo y Sueldo Minimo de todos los Empleados</h2>
            <hr />
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <label for="txtMinimo">Minimo</label>
                    <asp:TextBox ID="txtMinimo" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <label for="txtMaximo">Maximo</label>
                    <asp:TextBox ID="txtMaximo" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-default" OnClick="btnCalcular_Click" />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-link">Volver</asp:LinkButton><br />
                </div>
            </div>
            <br />
            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        </section>    
    </form>
    <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>
