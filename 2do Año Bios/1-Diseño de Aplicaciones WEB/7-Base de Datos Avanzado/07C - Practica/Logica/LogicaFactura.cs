using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaFactura:ILogicaFactura
    {
        public void AgregarFactura(Factura F)
        {
            FabricaPersistencia.getPersistenciaFactura().AgregarFactura(F);
        }

        //SINGLETON

        private static LogicaFactura _instancia = null;

        private LogicaFactura() { }

        public static LogicaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaFactura();

            return _instancia;
        }
    }
}
