/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemploinspectorclases;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

/**
 *
 * @author Bruno
 */
public class EjemploInspectorClases {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
    {
       try
       {
           Class clase = Class.forName("ejemploinspectorclases.Empleado");
           
           System.out.println("Clase: "+ clase.getName());
           System.out.println("Clase: "+ clase.getSimpleName());
           
           System.out.println("\n\nAtributos:\n");
           
           Field[] atributos = clase.getFields();
           
           for (Field a : atributos)
           {
               System.out.println("+ " + a.getName()+ " : " + a.getType().getSimpleName());
           }
           
           System.out.println("espacio en blanco");
           
           Field[] atributosDeclarados = clase.getDeclaredFields();

           for (Field a : atributosDeclarados)
           {
               System.out.println((Modifier.isPublic(a.getModifiers())? "+ " : "- ") + a.getName() + ": " + a.getType().getSimpleName());
           }
           
           
       }
       catch (ClassNotFoundException ex) 
       {
            System.out.println("Error no se encontro clase");
       }
       catch(Exception ex)
       {
           System.out.println("Error ocurrido al realizar las pruebas con la instancia");
       }
    }
    
}
