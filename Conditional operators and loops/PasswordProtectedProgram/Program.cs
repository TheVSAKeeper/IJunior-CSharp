using System;

namespace PasswordProtectedProgram;

internal static class Program
{
    private static void Main()
    {
        string savedPassword = "qwe123";
        int numberOfAttempts = 3;

        for (int i = numberOfAttempts - 1; i >= 0; i--)
        {
            Console.Write("Введите пароль: ");
            string enteredPassword = Console.ReadLine() ?? string.Empty;

            if (savedPassword == enteredPassword)
            {
                Console.WriteLine("Секретное сообщение");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Неверный пароль! Оставшиеся попытки: {i} из {numberOfAttempts}.\n");
            }
        }
    }
}