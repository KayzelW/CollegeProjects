/*
Boolean18. Проверить истинность высказывания: «Среди трех данных 
целых чисел есть хотя бы одна пара совпадающих».

Капитонов Роман 11.11.2023 ~2 минуты
*/

Console.Write("Введите первое целое число: ");
var num1 = int.Parse(Console.ReadLine());
Console.Write("Введите второе целое число: ");
var num2 = int.Parse(Console.ReadLine());
Console.Write("Введите третье целое число: ");
var num3 = int.Parse(Console.ReadLine());

var hasMatchingPair = num1 == num2 || num1 == num3 || num2 == num3;
Console.WriteLine($"Среди трех данных целых чисел есть хотя бы одна пара совпадающих: {hasMatchingPair}");