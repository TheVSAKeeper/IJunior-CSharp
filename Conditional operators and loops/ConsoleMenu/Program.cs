namespace ConsoleMenu;

internal static class Program
{
    private static void Main()
    {
        const string ShowLoremCommand = "lorem";
        const string ShowCurrentDateCommand = "date";
        const string ShowRandomIntCommand = "random-int";
        const string ClearConsoleCommand = "clear";
        const string ExitCommand = "exit";

        string availableCommands = $"Доступные команды:\n"
                                   + $"{ShowLoremCommand} - Выводит РыбаТекст.\n"
                                   + $"{ShowCurrentDateCommand} - Выводит текущую дату.\n"
                                   + $"{ShowRandomIntCommand} - Выводит случайное целое число.\n"
                                   + $"{ClearConsoleCommand} - Очищает консоль.\n"
                                   + $"{ExitCommand} - Завершает работу программы.\n";

        Random random = new();

        bool isWorking = true;
        bool isShowCommands = true;

        while (isWorking)
        {
            if (isShowCommands)
            {
                isShowCommands = false;
                Console.WriteLine(availableCommands);
            }

            Console.Write("Введите команду из списка: ");
            string enteredCommand = Console.ReadLine() ?? string.Empty;

            switch (enteredCommand)
            {
                case ShowLoremCommand:
                    Console.WriteLine("С учётом сложившейся международной обстановки, "
                                      + "высокое качество позиционных исследований не оставляет шанса для как самодостаточных,"
                                      + " так и внешне зависимых концептуальных решений.");

                    break;

                case ShowCurrentDateCommand:
                    DateTime currentDateTime = DateTime.Now;
                    Console.WriteLine($"Нынче {currentDateTime:f}");
                    break;

                case ShowRandomIntCommand:
                    int randomInteger = random.Next();
                    Console.WriteLine($"Неотрицательное случайное целое число: {randomInteger}");
                    break;

                case ClearConsoleCommand:
                    isShowCommands = true;
                    Console.Clear();
                    break;

                case ExitCommand:
                    isWorking = false;
                    continue;

                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }
}