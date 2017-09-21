using System;
using System.Collections.Generic;
using System.Text;


namespace EntidadesCompartidas
{

    public class Apartamento : Vivienda
    {
        //Atributos
        private bool _Portero;
        private int _Piso;
        private int _GComunes;



        //Propiedades
        public int Piso
        {
            set
            {
                if (value >= 0)
                    _Piso = value;
                else
                    throw new Exception("No hay pisos por debajo de la PB");
            }
            get { return _Piso; }
        }

        public bool Portero
        {
            set { _Portero = value; }
            get { return _Portero; }
        }

        public int GComunes
        {
            set
            {
                if (value <= 0)
                    throw new Exception("Los Gastos Cumunes son Obligatorio de Ingresar");
                else
                    _GComunes = value;
            }
            get { return _GComunes; }
        }

 

        //Constructores
        public Apartamento(int pPadron, string pDir, DateTime pFecha, int pAlquiler, bool pPortero, int pPiso, int pGastos, Duenio unD)
            : base(pPadron, pDir, pFecha, pAlquiler, unD)
        {
            Portero = pPortero;
            Piso = pPiso;
            GComunes = pGastos;
        }
        


        //Operaciones
        public override string ToString()
        {
            string _completo = base.ToString() + " - Piso: " + _Piso + " - ";

            if (_Portero)
                _completo += " Portero";
            else
                _completo += " Sin Portero";

            return (_completo);
        }

     }
}
