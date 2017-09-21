using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaVisita : ILogicaVisita
    {
        // Singleton
        private static LogicaVisita _instancia = null;
        private LogicaVisita() { }

        public static LogicaVisita ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaVisita();

            return _instancia;
        }

        public void Agregar(Visita visita)
        {
            IPersistenciaVisita FabricaVisita = FabricaPersitencia.getPersistenciaVisita();
            FabricaVisita.Agregar(visita);
        }

    }
}
