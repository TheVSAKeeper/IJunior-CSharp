using System;

namespace LocalMaxima;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minValue = 0;
        int maxValue = 99;

        int size = 30;
        int[] numbers = new int[size];

        int firstElementIndex = 0;
        int lastElementIndex = numbers.Length - 1;

        string format = new('0', maxValue.ToString().Length);

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(minValue, maxValue + 1);
        }

        Console.WriteLine($"{size} чисел: ");

        foreach (int number in numbers)
        {
            Console.Write($"{number.ToString(format)} ");
        }

        Console.WriteLine("\nЛокальные максимумы: ");

        char replacerCharacter = '-';
        string numberReplacer = new(replacerCharacter, format.Length);

        bool isLocalMaxima = numbers[firstElementIndex] > numbers[firstElementIndex + 1];
        string localMaxima = isLocalMaxima ? numbers[firstElementIndex].ToString(format) : numberReplacer;
        Console.Write($"{localMaxima} ");

        for (int i = 1; i < lastElementIndex; i++)
        {
            isLocalMaxima = numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1];
            localMaxima = isLocalMaxima ? numbers[i].ToString(format) : numberReplacer;
            Console.Write($"{localMaxima} ");
        }

        isLocalMaxima = numbers[lastElementIndex] > numbers[lastElementIndex - 1];
        localMaxima = isLocalMaxima ? numbers[lastElementIndex].ToString(format) : numberReplacer;
        Console.Write($"{localMaxima} ");

        Console.ReadKey();
    }
}