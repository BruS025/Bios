using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaEmpleado : ILogicaEmpleado
    {
        // Singleton
        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() { }

        public static LogicaEmpleado ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();

            return _instancia;
        }

        public void Agregar(Empleado empleado)
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            FabricaEmpleado.Agregar(empleado);
        }

        public void Eliminar(Empleado empleado)
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            FabricaEmpleado.Eliminar(empleado);
        }

        public void Modificar(Empleado empleado)
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            FabricaEmpleado.Modificar(empleado);
        }

        public Empleado Buscar(string nombreLogueo)
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            return FabricaEmpleado.Buscar(nombreLogueo);
        }

        public List<Empleado> Listar()
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            return FabricaEmpleado.Listar();
        }

        public List<Empleado> ListarTodos()
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            return FabricaEmpleado.ListarTodos();
        }

        public bool Login(string nombre, string contraseña)
        {
            IPersistenciaEmpleado FabricaEmpleado = FabricaPersitencia.getPersistenciaEmpleado();
            return FabricaEmpleado.Login(nombre, contraseña);
        }
    }
}
