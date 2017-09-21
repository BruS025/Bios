using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Definicion del delegado para el evento del alumno
public delegate void inscripcionMateriaEventHandler (object sender,MateriaEventArgs e);

public class Alumno
{
    //atributos
    private string _Nombre;
    private string _Apellido;

    //Propiedades
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }
    public string Apellido
    {
        get { return _Apellido; }
        set { _Apellido = value; }
    }

    //Constructor 
    public Alumno(string pNombre, string pApellido)
    {
        Nombre = pNombre;
        Apellido = pApellido;
    }

    /*Eventos - defino que eventos se pueden capturar si no se hace publico no se puede ejecutar fuera del ambito de la clase
     * habra que asignarle un controlador de eventos*/
    public event inscripcionMateriaEventHandler InscripcionMateria;

    //operacion del alumno que genera el evento es una operacion de tipo instancia que solo va a poder ser ejecutada por un objeto de la clase
    //es objeto que ejecuta esto es el alumno
    public void InscribirMateria(Materia pMateria)
    {
        InscripcionMateria(this, new MateriaEventArgs(pMateria));
        //esta linea provoca el evento,para provocarlo solamente lo llamamos
        //this reprecenta al objeto que en ese momento esta ejecutando la operacion
        //va a verificar si el objeto actual tiene asignado un delegado para evento y si lo tiene va a seguir al delegado para
        //llegar al controlador y la proxima linea de codigo que se ejecute es la primera del controlador
        
        //primero crea los objetos y luego ejecuta el evento
    }
}