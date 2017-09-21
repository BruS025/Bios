using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Local : Propiedad
    {
        private bool _Habilitacion;

        public Local (int padron, Zona zona, Empleado empleado, int precio, string direccion, string tipoDeAccion, int baño, int habitaciones, int metrosCuadradosP, bool habilitacion) : base (padron, zona, empleado, precio, direccion, tipoDeAccion, baño, habitaciones, metrosCuadradosP)
        {
            Habilitacion = habilitacion;
        }

        public bool Habilitacion
        {
            get { return _Habilitacion; }
            set { _Habilitacion = value; }
        }


    }
}
