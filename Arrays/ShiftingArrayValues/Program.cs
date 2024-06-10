using System;

namespace ShiftingArrayValues;

internal static class Program
{
    private static void Main()
    {
        Random random = new();
        int minValue = 0;
        int maxValue = 99;

        int size = 10;
        int[] numbers = new int[size];

        int defaultShiftsCount = 3;

        Console.Write($"Введите значение сдвига влево (по умолчанию {defaultShiftsCount}): ");
        string? requiredShifts = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(requiredShifts) || int.TryParse(requiredShifts, out int shiftsCount) == false)
            shiftsCount = defaultShiftsCount;

        shiftsCount %= numbers.Length;

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = random.Next(minValue, maxValue + 1);

        string numbersContents = string.Join(" ", numbers);
        Console.WriteLine($"До сдвига\n{numbersContents}");

        for (int i = 0; i < shiftsCount; i++)
        {
            for (int j = 0; j < numbers.Length - 1; j++)
            {
                (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
            }
        }

        numbersContents = string.Join(" ", numbers);
        Console.WriteLine($"После сдвига на {shiftsCount} влево\n{numbersContents}");

        Console.ReadKey();
    }
}