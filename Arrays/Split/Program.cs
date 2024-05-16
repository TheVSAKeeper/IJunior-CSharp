using System;
using System.Text.RegularExpressions;

namespace Split;

internal static class Program
{
    private static void Main()
    {
        string text = "Цена вопроса не важна, когда обереги никого не защитили! "
                      + "Но разбавленное изрядной долей эмпатии, рациональное мышление позволяет выполнить важные задания "
                      + "по разработке соответствующих условий активизации. Банальные, но неопровержимые выводы, "
                      + "а также сторонники тоталитаризма в науке, вне зависимости от их уровня, должны быть заблокированы "
                      + "в рамках своих собственных рациональных ограничений.";

        string[] wordSeparators = [" "];
        string[] words = text.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

        Regex regex = new(@"\w*");

        for (int i = 0; i < words.Length; i++)
            words[i] = regex.Match(words[i]).Value;

        string cleanedWords = string.Join("\n", words);
        Console.WriteLine(cleanedWords);

        regex = new Regex(@"\w\w*");
        MatchCollection matches = regex.Matches(text);

        cleanedWords = string.Join("\n", matches);
        Console.WriteLine($"\n{cleanedWords}");

        Console.ReadKey();
    }
}