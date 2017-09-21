using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Universidad
/// </summary>
public class Universidad
{
    private List<Materia> _ListaMaterias;
    private List<Alumno> _ListaAlumnos;
    private string _Nombre;

    //Propiedades
    public List<Materia> ListaMaterias
    {
        get { return _ListaMaterias; }
    }

    public List<Alumno> ListaAlumnos
    {
        get { return _ListaAlumnos; }
    }

    public Universidad(string pNombre)
    {
        _ListaAlumnos = new List<Alumno>();
        _ListaMaterias = new List<Materia>();
        _Nombre = pNombre;
    }

    //Operaciones
    public void RegistrarAlumno(Alumno pAlumno)
    {
        foreach (Alumno alum in _ListaAlumnos)
        {
            if(pAlumno.Nombre == alum.Nombre && pAlumno.Apellido == alum.Apellido)
            {
                throw new Exception("Error alumno existente");
            }
        }
        _ListaAlumnos.Add(pAlumno);
    }

    public void RegistrarMateria(Materia pMateria)
    {
        foreach (Materia mat in _ListaMaterias)
        {
           if (pMateria.Nombre == mat.Nombre)
            {
                throw new Exception("La materia debe de ser unica");
            }
        }
        _ListaMaterias.Add(pMateria);
    }

    public void RegistrarAlumnoMateria(Alumno pAlumno, Materia pMateria)
    {
        pMateria.RegistrarAlumno(pAlumno);
    }
}