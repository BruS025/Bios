using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaEmpleado getLogicaEmpleado()
        {
            return (LogicaEmpleado.ObtenerInstancia());
        }

        public static ILogicaZona getLogicaZona()
        {
            return (LogicaZona.ObtenerInstancia());
        }

        public static ILogicaVisita getLogicaVisita()
        {
            return (LogicaVisita.ObtenerInstancia());
        }

        public static ILogicaPropiedad getLogicaPropiedad()
        {
            return (LogicaPropiedad.ObtenerInstancia());
        }

    }
}
