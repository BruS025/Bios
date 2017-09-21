using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntidadesCompartidas
{

    public class PCongelado : Producto
    {
        // Atributos
        private double _Peso;

        // Costructor Completo
        public PCongelado(int pCod, string pNom, DateTime pFecha, double pPrecio, double pPeso)
            : base(pCod, pNom, pFecha, pPrecio)
        {
            Peso = pPeso;
        }

        // Propiedades
        public double Peso
        {
            get { return _Peso; }
            set
            {
                if (value > 0)
                    _Peso = value;
                else
                    throw new Exception("ERROR: El peso debe ser un numero mayor que 0 ");
            }
        }

        //ToString()
        public override string ToString()
        {
            return ("CONGELADO - " + base.ToString() + " , Peso: " + Peso.ToString());
        }

    }
}