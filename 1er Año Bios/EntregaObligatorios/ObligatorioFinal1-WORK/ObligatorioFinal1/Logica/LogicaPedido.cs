using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;
using System.Data;

namespace Logica
{
    public class LogicaPedido
    {
        public static int Agregar(Pedido venta, Cliente cliente)
        {
            return PersistenciaPedido.Agregar(venta, cliente);
        }

        public static List<Pedido> Pendientes(int doc)
        {
            return PersistenciaPedido.Pendientes(doc);
        }

        public static List<Pedido> PendientesTodos()
        {
            return PersistenciaPedido.PendientesTodos();
        }

        public static int Confirmar(int pedido, DateTime fecha)
        {
            return PersistenciaPedido.Confirmar(pedido, fecha);
        }

        public static DataSet XML (DateTime fecha)
        {
            return PersistenciaPedido.XML(fecha);
        }
    }
}
