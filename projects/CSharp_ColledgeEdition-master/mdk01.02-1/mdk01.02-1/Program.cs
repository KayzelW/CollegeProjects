using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mdk01._02_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            if (input.Length != 3)
                Console.WriteLine("А можно треугольник?");
                Environment.ExitCode = 1; //Не треугольник по количеству сторон

            List<int> borders = new List<int>();
            foreach (var item in input)
            {
                if (int.TryParse(item, out var x))
                {
                  
                  if (x <= 0) {
                    Console.WriteLine("А можно треугольник?");
                    Environment.ExitCode = 2; //Одна из сторон 0 или меньше
                    return;
                  }
                  
                  borders.Add(x);
                }
                else
                {
                  Console.WriteLine("Треугольник описывается числами, а не символами и буквами");
                  Environment.ExitCode = 3; //Символы вместо цифр
                  return;
                }
            }
            switch (IsTriangle(borders))//вывод через case по ключевым кодам
            {
                case 0:
                    Console.WriteLine("Не треугольник == 0");
                    break;
                case 1:
                    Console.WriteLine("Равносторонний треугольник == 1");
                    break;
                case 2:
                    Console.WriteLine("Равнобедренный треугольник == 2");
                    break;
                case 3:
                    Console.WriteLine("Разносторонний треугольник == 3");
                    break;
                default: 
                    Console.WriteLine("Сломано");
                    break;
            }
            
        }

        public static int IsTriangle(List<int> borders)
        {
            var a = borders[0];
            var b = borders[1];
            var c = borders[2];
            if ((a + b > c) && (b + c > a) && (a + c > b)) //треугольник?
            {
                if (a == b && b == c && a == c) return 1;//равносторонний!
                if (a == b || b == c || a == c) return 2;//равнобедренный!

                return 3;//разносторонний
            }
            return 0;
        }
    }
}