using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolAdo
{
    public class Conexion
    {
        // private static string es un atributo de clase que va a contener el string coneccion que me
        // voy a manejar en la aplicacion
        private static string _cnn = "Data Source=.;Initial Catalog=Empresa;Integrated Security=true";

        //propiedad de clase de solo lectura sobre el atributo anterior.
        public static string Cnn
        {
            get { return _cnn; }
        }
    }
}