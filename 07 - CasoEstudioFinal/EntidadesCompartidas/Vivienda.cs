using System;
using System.Collections.Generic;
using System.Text;



namespace EntidadesCompartidas
{


    public abstract class Vivienda
    {
        //Atributos
        private int _Padron;
        private string _Direccion;
        private DateTime _FechaCons;
        private int _Alquiler;

        //Atributo de Asoc.
        Duenio _Dueño;


        //Propiedades
        public int Padron
        {
            set
            {
                if (value <= 0)
                    throw new Exception("Numero de Padron Invalido");
                else
                    _Padron = value;
            }
            get { return _Padron; }
        }

        public string Direccion
        {
            set { _Direccion = value; }
            get { return _Direccion; }
        }

        public DateTime FechaCons
        {
            set
            {
                if (DateTime.Now >= value)
                    _FechaCons = value;
                else
                    throw new Exception("No se trabaja con Viviendas que aun no se construyeron");
            }
            get { return _FechaCons; }
        }

        public int Alquiler
        {
            set
            {
                if (value <= 0)
                    throw new Exception("Alquiler debe ser numero positivo");
                else
                    _Alquiler = value;
            }
            get { return _Alquiler; }
        }

        public Duenio Dueño
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el dueño");
                else
                    _Dueño = value;
            }
            get { return _Dueño; }

        }

 
        //Constructores    
        public Vivienda(int pPadron, string pDir, DateTime pFecha, int pAlq, Duenio unD)
        {
            Padron = pPadron;
            Direccion = pDir;
            FechaCons = pFecha;
            Alquiler = pAlq;
            Dueño = unD;
        }

        //Operaciones 
        public int Antiguedad()
        {
            TimeSpan _diferencia = DateTime.Now.Subtract(_FechaCons);
            int _CantDias = (int)Math.Truncate(_diferencia.Days / 365.25);

            return (_CantDias);
        }

        public override string ToString()
        {
            return ("Padron: " + _Padron + " - Dir: " + _Direccion + " - Fecha Const.: " + _FechaCons.ToShortDateString()  + " pesos - Dueño: " + this.Dueño.Nombre);
        }

    }
}