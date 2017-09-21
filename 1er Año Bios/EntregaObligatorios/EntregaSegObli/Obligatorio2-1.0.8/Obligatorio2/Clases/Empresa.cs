using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Clases
{
    public class Empresa
    {
        // Atributos
        private long _rutEmpresa;
        private string _direccionEmpresa;
        private long _telefonoEmpresa;

        // Constructor por defecto
        public Empresa() { }   

        // Constructor con parametros
        public Empresa(long rutEmpresa, string direccionEmpresa, long telefonoEmpresa)
        {
        _rutEmpresa = rutEmpresa;
        _direccionEmpresa = direccionEmpresa;
        _telefonoEmpresa = telefonoEmpresa;
        }

        // Propiedades RutEmpresa
        public long RutEmpresa
        {
            get { return _rutEmpresa; }
            set
            {
                if (value > 0)
                {
                    _rutEmpresa = value;
                }

                else
                {
                    throw new Excepciones("Es obligatorio completar este campo.");
                }
            }
        }

        // Propiedades DireccionEmpresa
        public string DireccionEmpresa
        {
            get { return _direccionEmpresa; }
            set
            {
                if (value.Trim().Length > 10)
                {
                    _direccionEmpresa = value;
                }

                else
                {
                    throw new Excepciones("Se deben ingresar al menos diez caracteres.");
                }
            }
        }

        // Propiedades TelefonoEmpresa
        public long TelefonoEmpresa
        {
            get { return _telefonoEmpresa; }
            set
            {
                if (value > 0)
                {
                    _telefonoEmpresa = value;
                }

                else
                {
                    throw new Excepciones("Se debe ingresar al menos un digito.");
                }
            }
        }
    }
}