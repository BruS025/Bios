/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemplofechasyhoras;

import java.text.DateFormat;
import java.text.ParseException;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Bruno
 */
public class EjemploFechasyHoras {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            DateFormat formateador;
            
            Date fechaActual = new Date();
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("DEFAULT : "+ formateador.format(fechaActual));
            
            formateador = DateFormat.getDateInstance(DateFormat.SHORT);
            System.out.println("SHORT : "+ formateador.format(fechaActual));
            
            formateador = DateFormat.getDateInstance(DateFormat.MEDIUM);
            System.out.println("MEDIUM : "+ formateador.format(fechaActual));
            
            formateador = DateFormat.getDateInstance(DateFormat.LONG);
            System.out.println("LONG : "+ formateador.format(fechaActual));
            
            formateador = DateFormat.getDateInstance(DateFormat.FULL);
            System.out.println("FULL : "+ formateador.format(fechaActual));
            
            System.out.println("\n\fehca y hora actual en formato default");
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println(formateador.format(fechaActual));
            
            
            Scanner teclado = new Scanner(System.in);
            
            System.out.println("\ningrese su fecha de nacimiento...(dd/mm/aaaa)");
            formateador = DateFormat.getDateInstance(DateFormat.SHORT);
            formateador.setLenient(false);
            Date fechaNac = formateador.parse(teclado.nextLine());
            
            
            Calendar calendario = Calendar.getInstance();
            
            calendario.setTime(fechaNac);
            
            System.out.println("\nDia de nacimiento: "+ calendario.get(Calendar.DAY_OF_MONTH));
            System.out.println("\nMes de nacimiento: "+ calendario.get(Calendar.MONTH));
            System.out.println("\nAnio de nacimiento: "+ calendario.get(Calendar.YEAR));
            
            
            
        } catch (ParseException ex) {
            Logger.getLogger(EjemploFechasyHoras.class.getName()).log(Level.SEVERE, null, ex);
        }      
    }
    
   /* public static void claseFecha(){
        try {
            DateFormat formateador;
            
            Date fechaActual = new Date();
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("DEFAULT : "+ formateador.format(DateFormat.DEFAULT));
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("SHORT : "+ formateador.format(DateFormat.SHORT));
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("MEDIUM : "+ formateador.format(DateFormat.MEDIUM));
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("LONG : "+ formateador.format(DateFormat.LONG));
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("FULL : "+ formateador.format(DateFormat.FULL));
            
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println("FULL : "+ formateador.format(DateFormat.FULL));
            
            System.out.println("\n\fehca y hora actual en formato default");
            formateador = DateFormat.getDateInstance(DateFormat.DEFAULT);
            System.out.println(formateador.format(fechaActual));
            
            
            Scanner teclado = new Scanner(System.in);
            
            System.out.println("n\\ingrese su fecha de nacimiento...(dd/mm/aaaa)");
            formateador = DateFormat.getDateInstance(DateFormat.SHORT);
            formateador.setLenient(false);
            Date fechaNac = formateador.parse(teclado.nextLine());
            
            
            Calendar calendario = Calendar.getInstance();
            
            calendario.setTime(fechaNac);
            
            System.out.println("\nDia de nacimiento: "+ calendario.get(Calendar.DAY_OF_MONTH));
            System.out.println("\nMes de nacimiento: "+ calendario.get(Calendar.MONTH));
            System.out.println("\nAnio de nacimiento: "+ calendario.get(Calendar.YEAR));
            
            
            
        } catch (ParseException ex) {
            Logger.getLogger(EjemploFechasyHoras.class.getName()).log(Level.SEVERE, null, ex);
        }      
   }*/
    
}
