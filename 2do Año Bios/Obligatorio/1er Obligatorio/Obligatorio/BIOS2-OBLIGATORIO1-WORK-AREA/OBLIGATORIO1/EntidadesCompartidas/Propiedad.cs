using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Propiedad
    {
        // Atributos
        private int _Padron;
        private Zona _Zona;
        private Empleado _Empleado;
        private int _Precio;
        private string _Direccion;
        private string _TipoDeAccion;
        private int _Baño;
        private int _Habitaciones;
        private int _MetrosCuadradosP;

        // Propiedades
        public int Padron
        {
            get { return _Padron; }
            set { _Padron = value; }
        }

        public Zona Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        public Empleado Empleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }

        public int Precio
        {
            get { return _Precio; }
            set {
                  if (value <= 0)
                  {
                    throw new Exception("ERROR: El precio deberia ser mayor a cero..");
                  }

                  else
                  {
                    _Precio = value;
                  }
                }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new Exception("ERROR: La direccion debe de tener entre 10 y 50 caracteres...");
                }

                else
                {
                    _Direccion = value;
                }
            }
        }

        public string TipoDeAccion
        {
            get { return _TipoDeAccion; }
            set
            {
                if(value == "Alquiler" || value == "Venta" || value == "Permuta")
                {
                    _TipoDeAccion = value;
                }

                else
                {
                    throw new Exception("ERROR: Debe ingresar un tipo valido..");
                }
            }
            
        }

        public int Baño
        {
            get { return _Baño; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("ERROR: La cantidad de baños deberia ser mayor a cero..");
                }

                else
                {
                    _Baño = value;
                }
            }
        }

        public int Habitaciones
        {
            get { return _Habitaciones; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("ERROR: La cantidad de habitaciones deberia ser mayor a cero..");
                }

                else
                {
                    _Habitaciones = value;
                }
            }
        }

        public int MetrosCuadradosP
        {
            get { return _MetrosCuadradosP; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("ERROR: Los metros cuadrados de la propiedad deberian ser mayor a cero..");
                }

                else
                {
                    _MetrosCuadradosP = value;
                }
            }
        }

        //Constructor
        public Propiedad(int padron, Zona zona, Empleado empleado, int precio, string direccion, string tipoDeAccion, int baño, int habitaciones, int metrosCuadradosP)
        {
            Padron = padron;
            Zona = zona;
            Empleado = empleado;
            Precio = precio;
            Direccion = direccion;
            TipoDeAccion = tipoDeAccion;
            Baño = baño;
            Habitaciones = habitaciones;
            MetrosCuadradosP = metrosCuadradosP;

        }

    }
}
