/*
For18. Дано вещественное число A и целое число N (> 0). 
Используя один цикл, найти значение выражения
1 - A + A**2 - A**3 + ... + (−1)**N*A**N.

Капитонов Роман 11.11.2023 ~4 минут
*/

Console.WriteLine("A: ");
var A = double.Parse(Console.ReadLine());
Console.WriteLine("N (> 0): ");
var N = int.Parse(Console.ReadLine());

double result = 0;

for (int i = 0; i <= N; i++)
{
    result += Math.Pow(-1, i) * Math.Pow(A, i);
}

Console.WriteLine($"Значение выражения: {result}");
