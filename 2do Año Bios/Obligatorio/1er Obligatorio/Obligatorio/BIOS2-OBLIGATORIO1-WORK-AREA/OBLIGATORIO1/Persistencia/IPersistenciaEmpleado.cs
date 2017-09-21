using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        void Agregar(Empleado empleado);
        void Eliminar(Empleado empleado);
        void Modificar(Empleado empleado);          
        Empleado Buscar(string nombre);
        List<Empleado> Listar();
        List<Empleado> ListarTodos();
        bool Login(string nombre, string contraseña);
    }
}
