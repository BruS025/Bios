using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;
using Logica;

namespace MiServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioArticulo" en el código, en svc y en el archivo de configuración a la vez.
    public class ServicioArticulo : IServicioArticulo
    {
        //operaciones
        void IServicioArticulo.AgregarArticulo(Articulo A)
        {
            FabricaLogica.getLogicaArticulo().AgregarArticulo(A);
        }
        void IServicioArticulo.EliminarArticulo(Articulo A)
        {
            FabricaLogica.getLogicaArticulo().EliminarArticulo(A);
        }

        void IServicioArticulo.ModificarArticulo(Articulo A)
        {
            FabricaLogica.getLogicaArticulo().ModificarArticulo(A);
        }

        Articulo IServicioArticulo.BuscarArticulo(int codigo)
        {
            return FabricaLogica.getLogicaArticulo().BuscarArticulo(codigo);
        }

        List<Articulo> IServicioArticulo.ListarArticulo()
        {
            return FabricaLogica.getLogicaArticulo().ListarArticulo();
        }
    }
}
