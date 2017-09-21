using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public interface IPersistenciaFactura
    {
        void AltaFactura(EntidadesCompartidas.Factura factura);
        void EliminarFactura(int id);
        EntidadesCompartidas.Factura BuscarFactura(int id);
        void ModificarFactura(EntidadesCompartidas.Factura factura);
    }
}
