using System;
using System.Globalization;

namespace ReadInt;

internal static class Program
{
    private static void Main()
    {
        int number = ReadInteger();
        Console.WriteLine($"Ведено число: {number}");

        number = Read<int>();
        Console.WriteLine($"Ведено число: {number}");
    }

    private static int ReadInteger()
    {
        int number;
        bool isNotNumber;

        do
        {
            Console.Write("Введите число: ");
            string? enteredNumber = Console.ReadLine();

            isNotNumber = int.TryParse(enteredNumber, out number) == false;

            if (isNotNumber)
                Console.WriteLine($"{enteredNumber} не является числом.");
        } while (isNotNumber);

        return number;
    }

    private static T Read<T>() where T : IParsable<T>
    {
        string type = typeof(T).Name;
        T? value = default;
        bool isNotValid;

        do
        {
            Console.Write($"Введите {type}: ");
            string? enteredValue = Console.ReadLine();

            isNotValid = T.TryParse(enteredValue, CultureInfo.InvariantCulture, out T? parsedValue) == false;

            if (parsedValue != null)
                value = parsedValue;

            if (isNotValid)
                Console.WriteLine($"{enteredValue} не является {type}.");
        } while (isNotValid);

        return value!;
    }
}