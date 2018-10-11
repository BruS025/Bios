<%-- 
    Document   : index
    Created on : Jun 6, 2018, 8:03:14 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        title>Ejemplo de JSP Y BEANS y SERVLETS</title>
    </head>
    <body>
        <jsp:useBean id="producto" class="beans.Producto" scope="session">
            <jsp:setProperty name="producto" property="codigo" value="1"/>
            <jsp:setProperty name="producto" property="descripcion" value="table"/>
            <jsp:setProperty name="producto" property="precio" value="300"/>
        </jsp:useBean>
        
        <h1>Ejemplo de JSP y BEANS </h1>
        
        <h2>Producto Actual:</h2>
        
        <p>Codigo: <jsp:getProperty name="producto" property="codigo"/></p>
        <p>Descripcion: <jsp:getProperty name="producto" property="descripcion"/></p>
        <p>Precio: <jsp:getProperty name="producto" property="precio"/></p>
        
        <h2>Cambiar por :</h2>
         <form action="CambiarProducto" method="post" accept-charsert="ISO-8859">
            <table>
                <tr>
                    <td>Codigo:</td><td><input type="text" name="codigo"/></td>
                </tr>
                <tr>
                    <td>Descripcion:</td><td><input type="text" name="Descripcion"/></td>
                </tr>
                <tr>
                    <td>Precio:</td><td><input type="text" name="Precio"/></td>
                </tr>
                <td>
                <td></td><td><input type="submit" name="accion" value="Cambiar Producto"</td>
                </td>
            </table>
        </form>
    </body>
</html>
