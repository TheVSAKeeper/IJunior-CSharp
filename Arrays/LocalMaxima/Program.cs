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

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(minValue, maxValue + 1);
        }

        Console.Write($"{size} чисел: ");

        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }

        Console.Write("Локальные максимумы: ");

        if (numbers[firstElementIndex] > numbers[firstElementIndex + 1])
            Console.Write($"{numbers[firstElementIndex]} ");

        for (int i = 1; i < lastElementIndex; i++)
        {
            if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1])
                Console.Write($"{numbers[i]} ");
        }

        if (numbers[lastElementIndex] > numbers[lastElementIndex - 1])
            Console.Write($"{numbers[lastElementIndex]} ");

        Console.ReadLine();
    }
}