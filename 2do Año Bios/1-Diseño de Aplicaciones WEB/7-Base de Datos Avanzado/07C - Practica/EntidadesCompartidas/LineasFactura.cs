using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class LineasFactura
    {
        private Articulo _articulo;
        private int _cantidad;


        public Articulo Articulo
        {
            get
            {
                return _articulo;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("El Articulo no puede ser negativo");
                }
                else
                {
                    _articulo = value;
                }
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La cantidad de articulos no puede ser meno o igual a 0");
                }
                else
                {
                    _cantidad = value;
                }
            }
        }

        public int CodArt
        {
            get { return _articulo.Codigo; }
        }
        public LineasFactura(Articulo articulo, int cantidad)
        {
            Articulo = articulo;
            Cantidad = cantidad;
        }

    }
}
