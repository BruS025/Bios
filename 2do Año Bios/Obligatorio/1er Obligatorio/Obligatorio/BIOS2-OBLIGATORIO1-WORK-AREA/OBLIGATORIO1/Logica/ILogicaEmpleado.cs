using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaEmpleado
    {
        void Agregar(Empleado empleado);
        void Eliminar(Empleado empleado);
        void Modificar(Empleado empleado);
        Empleado Buscar(string nombreLogueo);
        List<Empleado> Listar();
        List<Empleado> ListarTodos();
        bool Login(string Nombre, string Contraseña);
    }
}
