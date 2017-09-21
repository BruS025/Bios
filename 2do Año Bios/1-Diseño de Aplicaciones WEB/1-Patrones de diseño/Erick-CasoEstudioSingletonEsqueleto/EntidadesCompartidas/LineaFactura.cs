using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class LineaFactura
    {
        Articulo _articulo;
        int _cantidad;


        public LineaFactura(Articulo articulo, int cantidad)
        {
            Articulo = articulo;
            Cantidad = cantidad;
        }

        public Articulo Articulo
        {
            get{ return _articulo; }
            set
            {
                if (value == null) throw new Exception("El artículo no puede ser nulo");
                _articulo = value;
            }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value <= 0) { throw new Exception("La cantidad debe ser mayor a 0"); }
                _cantidad = value;
            }
        }
    }
}
