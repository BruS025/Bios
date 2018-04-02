/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemploarchivostexto;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.PrintStream;
import java.util.Date;

/**
 *
 * @author Bruno
 */
public class EjemploArchivosTexto {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       File archivo = new File("log.txt");
       
       if(archivo.exists()/*si existe el archivo*/ && !archivo.isDirectory()/*y ademas no es un directorio*/)
       {
           try (FileReader fr = new FileReader(archivo);/*con ; puedo agregar mas recursos*/
                BufferedReader br = new BufferedReader(fr))/*esto es un try con recursos y estos se van a cerrar solos son necesidad de que yo los tenga que cerrar!!!!!!! Y SOLO PUEDO USAR LOS QUE TIENEN AUTOCLOSER!!!!!!!!!!!*/
           {
                System.out.println("Ejecuciones anteriores ......\n");
                
                String linea;
                
                while((linea = br.readLine()) != null)
                {
                    System.out.println(linea);
                }
           } 
           catch (Exception e) 
           {
               System.out.println("Error  al leer el archivo.");
           }
           try(FileOutputStream fos = new FileOutputStream(archivo , true);
               PrintStream ps = new PrintStream(fos);) 
           {
               ps.println(new Date());
           }
           catch (Exception e)
           {
               System.out.println("Error al escribir el archivo");
           }
           
       }
    }
    
}
