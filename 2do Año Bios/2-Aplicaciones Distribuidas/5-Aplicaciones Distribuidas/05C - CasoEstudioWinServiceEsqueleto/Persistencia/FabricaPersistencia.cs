using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia
    {

        public static IPersistenciaArchivo getPersistenciaArchivo()
        {
            return (PersistenciaArchivo.GetInstancia());
        }
    }
}
