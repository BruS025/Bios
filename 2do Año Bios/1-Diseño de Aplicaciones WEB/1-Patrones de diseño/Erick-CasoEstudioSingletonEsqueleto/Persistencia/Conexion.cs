using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        private static string _cnn = "Data Source=192.168.1.110\\SQL,49458; Initial Catalog = Ventas; User=sa;Password=4715498-3";

        public static string Cnn
        {
            get { return _cnn; }
        }

    }
}
