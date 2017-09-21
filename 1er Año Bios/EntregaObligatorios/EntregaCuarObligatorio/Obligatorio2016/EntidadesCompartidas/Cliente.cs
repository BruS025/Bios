using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{

    public class Cliente
    {
        // Atributos
        private int _Cedula;
        private string _Direccion;
        private string _Telefono;
        private string _Nombre;

        // Constructor Completo
        public Cliente(int pCI, string pDir, string pTel, string pNom)
        {
            Cedula = pCI;
            Direccion = pDir;
            Telefono = pTel;
            Nombre = pNom;
        }

        // Métodos
        public int Cedula
        {
            get { return _Cedula; }
            set
            {
                if ((value < 100000) || (value > 9999999))
                    throw new Exception("ERROR: La cédula debe ser un número de 6 o 7 dígitos...");
                else
                    _Cedula = value;
            }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                if (value.Trim().Length < 5)
                    throw new Exception("ERROR: La direccion debe tener al menos 5 caracteres...");
                else
                    _Direccion = value.Trim();
            }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                try
                {
                    //verifica solo numeros
                    Convert.ToInt64(value.Trim());

                    if ((value.Trim().Length == 8) || (value.Trim().Length == 9))
                        _Telefono = value.Trim();
                    else
                        throw new Exception("ERROR: El Telefono de la Empresa debe tener 8 o 9 Dígitos...");
                }
                catch
                {
                    throw new Exception("ERROR: El Teléfono debe contener solamente 8 o 9 caracteres numéricos");
                }
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (value.Trim().Length < 5)
                    throw new Exception("ERROR: El nombre debe tener al menos 5 caracteres...");
                else
                    _Nombre = value.Trim();
            }
        }

        // ToString()
        public override string ToString()
        {
            return ("Cédula: " + _Cedula.ToString() + "; Nombre: " + _Nombre + "; Dir: " + _Direccion + "; Tel: " + _Telefono);
        }
    }

}