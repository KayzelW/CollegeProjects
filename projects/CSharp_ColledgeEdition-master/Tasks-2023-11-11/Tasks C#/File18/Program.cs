/*
File18. Дан файл вещественных чисел. Найти его первый локальный 
минимум (локальным минимумом называется элемент, который меньше своих 
соседей).

Капитонов Роман 11.11.2023 ~7 минут
*/

try
{
    var filePath = "doubles.txt";
    var numbers = File.ReadAllLines(filePath).Select(double.Parse).ToArray();
    
    var localMinimumIndex = FindLocalMinimumIndex(numbers);
    
    if (localMinimumIndex != -1)
    {
        var localMinimumValue = numbers[localMinimumIndex];
        Console.WriteLine($"Первый локальный минимум: {localMinimumValue}");
    }
    else
    {
        Console.WriteLine("Локальный минимум не найден.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Произошла ошибка: {ex.Message}");
}

static int FindLocalMinimumIndex(double[] numbers)
{
    for (var i = 1; i < numbers.Length - 1; i++)
    {
        if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1])
        {
            return i;
        }
    }

    return -1;
}