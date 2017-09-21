using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Persistencia
{
    interface IPersistenciaFactura
    {
        void AltaFactura(Factura F);
        void EliminarFactura(Factura F);
        void BuscarFactura(Factura F);
    }
}
