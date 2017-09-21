using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace EntidadesCompartidas
{

    public class Duenio
    {
        //Atributos
        private int _Ci;
        private string _Nombre;


        //Propiedades
        public int CI
        {
            set
            {
                if (value <= 0)
                    throw new Exception("CI invalida");
                else
                    _Ci = value;
            }
            get { return _Ci; }
        }

        public string Nombre
        {
            set { _Nombre = value; }
            get { return _Nombre; }
        }



        //Cosntructor
        public Duenio(int cedula, string nombre)
        {
            CI = cedula;
            Nombre = nombre;
        }


        //Operaciones
        public override string ToString()
        {
            return (Nombre + " - " + CI);
        }

    }
}