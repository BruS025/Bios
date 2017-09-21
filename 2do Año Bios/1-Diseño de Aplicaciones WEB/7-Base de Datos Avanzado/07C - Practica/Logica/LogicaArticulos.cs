using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulos:ILogicaArticulos
    {
        public void AgregarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulos().AgregarArticulo(A);
        }

        public void EliminarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulos().EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulos().ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int pCodigo)
        {
            return FabricaPersistencia.getPersistenciaArticulos().BuscarArticulo(pCodigo);
        }

        public List<Articulo> ListarArticulo()
        {
            return FabricaPersistencia.getPersistenciaArticulos().ListarArticulo();
        }

        //SINGLETON
        
        private static LogicaArticulos _instancia = null;

        private LogicaArticulos() { }

        public static LogicaArticulos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaArticulos();

            return _instancia;
        }
    }
}
