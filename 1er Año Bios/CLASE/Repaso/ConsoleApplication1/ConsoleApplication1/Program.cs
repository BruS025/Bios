using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ingrese numero");
            int valor = Convert.ToInt32(Console.ReadLine());
            int[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> comprar = buscar(vector, valor);

            foreach(var busqueda in comprar)
            {
                Console.Write(busqueda);
            }
            Console.ReadLine();
        }
        public static List<Int32> buscar(int[]vector,int valorComp)
        {
            List<int> buscar = new List<int>();
            
            for (int i=0;i<vector.Length;i++)
            {
                if (vector[i]>=valorComp)
                {
                   buscar.Add(i);
                }
            }
            return buscar;
        }
    }
}
