/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import beans.Producto;
import java.io.IOException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author Bruno
 */
public class CambiarProducto 
{
    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        HttpSession sesion = request.getSession();
        
        Producto producto =(Producto)sesion.getAttribute("producto");
        
        if(producto ==null)
        {
            producto = new Producto();
            
            sesion.setAttribute("producto",producto);
        }
        try
        {
            producto.setCodigo(Integer.parseInt(request.getParameter("Codigo")));
            
        }
        catch(Exception ex)
        {
            producto.setCodigo(0);
        }
        
        producto.setDescripcion(request.getParameter("Descripcion"));
        
        if(producto.getDescripcion() == null || producto.getDescripcion().equals(""))
        {
            producto.setDescripcion("N/D");
        }
        
        try
        {
            producto.setPrecio(Double.parseDouble(request.getParameter("precio")));
            
        }
        catch(Exception ex)
        {
            producto.setPrecio(0);
        }
        
        RequestDispatcher despachador =request.getRequestDispatcher("index.jsp");
        
        if(despachador != null)
        {
            despachador.forward(request, response);
        }
    }
}
