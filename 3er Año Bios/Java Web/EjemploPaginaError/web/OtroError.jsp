<%-- 
    Document   : OtroError
    Created on : May 30, 2018, 8:08:38 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8" isErrorPage="true"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Ejemplo de pagina de otro error</title>
    </head>
    <body style="background-color: red;color: white">
        <h1> ERROR</h1>
        <p> Se a producido el siguiente error</p>
        <p>${pageContext.errorData.throwable}</p>
    </body>
</html>
