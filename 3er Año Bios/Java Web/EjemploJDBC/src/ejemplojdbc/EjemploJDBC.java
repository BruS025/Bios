/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemplojdbc;


import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

/**
 *
 * @author Bruno
 */
public class EjemploJDBC 
{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
    {
        try
        {
            Class.forName("com.mysql.jdbc.Driver")/*newInstance()*/;
            
           // agregarEmpleado();
            EliminarEmpleado2();
          //  ListarEmpeados2();
            obtenerMayorSueldo();
        }
        catch (Exception ex) 
        {
            System.out.println("Error ocurrio al instanciar el driver");
        }
    }
    
    private static void agregarEmpleado()
    {
        Connection conexion = null;
        Statement consulta = null;
        
        try
        {
            conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/EjemploJDBC","root","bruno");
            
            consulta = conexion.createStatement();
            
            int filasAfectadas = consulta.executeUpdate("INSERT INTO Empleados VALUES(5,'MARIA JOSE',25,2700,0);");
            
            if(filasAfectadas == 1)
            {
                    System.out.println("Empelado agregado con exito");
            }
            else
            {
                    System.out.println("Error al agregar empleado");
            }
        }
        catch (Exception ex) 
        {
            System.out.println("Error al agregar el empleado" + ex);
        }
        finally
        {
            try
            {
                if(consulta != null) consulta.close();
                if(conexion != null) conexion.close();
            }
            catch(Exception ex)
            {
                System.out.println("Error al cerrar los recursos");     
            }
        } 
   }
    
    private static void EliminarEmpleado2()
    {
        try(Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/EjemploJDBC","root","bruno"); 
                CallableStatement consulta = conexion.prepareCall("{CALL EliminarEmpleado(?,?) }"))
        {
            consulta.setLong(1,3);
            consulta.registerOutParameter(2,java.sql.Types.VARCHAR);
            
            consulta.executeUpdate();
            
            String error = consulta.getString(2);
            
            if(error == null)
            {
                System.out.println("Empleado eliminado con exito");
            }
            else
            {
                System.out.println("error..." + error);
            }
        }
        catch (Exception ex)
        {
        System.out.println("Error fue cuando .." + ex);
        }
    }
    
    private static void ListarEmpeados2()
    {
        try(Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/EjemploJDBC","root","bruno"); 
                CallableStatement consulta = conexion.prepareCall("{ CALL ListarTodos() }"); ResultSet resultadoConsulta = consulta.executeQuery())
        {
            System.out.println();
            
            long cedula;
            String nombre;
            Double sueldo;
            Integer edad;
            Boolean casado; //Boolean con mayuscula para que admita el null
            
            while(resultadoConsulta.next())
            {
                cedula = resultadoConsulta.getLong(1);
                nombre = resultadoConsulta.getString("Nombre");
                sueldo = (Double)resultadoConsulta.getObject("Sueldo");
                edad = (Integer)resultadoConsulta.getObject("Edad");
                casado = resultadoConsulta.getBoolean("Casado");
                
                if(casado == false)
                {
                    casado = resultadoConsulta.wasNull() ? null : casado;
                }
                
                System.out.println("Cedula " + cedula + ",Nombre " + nombre + ",Sueldo " + (sueldo != null ? sueldo : "N/D") + ",EDAD " + (edad != null ? edad : "N/D") + ",Casado " + (casado != null ? casado ? "SI" : "NO" : "N/D"));
            }
            System.out.println();
        }
        catch(Exception ex)
        {
            System.out.println("error ocurrio  " + ex);
        }
    }
    
    private static void obtenerMayorSueldo()
    {
        Connection conexion = null;
        CallableStatement consulta = null;
        
        try
        {
            conexion = DriverManager.getConnection("jdbc:mysql://localhost:3306/EjemploJDBC","root","bruno");
            
            consulta = conexion.prepareCall("{ CALL ObtenerMayorSueldo(?) }");
            consulta.registerOutParameter(1 , java.sql.Types.DOUBLE);
            consulta.executeUpdate();
            
            double mayorSueldo = consulta.getDouble(1);
            
            System.out.println("mayor sueldo " + mayorSueldo);
        }
        catch(Exception ex)
        {
            System.out.println("El error es " + ex);
        }
        finally
        {
            try
            {
                if (consulta != null) consulta.close();
                if (conexion != null) conexion.close();
            }
            catch(Exception ex1)
            {
                System.out.println("Error al cerrar recursos" + ex1);
            }
        }
    }
}