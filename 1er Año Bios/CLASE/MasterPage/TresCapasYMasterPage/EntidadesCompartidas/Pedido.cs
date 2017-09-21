using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Pedido
    {
        public int ID;
        public DateTime Fecha;
        public string Descripcion;
        public int Total;
        public int SubTotal;
        public string Cliente;

        public List<ItemPedido> Items;
    }
}
