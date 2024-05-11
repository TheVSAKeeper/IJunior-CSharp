using System;

namespace SumOfNumbers;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int maxNumber = 100;
        int number = random.Next(maxNumber + 1);

        int firstDivisor = 3;
        int secondDivisor = 5;

        int sum = 0;

        Console.Write("Числа: ");

        for (int i = 0; i <= number; i++)
        {
            if (i % firstDivisor == 0 || i % secondDivisor == 0)
            {
                Console.Write($"{i} ");
                sum += i;
            }
        }

        Console.WriteLine($"\nСумма всех положительных чисел меньше {number} (включая число),\n"
                          + $"которые кратные {firstDivisor} или {secondDivisor} равна {sum}.");
    }
}