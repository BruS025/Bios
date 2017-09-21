using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    
    public class Pedido
    {

        // Atributos
        private int _id;
        private DateTime _fechaPedido;
        private DateTime _fechaEntrega;
        double _totalVenta;
        Cliente _comprador;
        private List<Linea> _linea;
        private bool _Estado;

        // Constructor simple
        public Pedido() { }

        // Constructor completo
        public Pedido(int id, DateTime fechaPedido, DateTime fechaEntrega, double totalVenta, Cliente comprador, List<Linea> linea, bool estado)
        {
            _id = id;
            _fechaPedido = fechaPedido;
            _fechaEntrega = fechaEntrega;
            _totalVenta = totalVenta;
            _comprador = comprador;
            _linea = linea;
            _Estado = estado;
        }

        // Metodos

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime FechaPedido
        {
            get { return _fechaPedido; }
            set {_fechaPedido = value; }
        }

        public DateTime FechaEntrega
        {
            get { return _fechaEntrega; }
            set { _fechaEntrega = value; }
           /* {
                if (value < DateTime.Today)
                    throw new Exception("ERROR: La Fecha de entrega no puede ser menor a la fecha actual...");
                if (value < this.FechaPedido)
                    throw new Exception("ERROR: La fecha de entrega no puede ser anterior a la fecha de la venta");
                else
                    _fechaEntrega = value;
            }*/
        }

        public double Total
        {
            //get { return Total}
            get
            {
                double suma = 0;

                //sumo los totales por cada linea de la venta
                foreach (Linea unaLinea in _linea)
                suma = suma + unaLinea.UnPlato.Precio;

                return suma;

            }
        }

        public Cliente Comprador
        {
            get { return _comprador; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR: debe asignarse un cliente a la venta");
                else
                    _comprador = value;
            }
        }

        public List<Linea> Renglones
        {
            get { return _linea; }
            set { _linea = value; }
        }

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
