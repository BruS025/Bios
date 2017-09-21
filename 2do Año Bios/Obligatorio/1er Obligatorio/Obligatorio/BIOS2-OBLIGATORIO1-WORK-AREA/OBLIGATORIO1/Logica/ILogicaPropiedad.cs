using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaPropiedad
    {
        void Agregar(Propiedad propiedad);
        void Modificar(Propiedad propiedad);
        void Eliminar(Propiedad propiedad);
        Propiedad Buscar(int padron);
        List<Propiedad> Listar();

    }
}
