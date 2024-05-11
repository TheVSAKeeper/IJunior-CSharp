namespace ExitControl;

internal static class Program
{
    private static void Main()
    {
        const string ExitCommand = "exit";

        string? inputMessage;

        do
        {
            Console.WriteLine("Введите {0} для выхода из программы.", ExitCommand);
            inputMessage = Console.ReadLine()?.ToLower();
        } while (inputMessage != ExitCommand);
    }
}