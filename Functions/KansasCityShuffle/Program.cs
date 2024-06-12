using System;
using System.Linq;

namespace KansasCityShuffle;

internal static class Program
{
    private static void Main()
    {
        TestIntArray();
        TestStringArray();
    }

    private static void TestIntArray()
    {
        int[] array = CreateArray(0);
        TestArray(array);
    }

    private static void TestStringArray()
    {
        string[] array = CreateArray("test");
        TestArray(array);
    }

    private static void TestArray<T>(T[] array)
    {
        PrintArray(array);
        Shuffle(array);
        PrintArray(array);
    }

    private static int[] CreateArray(int start, int count = 10) => Enumerable
        .Range(start, count)
        .ToArray();

    private static string[] CreateArray(string repeatingElement, int count = 10) => Enumerable
        .Repeat(repeatingElement, count)
        .Select((element, i) => $"{element} {i}")
        .ToArray();

    private static void Shuffle<T>(T[] array)
    {
        Random random = new();

        for (int i = 0; i < array.Length - 1; i++)
        {
            int j = random.Next(i + 1, array.Length);
            Swap(ref array[i], ref array[j]);
        }
    }

    private static void Swap<T>(ref T firstElement, ref T secondElement)
    {
        (firstElement, secondElement) = (secondElement, firstElement);
    }

    private static void PrintArray<T>(T[] array)
    {
        Console.Write($"Массив {typeof(T).Name}: ");

        foreach (T element in array)
            Console.Write($"{element} ");

        Console.WriteLine();
    }
}