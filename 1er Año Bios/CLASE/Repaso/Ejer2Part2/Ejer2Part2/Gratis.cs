using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Part2
{
    public class Gratis : Socio

    {
        private string _motivo;
    
        public Gratis() { }

        public Gratis(int ci, string nombre, string motivo):base(ci,nombre)
	    {
            _motivo = motivo;
        }

        public string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "Motivo" + _motivo;
        }

        public override double PagoMensual()
        {
            return 0;
        }
    }

}
