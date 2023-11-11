/*
Case18. Дано целое число в диапазоне 100–999. Вывести 
строку-описание данного числа, например: 256 — «двести пятьдесят шесть», 
814 — «восемьсот четырнадцать».

Капитонов Роман 11.11.2023 ~8 минут
*/

Console.Write("Введите целое число в диапазоне 100-999: ");
int number = int.Parse(Console.ReadLine());

if (number < 100 || number > 999)
{
    Console.WriteLine("Число не находится в допустимом диапазоне.");
}
else
{
    string result = NumberToWords(number);
    Console.WriteLine($"{number} — \"{result}\"");
}

static string NumberToWords(int number)
{
    string[] firths = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
    string[] seconds = { "", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
    string[] tens = { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
    string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };

    var first = number % 10;
    var ten = (number % 100) / 10;
    var hundred = number / 100;

    string result = hundreds[hundred];
        
    if (ten == 1)
    {
        result += " " + seconds[first];
    }
    else
    {
        result += " " + tens[ten] + " " + firths[first];
    }

    return result.Trim();
}