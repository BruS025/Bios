/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejemploorientacionaobjetos;

/**
 *
 * @author Bruno
 */
public class EjemploOrientacionAObjetos {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
    {
        Persona persona1;
        
        persona1 = new Persona();
        
        Persona persona2 = new Persona("Juan","Fernandez",35);
        
        System.out.println("\nEstado de personal: "+persona1);
        
        persona1.setNombre("Juan");
        persona1.setApellido("Fernandez");
        persona1.setEdad(34);
        persona1.cumplirAnios();
        
        System.out.println("\nEstado de persona1: "+persona1);
        
        System.out.println("Estado de persona2: "+persona2);
        
        comprobarIdentitidad(persona1,persona2);
        
        System.out.println("\nEstado persona3 = persona2");
        Persona persona3 = persona2;
        
        comprobarIdentitidad(persona2,persona3);
    }
    
    public static void comprobarIdentitidad(Persona primeraPersona , Persona segundaPersona)
    {
        if(primeraPersona !=null && segundaPersona!=null)
        {
            if(primeraPersona == segundaPersona)
            {
                System.out.println("Igules");
            }
        }
    }
}

