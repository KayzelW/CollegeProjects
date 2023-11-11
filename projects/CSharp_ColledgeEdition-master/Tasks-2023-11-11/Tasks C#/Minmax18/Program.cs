/*
Minmax18. Дано целое число N и набор из N целых чисел. Найти 
количество элементов, содержащихся между первым и последним максимальным 
элементом. Если в наборе имеется единственный максимальный элемент, то 
вывести 0.

Капитонов Роман 11.11.2023 ~4 минуты
*/

Console.Write("Введите количество элементов N: ");
var N = int.Parse(Console.ReadLine());

Console.WriteLine("Введите набор из N целых чисел(в строку):");
var numbers = Console.ReadLine().Split().ToList().ConvertAll(x => int.Parse(x));

var max = numbers.Max();
var firstMaxIndex = -1;
var lastMaxIndex = -1;

if (numbers.Select(x => x == max).Count() < 2)
    Console.WriteLine("В наборе 1 максимальный элемент.");

for (int i = 0; i < N; i++)
{
    if (numbers[i] == max)
    {
        if (firstMaxIndex == -1)
        {
            firstMaxIndex = i;
        }

        lastMaxIndex = i;
    }
}

var countBetweenMax = lastMaxIndex - firstMaxIndex - 1;
Console.WriteLine($"Между 1 и последним максимальным элементом: {countBetweenMax}");