using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{

    public class LineaVenta
    {

        //Atributos
        private Producto _UnProducto;
        private int _Cantidad;


        //Propiedades

        public Producto UnProducto
        {
            get { return _UnProducto; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR: debe asignar un producto a la linea de la venta..");
                else
                    _UnProducto = value;
            }
        }

        public int Cantidad
        {
            get { return _Cantidad; }
            set
            {
                if (value <= 0)
                    throw new Exception("ERROR: la venta debe ser al menos de una unidad...");
                else
                    _Cantidad = value;
            }
        }


        //Constructor
        public LineaVenta(Producto pProd, int pCant)
        {
            UnProducto = pProd;
            Cantidad = pCant;
        }
    }
}