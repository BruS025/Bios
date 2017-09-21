using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuarios
    {
        private string _NombreUsuario;
        private string _Pass;
        private string _NombreCompleto;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }

        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set { _NombreCompleto = value; }
        }

        public Usuarios(string NomUser ,string PasS,string NomCom)
        {
            NombreUsuario = NomUser;
            Pass = PasS;
            NombreCompleto = NomCom;
        }
    }
}
