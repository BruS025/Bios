using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace EntidadesCompartidas
{

    public class Venta
    {
        // Atributos
        private int _Id;
        private DateTime _FechaVta;
        private DateTime _FechaPago;

        //Asociación
        private Cliente _Comprador;
        private List<LineaVenta> _Lineas;


        //Propiedades
        public int Id
        {
            get { return (_Id); }
            set { _Id = value; }
        }

        public DateTime FechaVta
        {
            get { return _FechaVta; }
            set
            {
                if (value < DateTime.Today)
                    throw new Exception("ERROR: La Fecha de Venta no puede ser menor a la fecha actual...");
                else
                    _FechaVta = value;
            }
        }

        public DateTime FechaPago
        {
            get { return _FechaPago; }
            set
            {
                if (value < DateTime.Today)
                    throw new Exception("ERROR: La Fecha de Pago no puede ser menor a la fecha actual...");
                if (value < this.FechaVta)
                    throw new Exception("ERROR: La fecha de Pago no puede ser anterior a la fecha de la venta");
                else
                    _FechaPago = value;
            }
        }

        public double Total
        {
            get
            {
                double suma = 0;

                //sumo los totales por cada linea de la venta
                foreach (LineaVenta unaLinea in _Lineas)
                    suma = suma + (unaLinea.Cantidad * unaLinea.UnProducto.Precio);

                return suma;

            }
        }

        public Cliente Comprador
        {
            get { return _Comprador; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR: debe asignarse un cliente a la venta");
                else
                    _Comprador = value;
            }

        }

        public List<LineaVenta> Renglones
        {
            get { return _Lineas; }
            set { _Lineas = value; }
        }


        // Constructor Completo
        public Venta(int pId, DateTime pFechaV, DateTime pFechaP, Cliente pCliente, List<LineaVenta> pLista)
        {
            Id = pId;
            FechaVta = pFechaV;
            FechaPago = pFechaP;
            Comprador = pCliente;
            Renglones = pLista;
        }



    }
}