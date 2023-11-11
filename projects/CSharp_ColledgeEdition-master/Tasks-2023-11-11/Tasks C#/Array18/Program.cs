/*
Array18. Дан массив A ненулевых целых чисел размера 10. Вывести 
значение первого из тех его элементов AK, которые удовлетворяют 
неравенству AK < A10. Если таких элементов нет, то вывести 0.

Капитонов Роман 11.11.2023 ~7 минут
*/

var input = Console.ReadLine().Split().ToList().ConvertAll(x => int.Parse(x));
if (input.Count >= 10)
    Console.WriteLine(input.Select(x => x < input[9]? x : 0).FirstOrDefault());
Console.ReadKey();
