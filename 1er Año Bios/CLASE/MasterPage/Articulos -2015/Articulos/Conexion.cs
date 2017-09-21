using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articulos
{
    public class Conexion
    {
        private static string cnnString = "Data Source=.\\SQLEXPRESS;Initial Catalog = ArticulosDBClase; Integrated Security= true;";

        public static string CnnString
        {
            get { 
                return cnnString; 
            }
        }
    }
}