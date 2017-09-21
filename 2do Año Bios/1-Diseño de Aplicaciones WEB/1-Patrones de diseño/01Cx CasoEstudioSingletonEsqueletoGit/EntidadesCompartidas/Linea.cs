using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Linea
    {
        //atributos
        private int _idLin;
        private Articulo _Art;
        private int _CanLin;
        private int _idFac;
        
        //propiedades
        public int IdLinea
        {
            get { return _idLin; }
            set { _idLin = value; }
        }
        public Articulo Articulo
        {
            get { return _Art; }
            set { _Art = value; }
        }
        public int IdCantidad
        {
            get { return _CanLin; }
            set { _CanLin = value; }
        }

        public int IdFactura
        {
            get { return _idFac; }
            set { _idFac = value; }
        }

        //Contructor
        public Linea(int idLinea, Articulo art, int CantLin, int idFac)
        {
            _idLin = idLinea;
            _Art = art;
            _CanLin = CantLin;
            _idFac = idFac;
        }
  
    }
}
