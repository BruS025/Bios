/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package holanetbeas;

import java.util.Scanner;

/**
 *
 * @author sistemas
 */
public class HolaNetbeas {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String mensaje;
        
        mensaje = "este es el mensaje";
        
        System.out.println(mensaje);
        
        System.out.println("ingrese nombre");
        
        Scanner teclado = new Scanner(System.in);
        
        String nota;
        
        nota = teclado.nextLine();

        System.out.println("Aunque usted no lo crea su nombre es :"+ nota);
        
    }
    
}
