using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaPrestamo
    {
        void AltaPrestamo(Prestamo unPrestamo);
        void BajaPrestamo(Prestamo unPrestamo);
        void ModificaPrestamo(Prestamo unPrestamo);
        Prestamo BuscarPrestamo(int idPrestamo);
    }
}
