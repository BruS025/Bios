using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPropiedad : ILogicaPropiedad
    {
        // Singleton
        private static LogicaPropiedad _instancia = null;
        private LogicaPropiedad() { }

        public static LogicaPropiedad ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPropiedad();

            return _instancia;
        }

        // AGREGAR
        public void Agregar(Propiedad propiedad)
        {
            if (propiedad is Apartamento)
            {
                IPersistenciaApartamento FabricaApartamento = FabricaPersitencia.getPersistenciaApartamento();
                FabricaApartamento.Agregar((Apartamento)propiedad);

            }

            else if (propiedad is Casa)
            {
                if (((Casa)propiedad).MetrosCuadradosC > propiedad.MetrosCuadradosP)
                {
                    throw new Exception("Los metros cuadrados de la casa deben ser menores a los metros cuadrados de la propiedad...");
                }

                IPersistenciaCasa FabricaCasa = FabricaPersitencia.getPersistenciaCasa();
                FabricaCasa.Agregar((Casa)propiedad);

            }

            else if (propiedad is Local)
            {
                IPersistenciaLocal FabricaLocal = FabricaPersitencia.getPersistenciaLocal();
                FabricaLocal.Agregar((Local)propiedad);

            }         
        }

        // MODIFICAR
        public void Modificar(Propiedad propiedad)
        {
            if (propiedad is Apartamento)
            {
                IPersistenciaApartamento FabricaApartamento = FabricaPersitencia.getPersistenciaApartamento();
                FabricaApartamento.Modificar((Apartamento)propiedad);

            }

            else if (propiedad is Casa)
            {
                if (((Casa)propiedad).MetrosCuadradosC > propiedad.MetrosCuadradosP)
                {
                    throw new Exception("Los metros cuadrados de la casa deben ser menores a los metros cuadrados de la propiedad...");
                }

                IPersistenciaCasa FabricaCasa = FabricaPersitencia.getPersistenciaCasa();
                FabricaCasa.Modificar((Casa)propiedad);

            }

            else if (propiedad is Local)
            {
                IPersistenciaLocal FabricaLocal = FabricaPersitencia.getPersistenciaLocal();
                FabricaLocal.Modificar((Local)propiedad);

            }
        }

        // ELIMINAR
        public void Eliminar(Propiedad propiedad)
        {
            if (propiedad is Apartamento)
            {
                IPersistenciaApartamento FabricaApartamento = FabricaPersitencia.getPersistenciaApartamento();
                FabricaApartamento.Eliminar((Apartamento)propiedad);

            }

            else if (propiedad is Casa)
            {
                IPersistenciaCasa FabricaCasa = FabricaPersitencia.getPersistenciaCasa();
                FabricaCasa.Eliminar((Casa)propiedad);

            }

            else if (propiedad is Local)
            {
                IPersistenciaLocal FabricaLocal = FabricaPersitencia.getPersistenciaLocal();
                FabricaLocal.Eliminar((Local)propiedad);

            }
        }

        // BUSCAR
        public Propiedad Buscar(int padron)
        {

            Propiedad _Propiedad = FabricaPersitencia.getPersistenciaApartamento().Buscar(padron);
            if (_Propiedad == null)
            {
                _Propiedad = FabricaPersitencia.getPersistenciaCasa().Buscar(padron);
                if (_Propiedad == null)
                {
                    _Propiedad = FabricaPersitencia.getPersistenciaLocal().Buscar(padron);
                    return _Propiedad;
                }
                return _Propiedad;
            }
            return _Propiedad;
        }

        // LISTAR
        public List<Propiedad> Listar()
        {
            List<Propiedad> _Propiedades = new List<Propiedad>();
            _Propiedades.AddRange(FabricaPersitencia.getPersistenciaApartamento().Listar());
            _Propiedades.AddRange(FabricaPersitencia.getPersistenciaCasa().Listar());
            _Propiedades.AddRange(FabricaPersitencia.getPersistenciaLocal().Listar());

            return _Propiedades;

        }

    }
}
