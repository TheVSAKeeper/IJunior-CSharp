using System;

namespace DynamicArray;

internal static class Program
{
    private static void Main()
    {
        const string CommandSum = "sum";
        const string CommandExit = "exit";

        int[] numbers = [];

        bool isWorking = true;

        while (isWorking)
        {
            Console.Clear();

            string numbersContents = string.Join(" ", numbers);
            Console.WriteLine($"Содержимое массива ({numbers.Length} чисел: {numbersContents}");

            Console.Write($"Введите число, которое нужно добавить в массив, или команду {CommandSum} или {CommandExit}: ");
            string enteredCommand = Console.ReadLine() ?? string.Empty;

            switch (enteredCommand)
            {
                case CommandSum:
                    int sum = 0;

                    foreach (int number in numbers)
                        sum += number;

                    Console.WriteLine($"Сумма чисел в массиве — {sum}.");
                    break;

                case CommandExit:
                    isWorking = false;
                    continue;

                default:
                    if (int.TryParse(enteredCommand, out int userNumber) == false)
                    {
                        Console.WriteLine($"{enteredCommand} не является числом или допустимой командой.");
                        break;
                    }

                    int[] enlargedNumbers = new int[numbers.Length + 1];

                    for (int i = 0; i < numbers.Length; i++)
                        enlargedNumbers[i] = numbers[i];

                    enlargedNumbers[^1] = userNumber;
                    numbers = enlargedNumbers;

                    Console.WriteLine($"Число {userNumber} успешно добавлено в массив.");
                    break;
            }

            Console.ReadKey();
        }
    }
}