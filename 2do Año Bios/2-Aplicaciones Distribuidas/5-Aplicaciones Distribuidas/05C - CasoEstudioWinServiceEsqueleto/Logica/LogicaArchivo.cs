using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArchivo : ILogicaArchivo
    {
        //singleton
        private static LogicaArchivo _miInstancia;
        private LogicaArchivo() { }
        public static LogicaArchivo GetInstancia()
        {
            if (_miInstancia == null)
                _miInstancia = new LogicaArchivo();
            return (_miInstancia);
        }

        //operaciones
        public void AgregarArchivo(Archivo archivo)
        {
            IPersistenciaArchivo FArchivo = FabricaPersistencia.getPersistenciaArchivo();
            FArchivo.AgregarArchivo(archivo);
        }
    }
}
