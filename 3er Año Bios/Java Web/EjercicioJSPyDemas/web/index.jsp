<%-- 
    Document   : index
    Created on : Jun 8, 2018, 6:51:28 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <form>
            <h1>Ingrese el Producto</h1>
            <table>
                <tr>
                    <td>Codigo:<jsp:getProperty name="producto" property="codigo"/></td>
                </tr>
            </table>
        </form>
        
    </body>
</html>
