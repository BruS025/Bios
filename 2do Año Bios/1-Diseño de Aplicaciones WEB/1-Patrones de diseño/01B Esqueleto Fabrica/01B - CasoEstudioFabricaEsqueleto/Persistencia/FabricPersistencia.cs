using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricPersistencia
    {
        public static IpersistenciaArticulo getPersistenciaArticulo()
        {
            return (new PersistenciaArticulos());
        }
    }
}
