using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaArticulo getLogicaArticulo()
        {
            return (new LogicaArticulo());
        }
    }
}
