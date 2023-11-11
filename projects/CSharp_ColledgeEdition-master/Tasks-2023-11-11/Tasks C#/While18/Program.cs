/*
While18. Дано целое число N (> 0). Используя операции деления нацело 
и взятия остатка от деления, найти количество и сумму его цифр.

Капитонов Роман 11.11.2023 ~15 минут
*/

Console.Write("Введите целое число N (> 0): ");
var N = int.Parse(Console.ReadLine());

var countOfDigits = CountDigits(N);
var sumOfDigits = SumDigits(N);

Console.WriteLine($"Количество цифр: {countOfDigits}");
Console.WriteLine($"Сумма цифр: {sumOfDigits}");


static int CountDigits(int num)
{
    var count = 0;

    while (num > 0)
    {
        num /= 10;
        count++;
    }

    return count;
}

static int SumDigits(int num)
{
    int sum = 0;

    while (num > 0)
    {
        sum += num % 10;
        num /= 10;
    }

    return sum;
}