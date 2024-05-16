using System;

namespace ParenthesisExpression;

internal static class Program
{
    private static void Main()
    {
        const char IncreaseNestingCommand = '(';
        const char DecreaseNestingCommand = ')';

        string testExpression = "(()((()))";

        int nestingDepth = 0;
        int maxNestingDepth = 0;
        bool isCorrectBracketsExpression = true;

        for (int i = 0; i < testExpression.Length && isCorrectBracketsExpression; i++)
        {
            char symbol = testExpression[i];

            switch (symbol)
            {
                case IncreaseNestingCommand:
                {
                    nestingDepth++;

                    if (nestingDepth > maxNestingDepth)
                        maxNestingDepth = nestingDepth;

                    break;
                }

                case DecreaseNestingCommand:
                {
                    nestingDepth--;

                    if (nestingDepth < 0)
                    {
                        isCorrectBracketsExpression = false;
                        Console.WriteLine("Открывающаяся скобка отсутствует.");
                    }

                    break;
                }
            }
        }

        if (isCorrectBracketsExpression && nestingDepth > 0)
        {
            isCorrectBracketsExpression = false;
            Console.WriteLine("Закрывающаяся скобка отсутствует.");
        }

        if (isCorrectBracketsExpression)
        {
            Console.WriteLine($"{testExpression} — правильное скобочное выражение.");
            Console.WriteLine($"Максимальная глубина вложения скобок: {maxNestingDepth}.");
        }
        else
        {
            Console.WriteLine($"{testExpression} — неверное скобочное выражение.");
        }

        Console.ReadKey();
    }
}