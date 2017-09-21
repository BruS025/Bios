using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numa = 0;
            int[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Num a buscar:");
            numa = Console.Read();
            Console.WriteLine("resultado: " + devolver (vector,numa));

            Console.ReadLine();
            Console.Read();

        }
        public static bool devolver(int []vectorBuscar,int numaBuscar)
        {
            for(int i =0; i<=vectorBuscar.Length; i++)
            {
                if (numaBuscar == vectorBuscar[i])
                {
                    return true;
                }
                else return false;
            }

            return false;
        }
    }
}

