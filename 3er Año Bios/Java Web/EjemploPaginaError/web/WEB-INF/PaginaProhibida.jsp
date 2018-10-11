<%-- 
    Document   : PaginaProhibida
    Created on : Jun 1, 2018, 6:52:01 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    String usuario = request.getParameter("usuario") != null ? request.getParameter("usuario") : "";
    String contrasena = request.getParameter("contrasena") != null ? request.getParameter("contrasena") : "";
    
    if(!(usuario.equals("admin") && contrasena.equals("admin")))
    {
        response.sendError(403);
    }
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Ejemplo de pagina de error - PAGINA PROHIBIDA</title>
    </head>
    <body>
        <h1>Pagina prohibida</h1>
        
        <p>Pagina prohibida al publico</p>
    </body>
</html>
