namespace NameOutput;

internal static class Program
{
    private static void Main()
    {
        string defaultName = "Анонимный";
        char defaultBorderSymbol = '%';

        Console.Write($"Введите ваше имя (по умолчанию {defaultName}): ");
        string? requiredName = Console.ReadLine();

        string name = string.IsNullOrWhiteSpace(requiredName) ? defaultName : requiredName.Trim();

        Console.Write($"Введите символ границы (по умолчанию {defaultBorderSymbol}): ");
        string? requiredBorderSymbol = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(requiredBorderSymbol) || char.TryParse(requiredBorderSymbol.Trim(), out char borderSymbol) == false)
            borderSymbol = defaultBorderSymbol;
        
        string nameLine = $"{borderSymbol}{name}{borderSymbol}";
        string frame = new(borderSymbol, nameLine.Length);

        string nameInFrame = $"{frame}\n"
                             + nameLine
                             + $"\n{frame}";

        Console.WriteLine(nameInFrame);
        Console.ReadKey();
    }
}