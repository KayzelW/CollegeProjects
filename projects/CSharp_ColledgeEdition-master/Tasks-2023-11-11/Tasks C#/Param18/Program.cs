/*
Param18. Описать процедуру Chessboard(M, N, A), формирующую по целым 
положительным числам M и N матрицу A размера M x N, которая содержит 
числа 0 и 1, расположенные в «шахматном» порядке, причем A[1,1] = 0. 
Двумерный целочисленный массив A является выходным параметром. С помощью 
этой процедуры по данным целым числам M и N сформировать матрицу A 
размера M x N.

Капитонов Роман 11.11.2023 ~8 минут
*/

Console.Write("Введите количество строк M: ");
var M = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов N: ");
var N = int.Parse(Console.ReadLine());

var chessboardMatrix = new int[M, N];

Chessboard(M, N, chessboardMatrix);

Console.WriteLine("\nСформированная матрица с \"шахматным\" порядком:");
PrintMatrix(chessboardMatrix);

static void Chessboard(int M, int N, int[,] A)
{
    for (var i = 0; i < M; i++)
    {
        for (var j = 0; j < N; j++)
        {
            // Число 1 будет стоять на клетках с четной суммой индексов
            // (i + j), начиная с A[0, 0], поэтому если (i + j) четное, A[i, j] = 1
            A[i, j] = (i + j) % 2 == 0 ? 1 : 0;
        }
    }
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