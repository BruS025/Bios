using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using CapaPersistencia;

namespace CapaLogica
{
    public class LogicaAlumno
    {
        public static int Agregar(Alumno alumno)
        {
            return PersistenciaAlumno.Agregar(alumno);
        }

        public static List<Alumno> ListarTodos()
        {
            return PersistenciaAlumno.ListarTodos();
        }

        public static Alumno MostrarDatos( int CiAlumno)
        {
            return PersistenciaAlumno.MostrarDatos(CiAlumno);
        }

        public static int Modificar(Alumno AlumMod)
        {
            return PersistenciaAlumno.Modificar(AlumMod);
        }

        public static int Eliminar(Alumno Ci)
        {
            return PersistenciaAlumno.Eliminar(Ci);
        }
    }
}
