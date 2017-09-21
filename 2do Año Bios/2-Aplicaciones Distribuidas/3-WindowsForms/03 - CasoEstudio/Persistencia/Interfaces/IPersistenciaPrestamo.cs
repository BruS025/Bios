using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaPrestamo
    {
        void AltaPrestamo(Prestamo unPrestamo);
        void BajaPrestamo(Prestamo unPrestamo);
        void ModificarPrestamo(Prestamo unPrestamo);
        Prestamo BuscarPrestamo(int idPrestamo);
        List<Prestamo> ListarPrestamo();
    }
}
