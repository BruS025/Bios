using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuario Buscar(int documento)
        {
            return PersistenciaUsuario.Buscar(documento);
        }

        public static int Agregar(Administrador user, int id)
        {
            return PersistenciaUsuario.Agregar(user, id);
        }

        public static int Modificar(Administrador user, int id)
        {
            return PersistenciaUsuario.Modificar(user, id);
        }

        public static int Eliminar(int documento)
        {
            return PersistenciaUsuario.Eliminar(documento);
        }

        public static List<Administrador> Listar(int id)
        {
            return PersistenciaUsuario.Listar(id);
        }

        public static int AgregarC(Cliente user)
        {
            return PersistenciaUsuario.AgregarC(user);
        }

        public static Cliente LoginCliente(string NomLogeo, string pass)
        {
            return PersistenciaUsuario.LoginCliente(NomLogeo, pass);
        }

        public static Administrador LoginAdministrador(string NomLogeo, string pass)
        {
            return PersistenciaUsuario.LoginAdministrador(NomLogeo, pass);
        }
    }
}