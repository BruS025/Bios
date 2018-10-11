<%-- 
    Document   : CambiarProducto
    Created on : Jun 4, 2018, 8:15:32 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cambiar Producto</title>
    </head>
    <body>
        <jsp:useBean id="Producto" class="Beans.Producto" scope="session"/>
        <jsp:setProperty name="producto" property="codigo"/>
        <jsp:setProperty name="producto" property="Descripcion"/>
        <jsp:setProperty name="producto" property="Precio"/>
            
            <jsp:forward page="index.jsp"/>
    </body>
</html>
