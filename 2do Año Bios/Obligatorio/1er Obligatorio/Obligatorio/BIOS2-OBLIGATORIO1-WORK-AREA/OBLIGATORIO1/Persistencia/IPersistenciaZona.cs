using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaZona
    {
        void Agregar(Zona zona);
        void Eliminar(Zona zona);
        void Modificar(Zona zona);
        Zona Buscar(string nombre, string departamento);
        Zona BuscarT(string nombre, string departamento);
        List<Zona> Listar();
    }
}
