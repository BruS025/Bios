using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Part2
{
        public class Mensual : Socio
        {
            private DateTime _fechaUltimoPago;
            private int _cuota;

            //constructor por defecto

            public Mensual() { }

            //Constructor completo

            public Mensual(int ci, string nombre, DateTime fechaUltimoPago, int cuota) : base(ci, nombre)
            {
                _fechaUltimoPago = fechaUltimoPago;
                _cuota = cuota;
            }

            public DateTime FechaUltimoPago
            {
                get { return _fechaUltimoPago; }
                set { _fechaUltimoPago = value; }
            }

            public int Cuota
            {
                get { return _cuota; }
                set { _cuota = value; }
            }

            public override string ToString()
            {
                return base.ToString() + "Fecha del ultimo pago" + _fechaUltimoPago + "Cuota" + _cuota;
            }

            public override double PagoMensual()
            {
                if (_fechaUltimoPago.Month == DateTime.Now.Month && _fechaUltimoPago.Month == DateTime.Now.Year)
                {
                    return _cuota;
                }
                return 0;
            }
        } 
}
