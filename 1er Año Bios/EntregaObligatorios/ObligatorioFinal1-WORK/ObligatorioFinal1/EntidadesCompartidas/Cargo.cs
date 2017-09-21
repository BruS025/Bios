using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
        public class Cargo
        {
            // Atributos
            public string _Tipo;
            public int _Id;
            //public string _Especialidad;

            // Constructor simple
            public Cargo() { }

            // Constructor completo
            public Cargo(string Tipo, int Id)
            {
                _Tipo = Tipo;
                _Id = Id;

            }

            // Metodos
            public string Tipo
            {
                get { return _Tipo; }
                set
                {
                    {
                        if (value.Trim().Length < 3)
                        {
                            throw new Exception("ERROR: El nombre de la casa debe tener al menos 3 caracteres...");
                        }

                        else
                        {
                            _Tipo = value.Trim();
                        }
                    }
                }
            }

            public int Id
            {
                get { return _Id; }
                set { _Id = value; }
            }     
    }
}
