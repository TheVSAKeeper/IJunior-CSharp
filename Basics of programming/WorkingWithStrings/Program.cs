namespace WorkingWithStrings;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Как вас зовут?");
        string userName = Console.ReadLine()!;

        Console.WriteLine("Сколько вам лет?");
        int userAge = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Какой ваш знак зодиака?");
        string userZodiacSign = Console.ReadLine()!;

        Console.WriteLine("Кем Вы работаете?");
        string userProfession = Console.ReadLine()!;

        Console.WriteLine($"Вас зовут {userName}, Вам {userAge}, Ваш знак зодиака {userZodiacSign}, Вы работаете {userProfession}.");
        Console.ReadKey();
    }
}