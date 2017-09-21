using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public interface ILogicaFactura
    {
        void AgregarFactura(EntidadesCompartidas.Factura factura);
        EntidadesCompartidas.Factura BuscarFactura(int id);
        void BajaFactura(int id);
        void ModificarFactura(EntidadesCompartidas.Factura factura);
    }
}
