using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crearClases
{
   public class chofer:Servicios
    {
        private int _cedula;
        private string _nombre;
        private int _edad;

        //constructor por defecto

        public chofer () { }

        // construcor completo
        public chofer ( int cedula,int edad,string nombre)
        {
            _cedula = cedula;
            _edad = edad;
            _nombre = nombre;
        }
        public int Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }
        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
       
    }
}
