/*
If18. Даны три целых числа, одно из которых отлично от двух других, 
равных между собой. Определить порядковый номер числа, отличного от 
остальных.

Капитонов Роман 11.11.2023 ~3 минуты
*/

Console.Write("Введите первое целое число: ");
int num1 = int.Parse(Console.ReadLine());

Console.Write("Введите второе целое число: ");
int num2 = int.Parse(Console.ReadLine());

Console.Write("Введите третье целое число: ");
int num3 = int.Parse(Console.ReadLine());

if (num1 == num2 && num2 != num3)
{
    Console.WriteLine($"Третье число({num3}) отлично от остальных двух.");
}
else if (num1 == num3 && num2 != num1)
{
    Console.WriteLine($"Второе число({num2}) отлично от остальных двух.");
}
else if (num2 == num3 && num1 != num2)
{
    Console.WriteLine($"Первое число({num1}) отлично от остальных двух.");
}
else
{
    Console.WriteLine("Введены числа, не удовлетворяющие условиям задачи.");
}