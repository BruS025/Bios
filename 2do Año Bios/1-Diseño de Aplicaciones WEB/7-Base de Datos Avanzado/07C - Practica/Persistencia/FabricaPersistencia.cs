using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaArticulos getPersistenciaArticulos()
        {
            return (PersistenciaArticulos.GetInstancia());
        }

        public static IPersistenciaFactura getPersistenciaFactura()
        {
            return (PersistenciaFactura.GetInstancia());
        }
    }
}
