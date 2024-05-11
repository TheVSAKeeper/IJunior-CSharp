namespace SwappingValues;

internal static class Program
{
    private static void Main()
    {
        string name = "Иванов";
        string surname = "Иван";

        Console.WriteLine($"До перестановки: {name} {surname}");
            
        (name, surname) = (surname, name);
            
        Console.WriteLine($"После перестановки: {name} {surname}");
        Console.ReadKey();
    }
}