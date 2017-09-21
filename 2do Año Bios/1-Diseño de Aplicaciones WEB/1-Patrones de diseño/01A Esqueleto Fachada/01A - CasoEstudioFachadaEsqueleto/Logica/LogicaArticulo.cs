using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulo
    {

        public void AgregarArticulo(Articulo A)
        {

            FachadaPersistencia.AgregarArticulo(A);
        }

        public void EliminarArticulo(Articulo A)
        {
            FachadaPersistencia.EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            FachadaPersistencia.ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int lCodigo)
        {
           return FachadaPersistencia.BuscarArticulo(lCodigo);
        }


        public List<Articulo> ListarArticulo()
        {

            return FachadaPersistencia.ListarArticulo();
        }
    }
}
