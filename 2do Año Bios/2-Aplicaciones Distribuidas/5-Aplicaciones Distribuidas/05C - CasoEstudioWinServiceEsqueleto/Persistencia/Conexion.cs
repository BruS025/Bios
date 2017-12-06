using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        internal static String STRConexion
        {
            get { return "Data Source=.; Initial Catalog = Archivador; Integrated Security = true"; }
        }
    }
}
