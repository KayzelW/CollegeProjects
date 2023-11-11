/*
Series18. Дано целое число N и набор из N целых чисел, упорядоченный 
по возрастанию. Данный набор может содержать одинаковые элементы. 
Вывести в том же порядке все различные элементы данного набора.

Капитонов Роман 11.11.2023 ~3 минуты
*/

Console.Write("Введите количество элементов N: ");
var N = int.Parse(Console.ReadLine());

var uniqueElements = new HashSet<int>();

Console.WriteLine("Введите упорядоченный по возрастанию набор из N целых чисел:");

for (var i = 0; i < N; i++)
{
    Console.Write($"Элемент {i + 1}: ");
    var element = int.Parse(Console.ReadLine());
    uniqueElements.Add(element);
}

Console.WriteLine("\nУникальные элементы данного набора:");
foreach (var uniqueElement in uniqueElements)
{
    Console.Write($"{uniqueElement} ");
}