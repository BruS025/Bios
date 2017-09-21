using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Visita
    {
        // Atributos
        private DateTime _FechaHora;
        private int _Telefono;
        private string _Nombre;
        private Propiedad _Propiedad;

        // Propiedades
        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set
            {
                if(value < DateTime.Now)
                {
                    throw new Exception("ERROR: La fecha debe ser mayor a la actual..");
                }

                else
                {
                    _FechaHora = value;
                }
            }
        }

        public int Telefono
        {
            get { return _Telefono; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("ERROR: La cantidad de baños deberia ser mayor a cero..");
                }

                else
                {
                    _Telefono = value;
                }
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("ERROR: El nombre de logueo debe de tener hasta 20 caracteres...");
                }

                else
                {
                    _Nombre = value;
                }
            }
        }

        public Propiedad Propiedad
        {
            get { return _Propiedad; }
            set { _Propiedad = value; }
        }

        //Constructor
        public Visita(DateTime fechaHora, int telefono, string nombre, Propiedad propiedad)
        {
            FechaHora = fechaHora;
            Telefono = telefono;
            Nombre = nombre;
            Propiedad = propiedad;

        }
    }

}
