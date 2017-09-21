using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Persistencia
{
    public class FabricaPersitencia
    {
        public static IPersistenciaCasa getPersistenciaCasa()
        {
            return (PersistenciaCasa.ObtenerInstancia());
        }

        public static IPersistenciaApartamento getPersistenciaApartamento()
        {
            return (PersistenciaApartamento.ObtenerInstancia());
        }

        public static IPersistenciaLocal getPersistenciaLocal()
        {
            return (PersistenciaLocal.ObtenerInstancia());
        }

        public static IPersistenciaEmpleado getPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.ObtenerInstancia());
        }

        public static IPersistenciaZona getPersistenciaZona()
        {
            return (PersistenciaZona.ObtenerInstancia());
        }

        public static IPersistenciaVisita getPersistenciaVisita()
        {
            return (PersistenciaVisita.ObtenerInstancia());
        }
    }
}
