using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        private static string _cnn = "Data Source=.; Initial Catalog = BiosRealState; Integrated Security = true;";

        public static string Cnn
        {
            get { return _cnn; }
        }

    }
}
