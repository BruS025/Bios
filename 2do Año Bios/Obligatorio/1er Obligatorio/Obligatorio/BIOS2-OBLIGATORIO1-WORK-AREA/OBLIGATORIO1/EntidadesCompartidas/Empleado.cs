using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        // Atributos
        private string _NombreLogueo;
        private string _Contraseña;
        private bool _Activo;

        // Propiedades
        public string NombreLogueo
        {
            get { return _NombreLogueo; }
            set
            {
                if (value.Length > 10 )
                {
                    throw new Exception("ERROR: El nombre de logueo debe de tener hasta 10 caracteres...");
                }

                else
                {
                    _NombreLogueo = value;
                }
            }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception("ERROR: La contraseña debe ser de 10 caracteres...");
                }

                else
                {
                    _Contraseña = value;
                }
            }
        }

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        //Constructor
        public Empleado(string nombreLogueo, string contraseña, bool activo)
        {
            NombreLogueo = nombreLogueo;
            Contraseña = contraseña;
            Activo = activo;

        }

    }
}
