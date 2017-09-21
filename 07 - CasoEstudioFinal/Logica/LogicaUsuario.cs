using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class LogicaUsuario
    {

        public static EntidadesCompartidas.Usuario Logueo(string pUsu, string pPass)
        {
            return (Persistencia.PersistenciaUsuario.Logueo(pUsu, pPass));
        }
    }
}
