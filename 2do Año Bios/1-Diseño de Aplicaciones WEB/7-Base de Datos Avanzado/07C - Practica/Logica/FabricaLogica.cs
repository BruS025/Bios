using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaArticulos getLogicaArticulos()
        {
            return (LogicaArticulos.GetInstancia());
        }

        public static ILogicaFactura getLogicaFactura()
        {
            return (LogicaFactura.GetInstancia());
        }
    }
}
