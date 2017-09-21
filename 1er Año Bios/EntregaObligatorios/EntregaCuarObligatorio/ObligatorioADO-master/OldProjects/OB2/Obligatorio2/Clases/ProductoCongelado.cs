using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2.Clases;

namespace Obligatorio2.Clases
{
    public class ProductoCongelado : Producto
    {
        // Atributos
        private double _pesoProducto;

        // Constructor por defecto
        public ProductoCongelado() { }

        // Constructor con parametros
        public ProductoCongelado(long codigoBarrasProducto, string nombreProducto, DateTime fechaVencimientoProducto, double precioProducto, double pesoProducto) : base (codigoBarrasProducto, nombreProducto, fechaVencimientoProducto, precioProducto)
        {
            _pesoProducto = pesoProducto;
        }

        // Propiedades Peso
        public double Peso
        {
            get { return _pesoProducto; }
            set
            {
                if (value > 0)
                {
                    _pesoProducto = value;
                }      
            }
        }    
    }
}