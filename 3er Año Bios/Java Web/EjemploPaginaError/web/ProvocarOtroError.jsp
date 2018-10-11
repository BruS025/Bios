<%-- 
    Document   : ProvocarOtroError
    Created on : May 30, 2018, 8:19:42 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8" errorPage="OtroError.jsp"%>
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
        <title>Ejemplo de pagina provocar otro error</title>
    </head>
    <body>
        <h1>Ejemplo de pagina de error - provocar otro error</h1>
        
        <form>
            <p><input type ="submit" name="accion"value="Provocar error"/></p>
        </form>
    </body>
</html>
