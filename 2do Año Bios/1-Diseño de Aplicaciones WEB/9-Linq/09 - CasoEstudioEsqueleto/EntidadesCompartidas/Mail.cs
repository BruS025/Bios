using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Mail
    {
        private int _Identificador;
        private Usuarios _UserEnvio;
        private Usuarios _UserRecibio;
        private string _Asunto;
        private string _Texto;

        public int Identificador
        {
            get { return _Identificador; }
            set { _Identificador = value; }
        }

        public Usuarios UserEnvio
        {
            get { return _UserEnvio; }
            set { _UserEnvio = value; }
        }

        public Usuarios UserRecibio
        {
            get { return _UserRecibio; }
            set { _UserRecibio = value; }
        }

        public string Asunto
        {
            get { return _Asunto; }
            set { _Asunto = value; }
        }

        public string Texto
        {
            get {return _Texto; }
            set { _Texto = value; }
        }

        public Mail(int Iden , Usuarios UserE , Usuarios UserR , string Asun , string Tex)
        {
            Identificador = Iden;
            UserEnvio = UserE;
            UserRecibio = UserR;
            Asunto = Asun;
            Texto = Tex;
        }
    }
}
