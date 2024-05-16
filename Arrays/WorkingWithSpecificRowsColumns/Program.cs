using System;

namespace WorkingWithSpecificRowsColumns;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minValue = 1;
        int maxValue = 9;
        int maxSize = 10;

        int sum = 0;
        int sumRow = 2;
        int rows = random.Next(sumRow, maxSize + 1);

        int product = 1;
        int productColumn = 1;
        int columns = random.Next(productColumn, maxSize + 1);

        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[sumRow - 1, j];
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            product *= matrix[i, productColumn - 1];
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"\nСумма строки {sumRow}: {sum}");
        Console.WriteLine($"Произведение столбца {productColumn}: {product}");

        Console.ReadKey();
    }
}