/*
String18. Дана строка. Преобразовать в ней все строчные буквы (как 
латинские, так и русские) в прописные, а прописные — в строчные.

Капитонов Роман 11.11.2023 ~5 минут
*/

Console.Write("Введите строку: ");
var resultString = ToggleCase(Console.ReadLine());

Console.WriteLine($"Результат преобразования: {resultString}");

static string ToggleCase(string input)
{
    var charArray = input.ToCharArray();

    for (int i = 0; i < charArray.Length; i++)
    {
        if (char.IsUpper(charArray[i]))
        {
            charArray[i] = char.ToLower(charArray[i]);
        }
        else if (char.IsLower(charArray[i]))
        {
            charArray[i] = char.ToUpper(charArray[i]);
        }
    }

    return new string(charArray);
}
