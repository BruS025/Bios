using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaMail
    {
       public static List<EntidadesCompartidas.Mail> ListarMail()
        {
            EntidadesCompartidas.Mail _UnMail;
            List<EntidadesCompartidas.Mail> _ListaMail = new List<EntidadesCompartidas.Mail>();
            List<EntidadesCompartidas.Usuarios> user = LogicaUsuario.ListarUsuarios();

            _UnMail = new EntidadesCompartidas.Mail(1, user[0], user[1], "Aca va Asunto 01234567890123456789", "abcdeabcdeabcdeabcdeabcdeabcdeabcdeabcde");
            _ListaMail.Add(_UnMail);
            _UnMail = new EntidadesCompartidas.Mail(1, user[0], user[3], "Aca va Asunto", " ");
            _ListaMail.Add(_UnMail);
            _UnMail = new EntidadesCompartidas.Mail(1, user[4], user[5], "Aca va Asunto", "abcdeabcdeabcdeabcdeabcdeabcdeabcde");
            _ListaMail.Add(_UnMail);
            _UnMail = new EntidadesCompartidas.Mail(1, user[0], user[2], "Aca1", "abcdeabcdeabcdeabcdeabcdeabcde");
            _ListaMail.Add(_UnMail);
            _UnMail = new EntidadesCompartidas.Mail(1, user[0], user[3], "Aca2", "abcdeabcdeabcdeabcdeabcdeabcde");
            _ListaMail.Add(_UnMail);
            _UnMail = new EntidadesCompartidas.Mail(1, user[6], user[7], "Aca3", "abcdeabcdeabcdeabcdeabcdeabcde");
            _ListaMail.Add(_UnMail);

            return (_ListaMail);

        }
    }
}
