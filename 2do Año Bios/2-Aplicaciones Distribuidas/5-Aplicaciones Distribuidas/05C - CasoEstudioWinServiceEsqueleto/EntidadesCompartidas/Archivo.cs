using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Archivo
    {

        #region Atributos y Properties

        private string _nombre;
        private string _extension;
        private Int64 _tamanio;
        private DateTime _fechaCreacion;

        public string Nombre
        {
            get { return _nombre; }
            set {
                if (value.Trim().Length > 0)
                    _nombre = value;
                else
                    throw new Exception("Error - Nombre Obligatorio");
            }
        }
       
        public string Extension
        {
            get { return _extension; }
            set {
                if ((value.Trim().Length > 0))
                    _extension = value;
                else
                    throw new Exception("Error - Extension al menos 1");
            }
        }       

        public Int64 Tamanio
        {
            get { return _tamanio; }
            set { 
                if (value > 0)
                _tamanio = value;
                else
                    throw new Exception("Error - Tamañio solo acepta Positivos");
            }
        }

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        #endregion

        #region Constructores

        public Archivo(string pnombre, string pextension, Int64 ptamanio, DateTime pfechaCreacion)
        {
            Nombre = pnombre;
            Extension = pextension;
            Tamanio = ptamanio;
            FechaCreacion = pfechaCreacion;
        }

        #endregion
    }
}
