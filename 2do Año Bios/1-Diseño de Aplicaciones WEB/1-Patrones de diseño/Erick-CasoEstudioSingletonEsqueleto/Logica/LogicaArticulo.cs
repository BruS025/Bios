using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    internal class LogicaArticulo:ILogicaArticulo
    {
        private static LogicaArticulo _lArticulos = null;

        private LogicaArticulo() { }

        public static LogicaArticulo getClass
        {
            get
            {
                if (_lArticulos == null) { _lArticulos = new LogicaArticulo(); }
                return _lArticulos;
            }
       }


        public void AgregarArticulo(EntidadesCompartidas.Articulo A)
        {
            Persistencia.IPersistenciaArticulo PArticulo = Persistencia.FabricaPersistencia.getPersistenciaArticulo();
            PArticulo.AgregarArticulo(A);

        }
        public void EliminarArticulo(EntidadesCompartidas.Articulo A)
        {
            Persistencia.IPersistenciaArticulo PArticulo = Persistencia.FabricaPersistencia.getPersistenciaArticulo();
            PArticulo.EliminarArticulo(A);

        }
        public void ModificarArticulo(EntidadesCompartidas.Articulo A)
        {
            Persistencia.IPersistenciaArticulo PArticulo = Persistencia.FabricaPersistencia.getPersistenciaArticulo();
            PArticulo.ModificarArticulo(A);

        }
        public EntidadesCompartidas.Articulo BuscarArticulo(int pCodigo)
        {
            Persistencia.IPersistenciaArticulo PArticulo = Persistencia.FabricaPersistencia.getPersistenciaArticulo();
            return PArticulo.BuscarArticulo(pCodigo);

        }
        public List<EntidadesCompartidas.Articulo> ListarArticulo()
        {

            Persistencia.IPersistenciaArticulo PArticulo = Persistencia.FabricaPersistencia.getPersistenciaArticulo();
            return PArticulo.ListarArticulo();
        }
    }
}
