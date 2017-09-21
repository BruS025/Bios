using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using CapaPersistencia;


namespace CapaLogica
{
    public class LogicaArticulos
    {
        public static int Agregar(Articulo articulo)
        {
            return PersistenciaArticulo.Agregar(articulo);
        }

        public static int Modificar(Articulo articulo)
        {
            return PersistenciaArticulo.Modificar(articulo);
        }

        public static int Eliminar(int id)
        {
            return PersistenciaArticulo.Eliminar(id);
        }

        public static List<Articulo> Listar()
        {
            return PersistenciaArticulo.Listar();
        }

        public static bool buscar(int id)
        {
            return PersistenciaArticulo.Buscar(id);
        }
    }
}