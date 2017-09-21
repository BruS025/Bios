using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaFactura
    {
        void AgregarFactura(Factura F);
        void EliminarFactura(Factura F);
        Factura BuscarFactura(int pCodigo);
        List<Factura> ListarFactura();
    }
}
