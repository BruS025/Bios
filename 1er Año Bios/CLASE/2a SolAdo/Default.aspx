<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: justify">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-size: 14pt">Introduccion a ADO.NET</span></strong><br />
        <br />
        <table border="1">
            <tr>
                <td style="width: 355px; text-align: center">
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ListarEmpdeEmpresa.aspx">Listado de los Empleados de una Empresa</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>desconectada</strong> (utilizando DataSet y
                    SqlDataAdapter) ejecutando dos Stored Procedures: 1) uno sin parámetros para listar
                    todas las empresas y cargarlas en el combo; y 2) otro con un parámetro para listar
                    todos los empleados de la empresa seleccionada (el parámetro es el RUC de la empresa).
                </td>
            </tr>
            <tr>
                <td style="width: 355px">
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/EjemploDataSet.aspx">Modificar datos Desde Grilla</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>desconectada</strong> (utilizando DataSet y
                    SqlDataAdapter) ejecutando una consulta SQL simple desde C# sin parámetros. Luego
                    permite actualizar el DataSet en la Session (borrando las edades de los empleados)
                    aunque los cambios no se reflejan en la BD hasta no oprimir el botón "Actualizar
                    BD".</td>
            </tr>
            <tr>
                <td style="width: 355px">
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/AltaEmpl.aspx">Alta de Empleado</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand) ejecutando
                    un Stored Procedure con varios parámetros de entrada (pasándolos directamente en
                    la llamada al SP) y tomando el Return del SP (utilizando un SqlParameter de tipo
                    ReturnValue).</td>
            </tr>
            <tr>
                <td style="width: 355px">
                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ListarTodoEmp.aspx">Listado de Todos los Empleados</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand y
                    SqlDataReader) ejecutando una consulta SQL muy simple desde C# sin parámetros.</td>
            </tr>
            <tr>
                <td style="width: 355px">
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ListarEmpPorEdad.aspx">Listado de los Empleados por Edad</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand y
                    SqlDataReader) ejecutando un Stored Procedure con un parámetro de entrada (utilizando
                    un SqlParameter de tipo Input) y recorriendo su resultado con el SqlDataReader.</td>
            </tr>
            <tr>
                <td style="width: 355px">
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/ListarSueldos.aspx">Sueldo Maximo - Minimo / Uso de parametros Output</asp:LinkButton></td>
                <td style="width: 355px; text-align: left">
                    Muestra el trabajo en forma <strong>conectada</strong> (utilizando SqlCommand) ejecutando
                    un Stored Procedure con dos parámetros de salida (utilizando dos SqlParameter de
                    tipo Output)</td>
            </tr>
        </table>
    
    </div>
        <br />
        <strong>Nota</strong>:<br />
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
    </form>
</body>
</html>
