using System;

namespace SubarrayNumbersRepetitions;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int minValue = 0;
        int maxValue = 2;

        int size = 30;
        int[] numbers = new int[size];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = random.Next(minValue, maxValue + 1);

        string numbersContents = string.Join(" ", numbers);
        Console.WriteLine($"Массив: {numbersContents}");

        int repetitionsCount = 1;
        int maxRepeatingNumber = numbers.Length == 1 ? numbers[0] : 0;
        int maxRepetitionsCount = repetitionsCount;

        for (int i = 1; i < numbers.Length; i++)
        {
            repetitionsCount = numbers[i] == numbers[i - 1] ? repetitionsCount + 1 : 1;

            if (repetitionsCount > maxRepetitionsCount)
            {
                maxRepetitionsCount = repetitionsCount;
                maxRepeatingNumber = numbers[i];
            }
        }

        Console.WriteLine($"Число {maxRepeatingNumber} повторяется наибольшее количество раз подряд.\n"
                          + $"Количество повторений — {maxRepetitionsCount}.");

        Console.ReadKey();
    }
}