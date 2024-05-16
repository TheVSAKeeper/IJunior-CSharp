using System;

namespace DegreeOfTwo;

internal static class Program
{
    private static void Main()
    {
        Random random = new();

        int maxNumber = 10000;
        int number = random.Next(maxNumber);

        int minExponent = 1;
        int baseForExponentiation = 2;
        int exceedingNumber = baseForExponentiation;

        if (number == 0)
        {
            minExponent = 0;
            exceedingNumber = 1;
        }

        while (exceedingNumber <= number)
        {
            minExponent++;
            exceedingNumber *= baseForExponentiation;
        }

        Console.WriteLine($"{number} < {exceedingNumber} = {baseForExponentiation}^{minExponent}");
        Console.ReadKey();
    }
}