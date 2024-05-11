namespace Sequence;

internal static class Program
{
    private static void Main()
    {
        int startValue = 5;
        int endValue = 103;
        int step = 7;

        for (int i = startValue; i <= endValue; i += step)
            Console.Write($"{i} ");

        Console.ReadKey();
    }
}