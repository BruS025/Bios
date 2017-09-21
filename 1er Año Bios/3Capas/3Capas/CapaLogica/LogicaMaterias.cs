using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using CapaPersistencia;

namespace CapaLogica
{
    public class LogicaMaterias
    {
        public static List<Materias> ListarMaterias()
        {
            return PersistenciaMaterias.ListarMaterias();
        }
        public static int Agregar(Materias materia)
        {
            return PersistenciaMaterias.AgregarMat(materia);
        }
    }
}
