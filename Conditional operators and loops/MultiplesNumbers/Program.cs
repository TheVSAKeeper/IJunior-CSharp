using System;

namespace MultiplesNumbers;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minMultipleValue = 10;
        int maxMultipleValue = 25;
        int multipleValue = random.Next(minMultipleValue, maxMultipleValue + 1);

        int minNumber = 50;
        int maxNumber = 150;

        int multiplesCount = 0;

        for (int i = multipleValue; i <= maxNumber; i += multipleValue)
        {
            if (i >= minNumber)
                multiplesCount++;
        }

        Console.WriteLine($"For: Количество кратных {multipleValue} в диапазоне от {minNumber} до {maxNumber}: {multiplesCount}");

        int initialValue = multipleValue;

        while (initialValue <= minNumber)
        {
            initialValue += multipleValue;
        }

        int multiplesCountForWhile = 0;

        while (initialValue <= maxNumber)
        {
            initialValue += multipleValue;
            multiplesCountForWhile++;
        }

        Console.WriteLine($"While: Количество кратных {multipleValue} в диапазоне от {minNumber} до {maxNumber}: {multiplesCountForWhile}");
        Console.ReadKey();
    }
}