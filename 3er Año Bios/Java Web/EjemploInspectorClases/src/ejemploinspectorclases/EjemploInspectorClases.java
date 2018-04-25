/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemploinspectorclases;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
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
           
           System.out.println("\n\nConstructores:\n");
           
           Constructor [] contructores = clase.getConstructors();
           
           String parametros;
           
           for(Constructor c : contructores)
           {
               parametros ="";
               
                for(Class p : c.getParameterTypes())
                {
                    if(parametros.length() > 0)
                    {
                        parametros += ", ";
                    }
                    
                    parametros += p.getSimpleName();
                }
               System.out.println("+ " + clase.getSimpleName() + "(" + parametros + ")");
           }
           
           System.out.println("\n\nMetodos: \n");
           
           Method [] Method = clase.getMethods();
         
           for(Method m : Method)
           {
               parametros ="";
               
                for(Class p : m.getParameterTypes())
                {
                    if(parametros.length() > 0)
                    {
                        parametros += ", ";
                    }
                    
                    parametros += p.getSimpleName();
                }
               System.out.println("+ " + m.getName() + "(" + parametros +") :" + m.getReturnType().getSimpleName());
           }
           
            System.out.println("\n\nMetodosDeclarados: \n");
           
           Method [] metodosDeclarados = clase.getDeclaredMethods();
           
           for(Method m : metodosDeclarados)
           {
               parametros ="";
               
                for(Class p : m.getParameterTypes())
                {
                    if(parametros.length() > 0)
                    {
                        parametros += ", ";
                    }
                    
                    parametros += p.getSimpleName();
                }
               System.out.println((Modifier.isPublic(m.getModifiers())? "+ " : "- ") + m.getName() + "(" + parametros +")" + m.getReturnType().getSimpleName());
           }
           
           System.out.println("\n\nPruebas con una instancia:\n");
           
           Object objeto = clase.newInstance();
           
           Field atributoEdad = clase.getField("edad");
           
           System.out.println("Edad antes de cumpler años: "+atributoEdad.getInt(objeto));
           
           Method metodoCumplirAnios = clase.getDeclaredMethod("CumplirAnios");
           metodoCumplirAnios.setAccessible(true);
           metodoCumplirAnios.invoke(objeto);
           
           System.out.println("Edad despues de cumplir años: "+ atributoEdad.getInt(objeto));
           
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
