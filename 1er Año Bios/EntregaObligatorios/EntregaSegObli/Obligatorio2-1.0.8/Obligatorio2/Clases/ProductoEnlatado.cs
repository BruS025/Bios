using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2.Clases;

namespace Obligatorio2.Clases
{
    public class ProductoEnlatado : Producto
    {
        // Atributos
        private bool _abrefácil;

        // Constructor por defecto
        public ProductoEnlatado () {}

        // Constructor con parametros
        public ProductoEnlatado (long codigoBarrasProducto, string nombreProducto, DateTime fechaVencimientoProducto, double precioProducto, bool abrefácil) : base(codigoBarrasProducto, nombreProducto, fechaVencimientoProducto, precioProducto)
        {
            _abrefácil = abrefácil;
        }

        // Propiedades Abrefácil
        public bool Abrefácil
        {
            get { return _abrefácil; }
            set { _abrefácil = value; }
            
        }

    }
}