using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulo : ILogicaArticulos
    {
        // Singleton
        private static LogicaArticulo _instancia = null;
        private LogicaArticulo() { }

        public static LogicaArticulo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaArticulo();

            return _instancia;
        }

        public void AgregarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            FArticulo.AgregarArticulo(A);
        }

        public void EliminarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            FArticulo.EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            FArticulo.ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int codigo)
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            return FArticulo.BuscarArticulo(codigo);
        }

        public List<Articulo> ListarArticulo()
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            return FArticulo.ListarArticulo();
        }
    }
}
