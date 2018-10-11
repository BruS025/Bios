<%-- 
    Document   : index
    Created on : May 28, 2018, 8:05:43 PM
    Author     : Bruno
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%! //scriptlet declaracion a nivel de clase
    
    private String accion, nombre;
%>
<% //scriptlet dentro de metodo de servicio
    
    accion = request.getParameter("accion");
    nombre = request.getParameter("nombre");
    nombre = nombre != null && nombre.length() > 0 ? nombre : null;
    
    if(session.getAttribute("primerMensaje") == null)
    {
        session.setAttribute("primerMensaje", "Bienvenido a javaWEB");
        session.setAttribute("segundoMensaje", "Esperamos que lo disfrutes");
    }


%>

<!DOCTYPE html>

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    
        <h1>Hello World!</h1>
        <jsp:include page = "Titulo">
            <jsp:param name="subtitulo" value = "S"/>
        </jsp:include>
                <tr>
                    <td>Escribe tu nombre :</td>
                    <td>
                        <input type="text" name ="nombre" />
                    </td>        
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <input type="submit" name="accion" value="Saludar" />
                    </td>
                </tr>
                
        <% if((accion != null) && accion.equals("Saludar") && (nombre != null))
        {%>
            <p> ! hola <%= nombre %>!</p>
            
            <p> !chau ${param.nombre}!</p>  
            
        <%}%>
           
        <p><%= session.getAttribute("primerMensaje") %></p>
        
        <p>${segundoMensaje}</P>
        
    

