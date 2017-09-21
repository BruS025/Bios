using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaLocal
    {
        void Agregar(Local L);
        void Eliminar(Local L);
        void Modificar(Local L);
        Local Buscar(int padron);
        List<Local> Listar();
    }
}
