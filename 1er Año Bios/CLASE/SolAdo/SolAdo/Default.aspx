<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SolAdo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menú</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
</head>
<body style="text-align: justify">
    <form id="form1" runat="server">
        <section class="container">

            <h2 class="h2">Introduccion a ADO.NET</h2>
            <table class="table table-striped table-bordered">
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ListarEmpdeEmpresa.aspx">Listado de los Empleados de una Empresa</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>desconectada</strong> (utilizando DataSet y
                        SqlDataAdapter) ejecutando dos Stored Procedures: 1) uno sin parámetros para listar
                        todas las empresas y cargarlas en el combo; y 2) otro con un parámetro para listar
                        todos los empleados de la empresa seleccionada (el parámetro es el RUC de la empresa).
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/EjemploDataSet.aspx">Modificar datos Desde Grilla</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>desconectada</strong> (utilizando DataSet y
                        SqlDataAdapter) ejecutando una consulta SQL simple desde C# sin parámetros. Luego
                        permite actualizar el DataSet en la Session (borrando las edades de los empleados)
                        aunque los cambios no se reflejan en la BD hasta no oprimir el botón "Actualizar
                        BD".
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/AltaEmpleado.aspx">Alta de Empleado</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand) ejecutando
                        un Stored Procedure con varios parámetros de entrada (pasándolos directamente en
                        la llamada al SP) y tomando el Return del SP (utilizando un SqlParameter de tipo
                        ReturnValue).
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ListarTodoEmp.aspx">Listado de Todos los Empleados</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand y
                        SqlDataReader) ejecutando una consulta SQL muy simple desde C# sin parámetros.
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ListarEmpPorEdad.aspx">Listado de los Empleados por Edad</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand y
                        SqlDataReader) ejecutando un Stored Procedure con un parámetro de entrada (utilizando
                        un SqlParameter de tipo Input) y recorriendo su resultado con el SqlDataReader.
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/ListarSueldos.aspx">Sueldo Maximo - Minimo / Uso de parametros Output</asp:LinkButton>
                    </td>
                    <td class="text-left">
                        Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand) ejecutando
                        un Stored Procedure con dos parámetros de salida (utilizando dos SqlParameter de
                        tipo Output)
                    </td>
                </tr>
            </table>
    
            <div class="alert alert-danger" role="alert">
              <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
              <span class="sr-only">Nota:</span>
              Este ejemplo fue confeccionado con el objetivo de centrarse <strong><span style="text-decoration: underline">
                únicamente</span></strong> en ADO.NET y no en la mejor forma de utilizar ADO.NET
            desde un proyecto en ASP.NET. Por lo tanto se utilizó ADO.NET directamente desde
            los WebForms. <strong><span style="text-decoration: underline">Esto generalmente no
                es recomendable, salvo para programas pequeños o prototipos</span></strong>.
            Lo recomendable es utilizar una arquitectura en Capas en donde los WebForms no utilicen
            ADO.NET, sino que éste sea utilizado exclusivamente por la Capa de Persistencia.
            Esto se verá en las próximas semanas del curso así como en un Caso de Estudio. Por
            lo tanto recuerde que este ejemplo es sólo a fines académicos para enfocarse sólo
            en las características de ADO.NET y sus diferentes formas de trabajo y <strong><span
                style="text-decoration: underline">no</span></strong> para tomar como ejemplo
            de cómo utilizar ADO.NET desde ASP.NET.
            </div>
            
            </section>
    </form>
    <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>