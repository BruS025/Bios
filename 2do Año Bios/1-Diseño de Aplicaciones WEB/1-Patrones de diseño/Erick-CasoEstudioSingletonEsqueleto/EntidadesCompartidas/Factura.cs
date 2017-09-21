using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Factura
    {
        //atributos
        int _id;
        string _cliente;
        DateTime _fechaAlta;
        List<LineaFactura> _lineas = null;

        //Propiedades publicas
        public Factura(int id, string cliente, DateTime fechaAlta, List<LineaFactura> lineas)
        {
            ID = id;
            Cliente = cliente;
            FechaAlta = fechaAlta;
            Lineas = lineas;
        }

        public int ID
        {
            get { return _id; }
            set
            {
                if (value <= 0) throw new Exception("El id debe ser mayor a 0");
                _id = value;
            }
        }

        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set
            {
                _fechaAlta = value;
            }
        }

        public List<LineaFactura> Lineas
        {
            get { return _lineas; }
            set
            {
                    if (value == null) { throw new Exception("No hay artículos en su lista."); }
                    if (value.Count == 0) { throw new Exception("No hay artículos en su lista."); }
                    _lineas = value;
            }
        }

        public decimal MontoTotal
        {
            get
            {
                return CalcularMontoTotal();
            }
        }

        public decimal MontoBruto
        {
            get
            {
                return CalcularMontoBruto();
            }
        }

        public decimal MontoIVA
        {
            get
            {
                return CalcularMontoIVA();
            }
        }


        //operaciones privadas
        private decimal CalcularMontoTotal()
        {
            try
            {


                decimal res = 0;

                foreach (LineaFactura item in _lineas)
                {
                    res += item.Articulo.Precio * item.Cantidad;
                }

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalcularMontoBruto()
        {
            try
            {
                 decimal res = CalcularMontoTotal(); //Obtenemos monto total

                decimal dcAux = res * Convert.ToDecimal(0.22); //Obtenemos el IVA del monto

                return (res - dcAux); //Retornamos el bruto (Total - IVA)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalcularMontoIVA()
        {
            try
            {
              
                return CalcularMontoTotal() * Convert.ToDecimal(0.22); //Retornamos el 22% del total que seria el IVA
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
