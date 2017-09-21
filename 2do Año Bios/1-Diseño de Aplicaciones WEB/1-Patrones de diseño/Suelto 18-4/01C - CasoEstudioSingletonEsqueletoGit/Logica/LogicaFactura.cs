using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaFactura : ILogicaFacturas
    {
        // Singleton
        private static LogicaFactura _instancia = null;
        private LogicaFactura() { }

        public static LogicaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaFactura();

            return _instancia;
        }

        public void AgregarFactura(Factura F)
        {
            IPersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.AgregarArticulo(F);
        }

        public void EliminarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int codigo)
        {
            IPersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            return FArticulo.BuscarArticulo(codigo);
        }

        public List<Articulo> ListarArticulo()
        {
            IPersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            return FArticulo.ListarArticulo();
        }
    }
}
