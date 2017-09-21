using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class FachadaPersistencia
    {
        public static void AgregarArticulo(Articulo A)
        {
            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            PArticulos.AgregarArt(A);
        }

        public static void EliminarArticulo(Articulo A)
        {
            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            PArticulos.EliminarArt(A);
        }

        public static void ModificarArticulo(Articulo A)
        {
            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            PArticulos.ModificarArt(A);
        }

        public static Articulo BuscarArticulo(int fCodigo)
        {
            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            return PArticulos.BuscarArt(fCodigo);
        }


        public static List<Articulo> ListarArticulo()
        {   
            
            PersistenciaArticulos PArticulos = new PersistenciaArticulos();
            List<Articulo> _Lista = PArticulos.ListarArt();
            return _Lista;
        }

    }
}
