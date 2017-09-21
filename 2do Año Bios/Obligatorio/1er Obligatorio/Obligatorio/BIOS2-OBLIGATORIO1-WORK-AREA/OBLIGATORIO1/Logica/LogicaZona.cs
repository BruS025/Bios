using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaZona : ILogicaZona
    {
        // Singleton
        private static LogicaZona _instancia = null;
        private LogicaZona() { }

        public static LogicaZona ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaZona();

            return _instancia;
        }

        // CREAR
        public void Agregar(Zona zona)
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            FabricaZona.Agregar(zona);
        }

        // ELIMINAR
        public void Eliminar(Zona zona)
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            FabricaZona.Eliminar(zona);
        }

        // MODIFICAR
        public void Modificar(Zona zona)
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            FabricaZona.Modificar(zona);
        }

        public Zona Buscar(string nombre, string departamento)
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            return FabricaZona.Buscar(nombre, departamento);
        }

        public Zona BuscarT(string nombre, string departamento)
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            return FabricaZona.BuscarT(nombre, departamento);
        }

        public List<Zona> Listar()
        {
            IPersistenciaZona FabricaZona = FabricaPersitencia.getPersistenciaZona();
            return FabricaZona.Listar();
        }

    }
}
