using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Factura
    {
        private int _numFac;
        private DateTime _fechaFac;
        private string _nomCli;
        private decimal _totBru;
        private decimal _totIva;
        private decimal _totFac;

        private List<LineasFactura> _lineas;
        

        public int NumFac
        {
            get
            {
                return _numFac;
            }
        }

        public DateTime FechaFac
        {
            get
            {
                return _fechaFac;
            }
            set
            {
                if (value <= DateTime.Today)
                {
                    throw new Exception("La fecha no puede ser anterior a la actual");
                }
                else
                {
                    _fechaFac = value;
                }
            }
        }

        public string NomCli
        {
            get
            {
                return _nomCli;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("El nombre no puede quedar vacio");
                }
                else
                {
                    _nomCli = value;
                }
            }
        }

        public decimal TotBru
        {
            get
            {
                return _totBru;
            }
        }
        public decimal TotIva
        {
            get
            {
                return _totIva;
            }
        }

        public decimal TotFac
        {
            get
            {
                return _totFac;
            }
        }

        public List<LineasFactura> Lineas
        {
            get
            {
                return _lineas;
            }
            set
            {
                if (value == null || value.Count() == 0)
                {
                    throw new Exception("La cantidad de filas no puede ser nula o igual a 0");
                }

                if (value.Count > 5)
                {
                    throw new Exception("La cantidad de filas no puede ser mayor a 5");
                }
                
                _lineas = value;

                _totBru = calculoTotBru();
                _totIva = calculoIva();
                _totFac = calculoTotFac();
            }
        }

        public decimal calculoTotBru()
        {
            decimal totBru = 0;

            foreach(LineasFactura l in Lineas)
            {
                totBru += l.Articulo.Precio * l.Cantidad;
            }

            return totBru;
        }

        public decimal calculoIva()
        {
            decimal iva = TotBru * Convert.ToDecimal(0.22);

            return iva;
        }

        public decimal calculoTotFac()
        {
            decimal totFac = TotBru + TotIva;

            return totFac;
        }

        public Factura(DateTime fechaFac, string nomCli, List<LineasFactura> lineas)
        {
            FechaFac = fechaFac;
            NomCli = nomCli;
            Lineas = lineas;
        }
    }
}
