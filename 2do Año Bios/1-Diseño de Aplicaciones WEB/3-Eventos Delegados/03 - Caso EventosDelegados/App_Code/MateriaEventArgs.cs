using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MateriaEventArgs
/// </summary>
public class MateriaEventArgs:EventArgs
{
    //Atributos
    private Materia _LaMateria;

    //propiedades

    public Materia LaMateria
    {
        get { return _LaMateria; }
    }
    
    //contructor
    public MateriaEventArgs(Materia pMateria)
    {
        _LaMateria = pMateria;
    }
}