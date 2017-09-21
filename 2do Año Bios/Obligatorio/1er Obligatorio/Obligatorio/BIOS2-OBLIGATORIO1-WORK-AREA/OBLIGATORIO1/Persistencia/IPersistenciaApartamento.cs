using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaApartamento
    {
        void Agregar(Apartamento apartamento);
        void Eliminar(Apartamento apartamento);
        void Modificar(Apartamento apartamento);
        Apartamento Buscar(int padron);
        List<Apartamento> Listar();
    }
}
