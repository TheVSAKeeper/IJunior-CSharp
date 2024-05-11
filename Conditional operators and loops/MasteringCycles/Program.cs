namespace MasteringCycles;

internal static class Program
{
    private static void Main()
    {
        int defaultRepeatCount = 1;

        Console.Write($"Введите число повторений (по умолчанию {defaultRepeatCount}): ");
        string? requiredRepeat = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(requiredRepeat) || int.TryParse(requiredRepeat, out int repeatCount) == false)
            repeatCount = defaultRepeatCount;

        Console.Write("Введите сообщение для повторения: ");
        string repeatableMessage = Console.ReadLine() ?? string.Empty;

        for (int i = 0; i < repeatCount; i++)
            Console.WriteLine(repeatableMessage);

        Console.ReadKey();
    }
}