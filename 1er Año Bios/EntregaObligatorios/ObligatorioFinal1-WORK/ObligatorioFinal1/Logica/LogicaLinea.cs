using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaLinea
    {
        public static int Agregar(Linea linea, double totalVenta, Cliente cliente)
        {
            return PersistenciaLinea.Agregar(linea, totalVenta, cliente);

        }

        public static List<Linea> Pendientes(int venta)
        {
            return PersistenciaLinea.Pendientes(venta);
        }
    }
}
