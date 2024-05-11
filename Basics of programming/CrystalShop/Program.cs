namespace CrystalShop;

internal static class Program
{
    private static void Main()
    {
        int crystalPrice = 10;

        Console.Write("Введите количество золота: ");
        int.TryParse(Console.ReadLine(), out int goldInWallet);

        Console.Write($"Один кристалл стоит {crystalPrice}.\n"
                      + $"Введите количество кристаллов для покупки: ");

        int.TryParse(Console.ReadLine(), out int crystalsToBuy);

        int purchaseAmount = crystalsToBuy * crystalPrice;
        goldInWallet -= purchaseAmount;

        Console.WriteLine($"Кошелек\n"
                          + $"Золото: {goldInWallet}\n"
                          + $"Кристаллы: {crystalsToBuy}");

        Console.ReadKey();
    }
}