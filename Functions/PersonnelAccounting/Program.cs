using System;

namespace PersonnelAccounting;

internal static class Program
{
    private static void Main()
    {
        string[] fullNames = [];
        string[] positions = [];

        RunAccounting(ref fullNames, ref positions);
        ShowAllEmployees(fullNames, positions);
    }

    private static void RunAccounting(ref string[] fullNames, ref string[] positions)
    {
        const string CommandAddEmployee = "add";
        const string CommandShowAll = "show-all";
        const string CommandRemove = "remove";
        const string CommandSearch = "search";
        const string CommandFill = "fill";
        const string CommandExit = "exit";

        string availableCommands = $"""
                                    
                                       {CommandAddEmployee} - добавить досье
                                       {CommandShowAll} - вывести все досье
                                       {CommandRemove} - удалить досье
                                       {CommandSearch} - поиск по фамилии
                                       {CommandFill} - добавить случайные досье
                                       {CommandExit} - выход
                                    """;

        bool isWorking = true;

        while (isWorking)
        {
            ShowMessage("Список доступных команд:");
            ShowMessage(availableCommands);

            ShowMessage("\nВведите команду: ");
            string? enteredCommand = Console.ReadLine()?.Trim();

            Console.Clear();

            switch (enteredCommand)
            {
                case CommandAddEmployee:
                    AddEmployee(ref fullNames, ref positions);
                    break;

                case CommandShowAll:
                    ShowAllEmployees(fullNames, positions);
                    break;

                case CommandRemove:
                    RemoveEmployee(ref fullNames, ref positions);
                    break;

                case CommandSearch:
                    SearchEmployeeBySurname(fullNames, positions);
                    break;

                case CommandFill:
                    Fill(ref fullNames, ref positions);
                    break;

                case CommandExit:
                    isWorking = false;
                    break;

                default:
                    ShowMessage("Неверная команда", MessageType.Error);
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void AddEmployee(ref string[] fullNames, ref string[] positions)
    {
        string employeeFormat = "ФИО - Должность";

        ShowMessage($"Введите нового сотрудника ({employeeFormat}):");
        string newEmployee = Console.ReadLine()?.Trim() ?? string.Empty;

        if (TryAddEmployee(ref fullNames, ref positions, newEmployee) == false)
        {
            ShowMessage($"Сотрудник {newEmployee} не добавлен. Формат сотрудника должен быть {employeeFormat}.", MessageType.Error);
            return;
        }

        ShowMessage($"Новый сотрудник {newEmployee} успешно добавлен.", MessageType.Successful);
    }

    private static void ShowAllEmployees(string[] fullNames, string[] positions)
    {
        for (int i = 0; i < fullNames.Length && i < positions.Length; i++)
            ShowEmployee(i + 1, fullNames[i], positions[i]);
    }

    private static void ShowEmployee(int number, string fullName, string position)
    {
        ShowMessage($"\n{number}) {fullName} - {position}");
    }

    private static void RemoveEmployee(ref string[] fullNames, ref string[] positions)
    {
        ShowAllEmployees(fullNames, positions);

        int numberToRemove = ReadInteger("\nВведите номер сотрудника, которого нужно удалить: ");

        bool isRemoveSuccessful = TryRemoveAt(ref fullNames, numberToRemove - 1)
                                  && TryRemoveAt(ref positions, numberToRemove - 1);

        if (isRemoveSuccessful == false)
        {
            ShowMessage($"Сотрудник #{numberToRemove} не существует.", MessageType.Warning);
            return;
        }

        ShowMessage($"Удаление сотрудника #{numberToRemove} прошло успешно.", MessageType.Successful);
    }

    private static void SearchEmployeeBySurname(string[] fullNames, string[] positions)
    {
        ShowMessage("Введите фамилию: ");
        string surname = Console.ReadLine()?.Trim() ?? string.Empty;

        int index = FindIndexOf(fullNames, surname);

        if (index == -1)
        {
            ShowMessage($"Сотрудник с фамилией {surname} не найден.", MessageType.Warning);
            return;
        }

        ShowEmployee(index + 1, fullNames[index], positions[index]);
    }

    private static void Fill(ref string[] fullNames, ref string[] positions)
    {
        if (TryFill(ref fullNames, ref positions) == false)
        {
            ShowMessage("Заполнение списка сотрудников временно не работает.", MessageType.Warning);
            return;
        }

        ShowMessage("Список сотрудников успешно заполнен.", MessageType.Successful);
    }

    private static bool TryFill(ref string[] fullNames, ref string[] positions)
    {
        string[] employees =
        [
            "Мясников Владлен Демьянович - Топограф",
            "Антонов Артур Давидович - Финансист",
            "Цветков Кондрат Семёнович - Киномеханик",
            "Никитин Арсен Львович - Робототехник"
        ];

        foreach (string employee in employees)
        {
            if (TryAddEmployee(ref fullNames, ref positions, employee) == false)
                return false;
        }

        return true;
    }

    private static int ReadInteger(string userPrompt = "Введите число: ")
    {
        int number;
        bool isNotNumber;

        do
        {
            Console.Write(userPrompt);
            string? enteredNumber = Console.ReadLine();

            isNotNumber = int.TryParse(enteredNumber, out number) == false;

            if (isNotNumber)
                Console.WriteLine($"{enteredNumber} не является числом.");
        } while (isNotNumber);

        return number;
    }

    private static bool TryRemoveAt(ref string[] array, int index)
    {
        if (index < 0 || index >= array.Length)
            return false;

        string[] newArray = new string[array.Length - 1];

        for (int i = 0; i < array.Length; i++)
        {
            if (i < index)
                newArray[i] = array[i];
            else if (i > index)
                newArray[i - 1] = array[i];
        }

        array = newArray;
        return true;
    }

    private static int FindIndexOf(string[] fullNames, string surname)
    {
        for (int i = 0; i < fullNames.Length; i++)
        {
            string[] employeeData = fullNames[i].Split([" "], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (string.Equals(employeeData[0], surname, StringComparison.InvariantCultureIgnoreCase))
                return i;
        }

        return -1;
    }

    private static bool TryAddEmployee(ref string[] fullNames, ref string[] positions, string employee)
    {
        string[] employeeData = employee.Split(["-"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (employeeData.Length != 2)
            return false;

        string fullName = employeeData[0].Trim();
        string position = employeeData[1].Trim();

        fullNames = AddEnd(fullNames, fullName);
        positions = AddEnd(positions, position);

        return true;
    }

    private static string[] AddEnd(string[] array, string element)
    {
        string[] newArray = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
            newArray[i] = array[i];

        newArray[^1] = element;
        return newArray;
    }

    private static void ShowMessage(string message, MessageType type = MessageType.Common)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        ConsoleColor selectedColor = (ConsoleColor)type;

        Console.ForegroundColor = selectedColor;
        Console.Write(message);
        Console.ForegroundColor = defaultColor;
    }
}

internal enum MessageType
{
    Common = ConsoleColor.Gray,
    Successful = ConsoleColor.Green,
    Warning = ConsoleColor.Yellow,
    Error = ConsoleColor.Red
}