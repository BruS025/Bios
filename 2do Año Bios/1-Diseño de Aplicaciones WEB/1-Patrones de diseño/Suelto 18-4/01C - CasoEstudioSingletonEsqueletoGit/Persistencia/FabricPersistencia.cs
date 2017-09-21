using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricPersistencia
    {
        public static IPersistenciaArticulo getPersistenciaArticulo()
        {
            return (PersistenciaArticulos.GetInstancia()); // Cambio que obliga el singleton
        }
    }
}
