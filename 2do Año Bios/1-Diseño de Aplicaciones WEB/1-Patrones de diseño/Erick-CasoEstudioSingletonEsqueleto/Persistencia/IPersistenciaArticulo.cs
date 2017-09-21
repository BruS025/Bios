using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public interface IPersistenciaArticulo
    {
        void AgregarArticulo(EntidadesCompartidas.Articulo A);
        void EliminarArticulo(EntidadesCompartidas.Articulo A);
        void ModificarArticulo(EntidadesCompartidas.Articulo A);
        EntidadesCompartidas.Articulo BuscarArticulo(int pCodigo);
        List<EntidadesCompartidas.Articulo> ListarArticulo();
       
    }
}
