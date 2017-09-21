using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulo : ILogicaArticulo
    {
        public void AgregarArticulo(Articulo A)
        {
            IpersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.AgregarArticulo(A);
        }

        public void EliminarArticulo(Articulo A)
        {
            IpersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            IpersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            FArticulo.ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int codigo)
        {
            IpersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            return FArticulo.BuscarArticulo(codigo);
        }

        public List<Articulo> ListarArticulo()
        {
            IpersistenciaArticulo FArticulo = FabricPersistencia.getPersistenciaArticulo();
            return FArticulo.ListarArticulo();
        }
    }
}
