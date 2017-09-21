using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    internal class LogicaFactura:ILogicaFactura
    {
        private static LogicaFactura _lFactura = null;

        private LogicaFactura() { }

        public static LogicaFactura getClass
        {
            get
            {
                if (_lFactura == null) { _lFactura = new LogicaFactura(); }
                return _lFactura;
            }
       }


        public void AgregarFactura(EntidadesCompartidas.Factura factura)
        {
            Persistencia.IPersistenciaFactura PFactura = Persistencia.FabricaPersistencia.getPersistenciaFactura();
            PFactura.AltaFactura(factura);
        }

        public EntidadesCompartidas.Factura BuscarFactura(int id)
        {
            Persistencia.IPersistenciaFactura PFactura = Persistencia.FabricaPersistencia.getPersistenciaFactura();
            return PFactura.BuscarFactura(id);
        }

        public void BajaFactura(int id)
        {
            Persistencia.IPersistenciaFactura PFactura = Persistencia.FabricaPersistencia.getPersistenciaFactura();
            PFactura.EliminarFactura(id);
        }

        public void ModificarFactura(EntidadesCompartidas.Factura factura)
        {
            Persistencia.IPersistenciaFactura PFactura = Persistencia.FabricaPersistencia.getPersistenciaFactura();
            PFactura.ModificarFactura(factura);
        }
    }
}
