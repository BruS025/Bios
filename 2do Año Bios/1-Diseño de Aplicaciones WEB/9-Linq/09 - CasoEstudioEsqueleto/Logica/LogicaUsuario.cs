using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaUsuario
    {
        public static List<EntidadesCompartidas.Usuarios> ListarUsuarios()
        {
            EntidadesCompartidas.Usuarios _UnUser;

            List<EntidadesCompartidas.Usuarios> _listUser = new List<EntidadesCompartidas.Usuarios>();

            _UnUser = new EntidadesCompartidas.Usuarios("Andresito", "PassWord1", "AndresitoCompleto1");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario2", "PassWord2", "NombreCompleto2");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario3", "PassWord3", "NombreCompleto3");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario4", "PassWord4", "NombreCompleto4");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario5", "PassWord5", "NombreCompleto5");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario6", "PassWord6", "NombreCompleto6");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario7", "PassWord7", "NombreCompleto7");
            _listUser.Add(_UnUser);
            _UnUser = new EntidadesCompartidas.Usuarios("NombreUsuario1", "PassWord8", "NombreCompleto8");
            _listUser.Add(_UnUser);

            return (_listUser);
        }
    }
}
