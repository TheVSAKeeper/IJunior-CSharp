using System;

namespace GreatestElement;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minValue = 1;
        int maxValue = 9;

        int maxElement = int.MinValue;
        int replacerNumber = 0;

        int rows = 10;
        int columns = 10;
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);

                if (maxElement < matrix[i, j])
                    maxElement = matrix[i, j];
            }
        }

        Console.WriteLine($"Максимальный элемент — {maxElement}.");

        Console.WriteLine("Исходная матрица");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Результирующая матрица\n"
                          + $"Максимальный элемент {maxElement} заменен на {replacerNumber}:");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == maxElement)
                    matrix[i, j] = replacerNumber;

                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}