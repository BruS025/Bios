using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2.Clases
{
    public class Excepciones : Exception
    {
        // Constructor por defecto
        public Excepciones() : base() { }

        // Constructor con mensaje
        public Excepciones (string mensaje) : base (mensaje) { }

        // Constructor tipo excepcion
        public Excepciones (int numeroExcepcion , string campo) : base () { }

        // Verificador de excepciones
        public static string mensajesExc (int numero , string campo , int minimo)
        {
            if (numero == 1)
            {
                return string.Format("El campo '{0}' no puede estar vacío.", campo);
            }

            else if (numero == 2)
            {
                return string.Format("Se ha ingresado un tipo de dato no válido en el campo: {0}.", campo);
            }

            else if (numero == 3)
            {
                return string.Format("El '{0}' ya se encuentra registrado.", campo);
            }

            else if (numero == 4)
            {
                return string.Format("El largo mínimo del campo {0} es {1}.", campo, minimo);
            }

            else if (numero == 5)
            {
                return string.Format("Ingrese algún caracter en el campo de búsqueda .");
            }

            else if (numero == 6)
            {
                return string.Format("La fecha del vencimiento debe ser mayor al día actual.");
            }

            else if (numero == 7)
            {
                return string.Format("El valor mínimo del campo {0} es {1}.", campo, minimo);
            }


            else
            {
                return string.Format("Error no identificado.");
            }
        }    
    }
}