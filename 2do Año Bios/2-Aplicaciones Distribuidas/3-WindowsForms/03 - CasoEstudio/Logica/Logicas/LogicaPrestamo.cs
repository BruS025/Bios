using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPrestamo : ILogicaPrestamo
    {
        //singleton
        private static LogicaPrestamo _miInstancia;
        private LogicaPrestamo() { }
        public static LogicaPrestamo GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new LogicaPrestamo();
            return _miInstancia;
        }

        public void AltaPrestamo(Prestamo unPrestamo)
        {
            FabricaPersistencia.getPersistenciaPrestamo().AltaPrestamo(unPrestamo);
        }

        public void BajaPrestamo(Prestamo unPrestamo)
        {
            FabricaPersistencia.getPersistenciaPrestamo().BajaPrestamo(unPrestamo);
        }

        public void ModificaPrestamo(Prestamo unPrestamo)
        {
            FabricaPersistencia.getPersistenciaPrestamo().ModificarPrestamo(unPrestamo);
        }

        public Prestamo BuscarPrestamo(int idPrestamo)
        {
            return (FabricaPersistencia.getPersistenciaPrestamo().BuscarPrestamo(idPrestamo));
        }
    }
}
