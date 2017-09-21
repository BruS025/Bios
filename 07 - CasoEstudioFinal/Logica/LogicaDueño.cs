using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Persistencia;
using EntidadesCompartidas;


namespace Logica
{
    public class LogicaDueño
    {
        public static void Alta(Duenio unD)
        {
            PersitenciaDueño.Alta(unD);
         }

        public static void Modificar(Duenio unD)
        {
            PersitenciaDueño.Modificar(unD);
        }

        public static void Eliminar(Duenio unD)
        {
            PersitenciaDueño.Eliminar(unD);
        }

        public static Duenio Buscar(int pCedula)
        {
            return (PersitenciaDueño.Buscar(pCedula));
        }

        public static List<Duenio> Listar()
        {
            return (PersitenciaDueño.Listar());
        }

    }
}
