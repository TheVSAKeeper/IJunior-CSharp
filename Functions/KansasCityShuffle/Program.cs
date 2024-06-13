using System;
using System.Linq;

namespace KansasCityShuffle;

internal static class Program
{
    private static void Main()
    {
        RunShuffleTestingIntArray();
        RunShuffleTestingStringArray();
    }

    private static void RunShuffleTestingIntArray()
    {
        int start = 0;
        int[] array = CreateArray(start);
        RunArrayTesting(array);
    }

    private static void RunShuffleTestingStringArray()
    {
        string repeatingElement = "test";
        string[] array = CreateArray(repeatingElement);
        RunArrayTesting(array);
    }

    private static void RunArrayTesting<T>(T[] array)
    {
        PrintArray(array);
        Shuffle(array);
        PrintArray(array);
    }

    private static int[] CreateArray(int start, int count = 10) =>
        Enumerable.Range(start, count)
            .ToArray();

    private static string[] CreateArray(string repeatingElement, int count = 10) =>
        Enumerable.Repeat(repeatingElement, count)
            .Select((element, index) => $"{element} {index}")
            .ToArray();

    private static void Shuffle<T>(T[] array)
    {
        Random random = new();

        for (int i = 0; i < array.Length - 1; i++)
        {
            int j = random.Next(i + 1, array.Length);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    private static void PrintArray<T>(T[] array)
    {
        Console.Write($"Массив {typeof(T).Name}: ");

        foreach (T element in array)
            Console.Write($"{element} ");

        Console.WriteLine();
    }
}