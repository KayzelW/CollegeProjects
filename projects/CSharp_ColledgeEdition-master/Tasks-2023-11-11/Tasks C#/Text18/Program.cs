/*
Text18. Дано целое число K и текстовый файл. Удалить из каждой строки 
файла первые K символов (если длина строки меньше K, то удалить из нее 
все символы).

Капитонов Роман 11.11.2023 ~11 минут
*/

Console.Write("Введите путь к текстовому файлу(не относительный): ");
var filePath = Console.ReadLine();

Console.Write("Введите значение K: ");
var K = int.Parse(Console.ReadLine());

try
{
    RemoveFirstKCharacters(filePath, K);
    Console.WriteLine("Преобразование завершено успешно.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}


static void RemoveFirstKCharacters(string filePath, int K)
{
    var tempFilePath = Path.GetTempFileName();
    using (var reader = new StreamReader(filePath))
    using (var writer = new StreamWriter(tempFilePath))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line.Length >= K)
            {
                line = line.Substring(K);
            }
            else
            {
                line = string.Empty;
            }

            writer.WriteLine(line);
        }
    }

    // Заменяем исходный файл обработанным
    File.Delete(filePath);
    File.Move(tempFilePath, filePath);
}