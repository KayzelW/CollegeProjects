/*
Proc12. Описать процедуру SortInc3(A, B, C), меняющую содержимое 
переменных A, B, C таким образом, чтобы их значения оказались 
упорядоченными по возрастанию (A, B, C — вещественные параметры, 
являющиеся одновременно входными и выходными). С помощью этой процедуры 
упорядочить по возрастанию два данных набора из трех чисел: (A1, B1, C1) 
и (A2, B2, C2).

Капитонов Роман 11.11.2023 ~10 минут
*/

Console.WriteLine("Введите три числа для первого набора:");
var A1 = double.Parse(Console.ReadLine());
var B1 = double.Parse(Console.ReadLine());
var C1 = double.Parse(Console.ReadLine());

Console.WriteLine("\nВведите три числа для второго набора:");
var A2 = double.Parse(Console.ReadLine());
var B2 = double.Parse(Console.ReadLine());
var C2 = double.Parse(Console.ReadLine());

SortInc3(ref A1, ref B1, ref C1);
SortInc3(ref A2, ref B2, ref C2);

Console.WriteLine($"\nПервый набор после сортировки: {A1}, {B1}, {C1}");
Console.WriteLine($"Второй набор после сортировки: {A2}, {B2}, {C2}");

static void SortInc3(ref double A, ref double B, ref double C)
{
    if (A > B)
    {
        Swap(ref A, ref B);
    }

    if (B > C)
    {
        Swap(ref B, ref C);
    }

    if (A > B)
    {
        Swap(ref A, ref B);
    }
}

static void Swap(ref double x, ref double y)
{
    var temp = x;
    x = y;
    y = temp;
}