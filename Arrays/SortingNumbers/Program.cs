using System;

namespace SortingNumbers;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minValue = 0;
        int maxValue = 99;

        int minSize = 10;
        int maxSize = 50;
        int size = random.Next(minSize, maxSize + 1);

        int[] numbers = new int[size];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = random.Next(minValue, maxValue + 1);

        string numbersContents = string.Join(" ", numbers);
        Console.WriteLine($"Несортированный массив: {numbersContents}");

        bool isElementsSwapped = true;

        for (int i = numbers.Length - 1; i > 0 && isElementsSwapped; i--)
        {
            isElementsSwapped = false;

            for (int j = 1; j <= i; j++)
            {
                if (numbers[j - 1] > numbers[j])
                {
                    isElementsSwapped = true;
                    (numbers[j - 1], numbers[j]) = (numbers[j], numbers[j - 1]);
                }
            }
        }

        numbersContents = string.Join(" ", numbers);
        Console.WriteLine($"Сортированный массив: {numbersContents}");

        Console.ReadKey();
    }
}