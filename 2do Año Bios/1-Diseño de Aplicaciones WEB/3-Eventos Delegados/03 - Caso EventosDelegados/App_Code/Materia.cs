using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Materia
/// </summary>
public delegate void inscripcionMateriaUniversidadEventHandler (Materia pMateria);

public class Materia
{

    //Atributos
    private string _Nombre;
    private List<Alumno> _ListaAlumnos;

    //Propiedades

    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }

    public List<Alumno> ListaAlumnos
    {
           get{return _ListaAlumnos;}
    }

    //Contructores

    public Materia(string pMateria)
    {
        Nombre = pMateria;
        _ListaAlumnos = new List<Alumno>();
    }

    public void RegistrarAlumno(Alumno pAlumno)
    {      
        foreach (Alumno busqueda in _ListaAlumnos)
        {
            if (pAlumno.Nombre == busqueda.Nombre && pAlumno.Apellido == busqueda.Apellido)
            {
                throw new Exception ("Error"); 
            }
        }
        _ListaAlumnos.Add(pAlumno);
    }
    public event inscripcionMateriaUniversidadEventHandler InscripcionMateriaUniversidad;

    public void InscripcioMatAUni()
    {
        InscripcionMateriaUniversidad(this);
    }
}
