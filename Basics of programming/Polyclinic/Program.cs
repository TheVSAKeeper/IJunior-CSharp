namespace Polyclinic;

internal static class Program
{
    private static void Main()
    {
        int receptionTimeInMinutes = 10;
        int minutesPerHour = 60;

        Console.Write("Введите количество человек перед вами: ");
        int.TryParse(Console.ReadLine(), out int peopleInQueue);

        int totalWaitingTimeInMinutes = peopleInQueue * receptionTimeInMinutes;
        int waitingHours = totalWaitingTimeInMinutes / minutesPerHour;
        int waitingMinutes = totalWaitingTimeInMinutes % minutesPerHour;

        Console.WriteLine($"Вам нужно отстоять в очереди {waitingHours}:{waitingMinutes}.");
        Console.ReadKey();
    }
}