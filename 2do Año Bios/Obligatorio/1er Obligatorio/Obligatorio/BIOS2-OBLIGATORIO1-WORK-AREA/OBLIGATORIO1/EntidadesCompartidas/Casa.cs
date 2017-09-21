using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Casa : Propiedad
    {
        private bool _FondoJardin;
        private int _MetrosCuadradosC;

        public bool FondoJardin
        {
            get { return _FondoJardin; }
            set
            {
                _FondoJardin = value;
            }
        }

        public int MetrosCuadradosC
        {
            get { return _MetrosCuadradosC; }
            set { _MetrosCuadradosC = value; }

        }

        public Casa(int padron, Zona zona, Empleado empleado, int precio, string direccion, string tipoDeAccion, int baño, int habitaciones, int metrosCuadradosP, bool fondojardin, int metrosCuadradosC): base (padron,zona,empleado,precio,direccion,tipoDeAccion,baño,habitaciones,metrosCuadradosP)
        {
            FondoJardin = fondojardin;
            MetrosCuadradosC = metrosCuadradosC;
        }

    }
}
