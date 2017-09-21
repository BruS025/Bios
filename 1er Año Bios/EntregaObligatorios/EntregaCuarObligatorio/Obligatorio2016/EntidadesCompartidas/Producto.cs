using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntidadesCompartidas
{

    public class Producto
    {
        //Atributos
        private int _CodigoB;
        private string _Nombre;
        private DateTime _FechaVto;
        private double _Precio;

        //Constructor Completo
        public Producto(int pCod, string pNom, DateTime pFecha, double pPrecio)
        {
            CodigoB = pCod;
            Nombre = pNom;
            FechaVto = pFecha;
            Precio = pPrecio;
        }

        //Propiedades
        public int CodigoB
        {
            get { return _CodigoB; }
            set
            {
                if (value > 1)
                    _CodigoB = value;
                else
                    throw new Exception("ERROR:  El Código de Barras debe ser numero positivo...");
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (value.Length > 2)
                    _Nombre = value;
                else
                    throw new Exception("ERROR: El nombre del producto debe tener al menos 3 caracteres...");
            }
        }

        public DateTime FechaVto
        {
            get { return _FechaVto; }
            set
            {
                if ((value).Subtract(DateTime.Now).Days < 0)
                    throw new Exception("Error en la fecha de Vencimiento, Producto ya vencido");
                else
                    _FechaVto = value;
            }
        }

        public double Precio
        {
            get { return _Precio; }
            set
            {
                if (value > 0)
                    _Precio = value;
                else
                    throw new Exception("ERROR: El Precio debe ser un número mayor que 0");
            }
        }

        public override string ToString()
        {
            return ("Cod. Barras: " + CodigoB + ", Nombre: " + Nombre + ", Fecha Vto.: " + this.FechaVto.ToShortDateString() + ", Precio: " + Precio.ToString());
        }
    }
}