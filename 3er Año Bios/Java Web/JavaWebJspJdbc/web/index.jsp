<%-- 
    Document   : index
    Created on : Jun 6, 2018, 7:02:40 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP INICIAL</title>
    </head>
    <body>
        <jsp:useBean id="Mensaje" class="Beans.Mensaje" scope="session">
            <jsp:setProperty name="Mensaje" property="idMen" value="1"/>
        </jsp:useBean>
        
        
        <h1>En la teoria esto funciona</h1>
        
        <p>Mensaje: <jsp:getProperty name="Mensaje" property="idMen"/></p>
    </body>
</html>
