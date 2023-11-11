/*
Matrix18. Дана матрица размера M * N и целое число K (1 <= K <= N). 
Найти сумму и произведение элементов K-го столбца данной матрицы.

Капитонов Роман 11.11.2023 ~5 минут
*/

Console.Write("Введите количество строк M: ");
int M = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов N: ");
int N = int.Parse(Console.ReadLine());

Console.Write("Введите номер столбца K (1 <= K <= N): ");
int K = int.Parse(Console.ReadLine());

if (K >= 1 && K <= N)
{
    int[,] matrix = new int[M, N];
    var random = new Random();

    for (var i = 0; i < M; i++)
    {
        for (var j = 0; j < N; j++)
        {
            matrix[i, j] = random.Next(1, 9);
        }
    }

    Console.WriteLine(@"Матрица:");
    PrintMatrix(matrix);

    var sum = 0;
    var result = 1;

    for (var i = 0; i < M; i++)
    {
        sum += matrix[i, K - 1];
        result *= matrix[i, K - 1];
    }

    Console.WriteLine($"\nСумма элементов {K}-го столбца: {sum}");
    Console.WriteLine($"Произведение элементов {K}-го столбца: {result}");
}
else
{
    Console.WriteLine("Некорректный номер столбца. Введите значение от 1 до N.");
}

static void PrintMatrix(int[,] matrix)
{
    var rows = matrix.GetLength(0);
    var columns = matrix.GetLength(1);

    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < columns; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}