using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Apartamento : Propiedad
    {
        private bool _Ascensor;
        private int _Piso;

        public bool Ascensor
        {
            get { return _Ascensor; }
            set
            {
                _Ascensor = value;
            }
        }

        public int Piso
        {
            get { return _Piso; }
            set
            {
                _Piso = value;
            }
        }

        public Apartamento(int padron, Zona zona, Empleado empleado, int precio, string direccion, string tipoDeAccion, int baño, int habitaciones, int metrosCuadradosP, bool ascensor, int piso) : base(padron, zona, empleado, precio, direccion, tipoDeAccion, baño, habitaciones, metrosCuadradosP)
        {
            Ascensor = ascensor;
            Piso = piso;
        }
    }
}
