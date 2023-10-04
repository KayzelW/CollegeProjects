using System;
using System.Collections.Generic;
using System.Linq;

namespace mdk01._02_2
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

                    if (x <= 0)
                    {
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
            /*
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
            */
            switch (triangleFormat(borders))
            {
                case 0:
                    Console.WriteLine("Не треугольник == 0");
                    break;
                case 1:
                    Console.WriteLine("Тупоугольный треугольник == 1");
                    break;
                case 2:
                    Console.WriteLine("Остроугольный треугольник == 2");
                    break;
                case 3:
                    Console.WriteLine("Прямоугольный треугольник == 3");
                    break;
                default:
                    Console.WriteLine("Не треугольник");
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

        public static int triangleFormat(List<int> borders)
        {
            if (IsTriangle(borders) != 0)
            {
                var c = borders.Max(x => x);
                borders.Remove(c);
                var a = borders[0];
                var b = borders[1];

                if(c*c > (a * a + b * b)) return 1; //Тупоугольный
                if(c*c < (a * a + b * b)) return 2; //Остроугольный
                if(c*c == (a * a + b * b)) return 3; //Прямоугольный
            }
            else return 0;
            return -1;
        }

    }
}

/*
Задание 3. Разработать программу.
Даны длины сторон треугольника, определить вид треугольника и его площадь. Выполнить контроль вводимых чисел.
1.	Остроугольный треугольник
2.	Тупоугольный треугольник
3.	Прямоугольный треугольник
Ограничения:
- три числа не могут быть определены как стороны треугольника;
- если хотя бы одно из них меньше или равно 0;
- сумма двух из них меньше третьего.
Подготовить набор тестовых вариантов для обнаружения ошибок в программе и оформить результат.

*/