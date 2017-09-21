using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FachadaLogica
    {
        public static void AgregarArticulo(Articulo A)
        {
            LogicaArticulo LArticulos = new LogicaArticulo();
            LArticulos.AgregarArticulo(A);
        }

        public static void EliminarArticulo(Articulo A)
        {
            LogicaArticulo LArticulos = new LogicaArticulo();
            LArticulos.EliminarArticulo(A);
        }

        public static void ModificarArticulo(Articulo A)
        {
            LogicaArticulo LArticulos = new LogicaArticulo();
            LArticulos.ModificarArticulo(A);
        }

        public static Articulo BuscarArticulo(int fCodigo)
        {
            LogicaArticulo LArticulos = new LogicaArticulo();
            return LArticulos.BuscarArticulo(fCodigo);
        }


        public static List<Articulo> ListarArticulo()
        {

            LogicaArticulo LArticulos = new LogicaArticulo();
            List<Articulo> _Lista = LArticulos.ListarArticulo();
            return _Lista;
        }
    }
}
