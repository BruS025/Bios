using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Factura
    {
        //atributos
        private int _id;
        private DateTime _fecha;
        private string _cliente;
        private List<Linea> _lineas;
        
        //propiedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public List<Linea> Lineas
        {
            get { return _lineas; }
            set { _lineas = value; }
        }

        public decimal TotalBruto
        {
            get
            {
                decimal suma = 0;

                //Sumo los totales por cada linea de la venta
                foreach (Linea unaLinea in _lineas)
                {
                    suma = suma + unaLinea.Articulo.Precio;
                }

                return suma;

            }
        }

        public decimal TotalIva
        {
            get
            {
                decimal suma = 0;

                //Sumo los totales por cada linea de la venta
                foreach (Linea unaLinea in _lineas)
                {
                    suma = suma + (unaLinea.Articulo.Precio * Convert.ToDecimal(0.22));
                }

                return suma;

            }
        }

        public decimal Total
        {
            get
            {
                decimal suma = 0;

                //Sumo los totales por cada linea de la venta
                foreach (Linea unaLinea in _lineas)
                {
                    suma = suma + (unaLinea.Articulo.Precio * Convert.ToDecimal(1.23));
                }

                return suma;

            }
        }

        //Contructor
        public Factura(int id, DateTime fecha, string cliente, List<Linea> lineas)
        {
            _id = id;
            _fecha = fecha;
            _cliente = cliente;
            _lineas = lineas;

        }
  
    }
}
