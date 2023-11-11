/*
Func18. Описать функцию RadToDeg(R) вещественного типа, находящую 
величину угла в градусах, если дана его величина R в радианах (R — 
вещественное число, 0 <= R < 2*pi). Воспользоваться следующим 
соотношением: 180градусов = pi радианов. В качестве значения pi 
использовать 3.14. С помощью функции RadToDeg перевести из радианов 
в градусы пять данных углов.

Капитонов Роман 11.11.2023 ~5 минут
*/

const double pi = 3.14;

Console.Write("Введите углы в радианах через пробел (0 <= угол < 2*pi): ");
var input = Console.ReadLine().Split(' ').ToList().ConvertAll(x => double.Parse(x));

Console.WriteLine("\nРезультаты в градусах:");

foreach (var item in input)
{
    var angleInDegrees = RadToDeg(item);
    Console.WriteLine($"{item} радиан = {angleInDegrees} градусов");
}

static double RadToDeg(double radians)
{
    return radians * (180.0 / pi);
}