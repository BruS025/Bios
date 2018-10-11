<%-- 
    Document   : ProbocarUnError
    Created on : May 30, 2018, 8:13:14 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    if(request.getParameter("accion") != null && request.getParameter("accion").equals("Provocar Error"))
    {
        int resultado = 1/0;
    }
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Ejemplo de pagina provocar un error</title>
    </head>
    <body>
        <h1>Ejemplo de pagina de error - provocar un error</h1>
        
        <form>
            <p><input type ="submit" name="accion"value="Provocar error"/></p>
        </form>
    </body>
</html>
