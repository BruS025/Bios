using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaVivienda
    {
        public static void Alta(Vivienda unaV)
        {
            if (unaV is Apartamento)
                PersistenciaApartamento.Alta((Apartamento)unaV);
            else if (unaV is Casa)
                throw new Exception("No se eimplemento Alta Casa");
            else if (unaV == null)
                throw new Exception("No se indicio Vivienda para Alta");
        }

        public static void Modificar(Vivienda unaV)
        {
            if (unaV is Apartamento)
                PersistenciaApartamento.Modificar((Apartamento)unaV);
            else if (unaV is Casa)
                throw new Exception("No se eimplemento Modificar Casa");
            else if (unaV == null)
                throw new Exception("No se indicio Vivienda para Modificar");
 
        }

        public static void Eliminar(Vivienda unaV)
        {
            if (unaV == null)
               throw new Exception("No se indicio Vivienda para Eliminar"); 
            else
                PersistenciaVivienda.Eliminar(unaV);
 
        }

        public static EntidadesCompartidas.Vivienda Buscar(int pPadron)
        {
            Vivienda unaV = null;

            unaV = PersistenciaApartamento.Buscar(pPadron);

            if (unaV == null)
            {
                //se deberia llamar a la PersitenciaCasa
            }

            return unaV;
        }

        public static List<EntidadesCompartidas.Vivienda> ListarTodo()
        {
            List<Vivienda> _lista = new List<Vivienda>();

            _lista.AddRange(PersistenciaCasa.ListarTodo());
            _lista.AddRange(PersistenciaApartamento.ListarTodo());
 
            return (_lista);
        }

        public static List<EntidadesCompartidas.Vivienda> ListarAntiguedad(int pAnios)
        {
            List<Vivienda> _lista = ListarTodo();
            List<Vivienda> _listaFiltrada = new List<Vivienda>();

            foreach(Vivienda unaV in _lista )
            {
                if (unaV.Antiguedad() >= pAnios)
                    _listaFiltrada.Add(unaV);
            }

            return (_listaFiltrada);
        }

        public static List<EntidadesCompartidas.Vivienda> ListarPorDuenio(Duenio unD)
        {
            List<Vivienda> _lista = new List<Vivienda>();

            _lista.AddRange(PersistenciaApartamento.ListarPorDuenio(unD));
            _lista.AddRange(PersistenciaCasa.ListarPorDuenio(unD));

            return (_lista);
        }

        public static void CantTotalviviendas(ref int pCantAptos, ref int pCantCasas)
        {
            pCantAptos = Persistencia.PersistenciaApartamento.CantTotalAptos();
            pCantCasas = Persistencia.PersistenciaCasa.CantTotalCasas();
        }

    }
}
