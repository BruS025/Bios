using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{

    public class Linea
    {
        //Atributos
        private Plato _UnPlato;
        private Casa _UnaCasa;
        private int _Cantidad;

        //Propiedades

        public Plato UnPlato
        {
            get { return _UnPlato; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR: Debe agregar al menos un plato a la venta..");
                else
                    _UnPlato = value;
            }
        }

        public Casa UnaCasa
        {
            get { return _UnaCasa; }
            set
            {
                if (value == null)
                    throw new Exception("ERROR: El plato debe tener una casa..");
                else
                    _UnaCasa = value;
            }
        }

        public int Cantidad
        {
            get { return _Cantidad; }
            set
            {
                if (value <= 0)
                    throw new Exception("ERROR: La venta debe ser al menos de una unidad...");
                else
                    _Cantidad = value;
            }
        }

        //Constructor
        public Linea(Plato lPlato, Casa lCasa , int lCant)
        {
            UnPlato = lPlato;
            UnaCasa = lCasa;
            Cantidad = lCant;
        }

        public Linea()
        {

        }
    }   
}
