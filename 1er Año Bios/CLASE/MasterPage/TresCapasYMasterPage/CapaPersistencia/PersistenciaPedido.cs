using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using EntidadesCompartidas;

namespace CapaPersistencia
{
    public class PersistenciaPedido
    {
        public static int AgregarPedido(Pedido pedido)
        {
            /*1-Agregar pedido
             *2-Obtener id pedido
             *3-Agregar ItemPedido--Llama al metodo agregar item por cada item que tiene asociado
             */

            throw new NotImplementedException();
        }

        public static List<Pedido> Listar()
        {
            //Select
            throw new NotImplementedException();
        }

        private static bool AgregarItem(ItemPedido item, int idPedido)
        {
            //InserT Normal
            throw new NotImplementedException();
        }
    }
}

