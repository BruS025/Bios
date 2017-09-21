using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCasa
    {
        void Agregar(Casa casa);
        void Eliminar(Casa casa);
        void Modificar(Casa casa);
        Casa Buscar(int padron);
        List<Casa> Listar();
    }
}
