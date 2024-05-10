namespace Images;

internal static class Program
{
    private static void Main()
    {
        int imagesInRow = 3;
        int imagesInAlbum = 52;

        int filledRows = imagesInAlbum / imagesInRow;
        int unusedImages = imagesInAlbum % imagesInRow;

        Console.WriteLine($"Заполненных рядов: {filledRows}\nКартинок сверх меры: {unusedImages}");
        Console.ReadKey();
    }
}