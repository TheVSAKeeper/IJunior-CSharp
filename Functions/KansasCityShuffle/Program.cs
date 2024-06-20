using System;

namespace KansasCityShuffle;

internal static class Program
{
    private static void Main()
    {
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        PrintArray(array);
        Shuffle(array);
        PrintArray(array);
    }

    private static void Shuffle(int[] array)
    {
        Random random = new();

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = random.Next(i + 1, array.Length);
            (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }

    private static void PrintArray(int[] array)
    {
        Console.Write("Массив: ");

        foreach (int element in array)
            Console.Write($"{element} ");

        Console.WriteLine();
    }
}