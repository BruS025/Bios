using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Administrador : Usuario
    {
        // Atributos
        public int _Cargo;

        // Constructor simple
        public Administrador() { }

        // Constructor completo
        public Administrador(string Nombre, string Apellido, string Contrasenia, int Documento, string UsuarioNombre, int Cargo) : base(Nombre, Apellido, Contrasenia, Documento, UsuarioNombre)
        {

            _Cargo = Cargo;

        }

        // Metodos
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }           
        }

    }
}
