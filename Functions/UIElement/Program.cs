using System;

namespace UIElement;

internal static class Program
{
    public static void Main()
    {
        DrawBar(0.6f, 10, 0, 0, ConsoleColor.Red, "Health");
        DrawBar(0.4f, 10, 0, 2, ConsoleColor.Blue, "Mana");
    }

    private static void DrawBar(float percent, int length, int left, int top, ConsoleColor color, string label)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        char filledCharacter = '#';
        char emptyCharacter = '_';

        int filledLength = CalculateFilledLength(percent, length);
        int emptyLength = length - filledLength;

        SetCursorPosition(left, top);
        Console.Write("[");

        DrawBarPart(filledCharacter, filledLength, color);
        DrawBarPart(emptyCharacter, emptyLength, originalColor);

        Console.Write($"] : {label}");
        ResetCursorPosition();
    }

    private static int CalculateFilledLength(float percent, int length) => (int)Math.Round(percent * length);

    private static void DrawBarPart(char character, int length, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        string barPart = new(character, length);
        Console.Write(barPart);
    }

    private static void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }

    private static void ResetCursorPosition()
    {
        Console.SetCursorPosition(0, 0);
    }
}