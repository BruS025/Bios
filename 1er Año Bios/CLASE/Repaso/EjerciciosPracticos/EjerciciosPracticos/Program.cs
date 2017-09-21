using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPracticos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Metodo para buscar valores dentro de una matriz

            int[] vector = { 3, 4, 5, 8, 4, 9, 8, 7, 12345, 7 };

            Console.Write("ingrese numero:");
            int valor=Convert.ToInt32(Console.ReadLine());
            Console.Write("ingrese numero 2:");
            int valor2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("El resultado es:" + comprar(valor,valor2));

            Console.ReadLine();
            
        }
        public static string comprar(int valor1,int valor2)
        {
            if (valor1 < valor2)
            {
                return "Valor 1 menor al valor 2";
            }
            else if (valor1 == valor2)
            {
                return "valor 1 igual al valor 2";
            }
            else if (valor1 > valor2)
                    {
                return "valor 1 mayor";
                     }
            return "resultado no encontrado";
        }
        }
    }

