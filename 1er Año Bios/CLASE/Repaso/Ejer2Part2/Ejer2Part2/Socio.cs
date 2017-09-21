using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Part2
{
    public class Socio
    {
        private int _ci;
        private string _nombre;

        //constructor por defecto
        public Socio() { }
        //Completo
        public Socio(int ci, string nombre)
        {
            _ci = ci;
            _nombre = nombre;
        }

        public int CI
        {
            get { return _ci; }
            set { _ci = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public override string ToString()
        {
            return "Cedula" + _ci + "Nombre" + _nombre;
        }

        public virtual double PagoMensual()
        {
            return 0;
        }
    }
}

