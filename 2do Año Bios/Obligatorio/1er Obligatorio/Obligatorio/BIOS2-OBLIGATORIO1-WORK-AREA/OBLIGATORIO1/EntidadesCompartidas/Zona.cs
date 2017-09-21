using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Zona
    {
        private string _Nombre;
        private string _Departamento;
        private string _NombreOficial;
        private int _Habitantes;
        private List<string> _Servicios;
        private bool _Activo;

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if(value.Trim().Length != 3)
                {
                    throw new Exception("El Nombre debe de tener 3 caracteres");
                }
                else
                {
                    _Nombre = value.Trim();
                }
            }
        }

        public string Departamento
        {
            get { return _Departamento; }
            set
            {
                _Departamento = value;
            }
        }

        public string NombreOficial
        {
            get { return _NombreOficial; }
            set
            {
                _NombreOficial = value;
            }
        }

        public int Habitantes
        {
            get { return _Habitantes; }
            set
            {
                if (value < 0 )
                {
                    throw new Exception("Los habitantes tienen que ser mayores a 0");
                }
                _Habitantes = value;
            }
        }

        public List<string> Servicios
        {
            get { return _Servicios; }
            set { _Servicios = value; }
        }

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        public Zona(string nombre,string departamento,string nombreoficial,int habitantes, List<string> servicios, bool activo)
        {
            Nombre = nombre;
            Departamento = departamento;
            NombreOficial = nombreoficial;
            Habitantes = habitantes;
            Servicios = servicios;
            Activo = activo;
        }
    }
}
