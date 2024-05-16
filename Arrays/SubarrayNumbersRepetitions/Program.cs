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

        int repeatingNumber = numbers[0];
        int repetitionsCount = 1;

        int maxRepeatingNumber = repeatingNumber;
        int maxRepetitionsCount = repetitionsCount;

        for (int i = 1; i < numbers.Length; i++)
        {
            int number = numbers[i];

            if (repeatingNumber == number)
            {
                repetitionsCount++;

                if (repetitionsCount > maxRepetitionsCount)
                {
                    maxRepetitionsCount = repetitionsCount;
                    maxRepeatingNumber = repeatingNumber;
                }
            }
            else
            {
                repeatingNumber = number;
                repetitionsCount = 1;
            }
        }

        Console.WriteLine($"Число {maxRepeatingNumber} повторяется наибольшее количество раз подряд.\n"
                          + $"Количество повторений — {maxRepetitionsCount}.");

        Console.ReadKey();
    }
}