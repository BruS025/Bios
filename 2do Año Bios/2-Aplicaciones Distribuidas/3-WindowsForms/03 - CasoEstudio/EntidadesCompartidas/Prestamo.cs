using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Prestamo
    {
        //atributos
        private int _idPrestamo;
        private String _nombreCliente;
        private DateTime _fechaPide;
        private int _duracion;
        private List<Libro> _losLibros;

        /*-----------------------------------
        !!!FALTA TODO CODIGO DEFENSIVO !!!!!!
        -----------------------------------*/

        //propiedades
        public int IdPrestamo
        {
            get { return _idPrestamo; }
            set { _idPrestamo = value; }
        }

        public String NombreCliente
        {
            get { return _nombreCliente; }
            set { _nombreCliente = value; }
        }

        public DateTime FechaPide
        {
            get { return _fechaPide; }
            set { _fechaPide = value; }
        }

        public int Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }

        public List<Libro> LosLibros
        {
            get { return _losLibros; }
            set { _losLibros = value; }
        }

        //Contructor
        public Prestamo(int pIdPrestamo, String pNombreCliente, DateTime pFechaPide, int pduracion, List<Libro> pLosLibros)
        {
            _idPrestamo = pIdPrestamo;
            _nombreCliente = pNombreCliente;
            _fechaPide = pFechaPide;
            _duracion = pduracion;
            _losLibros = pLosLibros;
        }
    }
}
