/*
Begin18. Даны три точки A, B, C на числовой оси. Точка C расположена
между точками A и B. Найти произведение длин отрезков AC и BC.

Капитонов Роман 11.11.2023 ~6 минут
*/

using System.Drawing;

var pointA = ReadPoint("A");
var pointB = ReadPoint("B");
var pointC = ReadPoint("C");

var lengthAC = CalculateDistance(pointA, pointC);
var lengthBC = CalculateDistance(pointB, pointC);
var res = lengthAC * lengthBC;

Console.WriteLine($"Длина отрезка AC: {lengthAC}");
Console.WriteLine($"Длина отрезка BC: {lengthBC}");
Console.WriteLine($"Произведение длин отрезков AC и BC: {res}");

static Point ReadPoint(string pointName)
{
    Console.Write($"Введите координаты точки {pointName} (X Y): ");
    var input = Console.ReadLine().Split(' ');
    return new Point(int.Parse(input[0]), int.Parse(input[1]));
}

static int CalculateDistance(Point p1, Point p2)
{
    var deltaX = p2.X - p1.X;
    var deltaY = p2.Y - p1.Y;
    return (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
}
