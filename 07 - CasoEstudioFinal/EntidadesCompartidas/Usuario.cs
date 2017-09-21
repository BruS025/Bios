using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //atributos
        private int _Cedula;
        private string _Nombre;
        private string _NomUsu;
        private string _Pass;



        //Propiedades
        public int Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }     

        public string NomUsu
        {
            get { return _NomUsu; }
            set
            {
                if (value.Trim().Length > 3)
                    _NomUsu = value;
                else
                {
                    throw new Exception("Nombre Invalido");
                }
            }
        }

        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }



        //Constructores
        public Usuario(int pCI, string pNom, string pUsu, string pPass)
        {
            Cedula = pCI;
            Nombre = pNom;
            NomUsu = pUsu;
            Pass = pPass;
        }

    }
}