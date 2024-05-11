namespace CurrencyConverter;

internal static class Program
{
    private static void Main()
    {
        const string Rubles = "RUB";
        const string Dollars = "USD";
        const string Euro = "EUR";

        const string CurrencyNotFoundError = "Валюта {0} не найдена.";
        const string NotEnoughCurrencyError = "На балансе недостаточно средств {0}.";
        const string AvailableForConversion = "Доступно для конвертации {0} {1}.";
        const string SumForConversionRequest = "Часть баланса для конвертации: ";
        const string ConvertToRequest = "Перевести в ";

        double dollarPriceInRubles = 98.0;
        double euroPriceInRubles = 102.0;
        double dollarPriceInEuros = 1.1;

        double rublePriceInDollars = 1 / dollarPriceInRubles;
        double rublePriceInEuros = 1 / euroPriceInRubles;
        double euroPriceInDollars = 1 / dollarPriceInEuros;

        double balanceInRubles = 100.1;
        double balanceInDollars = 100.2;
        double balanceInEuros = 500.1;

        bool isWorking = true;

        while (isWorking)
        {
            Console.Clear();

            Console.WriteLine($"Рублей ({Rubles}): {balanceInRubles}\n"
                              + $"Долларов ({Dollars}): {balanceInDollars}\n"
                              + $"Евро ({Euro}): {balanceInEuros}\n");

            Console.Write("Конвертировать из ");
            string fromBalance = Console.ReadLine()?.ToUpper() ?? string.Empty;

            string toBalance;
            double partOfBalanceForConversion;

            switch (fromBalance)
            {
                case Euro:
                    Console.WriteLine(AvailableForConversion, balanceInEuros, fromBalance);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInEuros)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, fromBalance);
                        break;
                    }

                    Console.Write(ConvertToRequest);
                    toBalance = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    if (toBalance == Dollars)
                    {
                        balanceInDollars += partOfBalanceForConversion * euroPriceInDollars;
                    }
                    else if (toBalance == Rubles)
                    {
                        balanceInRubles += partOfBalanceForConversion * euroPriceInRubles;
                    }
                    else
                    {
                        Console.WriteLine(CurrencyNotFoundError, fromBalance);
                        break;
                    }

                    balanceInEuros -= partOfBalanceForConversion;
                    break;

                case Dollars:
                    Console.WriteLine(AvailableForConversion, balanceInDollars, fromBalance);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInDollars)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, fromBalance);
                        break;
                    }

                    Console.Write(ConvertToRequest);
                    toBalance = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    if (toBalance == Euro)
                    {
                        balanceInEuros += partOfBalanceForConversion * dollarPriceInEuros;
                    }
                    else if (toBalance == Rubles)
                    {
                        balanceInRubles += partOfBalanceForConversion * dollarPriceInRubles;
                    }
                    else
                    {
                        Console.WriteLine(CurrencyNotFoundError, toBalance);
                        break;
                    }

                    balanceInDollars -= partOfBalanceForConversion;
                    break;

                case Rubles:
                    Console.WriteLine(AvailableForConversion, balanceInRubles, fromBalance);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInRubles)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, fromBalance);
                        break;
                    }

                    Console.Write(ConvertToRequest);
                    toBalance = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    if (toBalance == Dollars)
                    {
                        balanceInDollars += partOfBalanceForConversion * rublePriceInDollars;
                    }
                    else if (toBalance == Euro)
                    {
                        balanceInEuros += partOfBalanceForConversion * rublePriceInEuros;
                    }
                    else
                    {
                        Console.WriteLine(CurrencyNotFoundError, fromBalance);
                        break;
                    }

                    balanceInRubles -= partOfBalanceForConversion;
                    break;

                default:
                    Console.WriteLine(NotEnoughCurrencyError, fromBalance);
                    break;
            }

            Console.WriteLine($"Рублей: {balanceInRubles}\n"
                              + $"Долларов: {balanceInDollars}\n"
                              + $"Евро: {balanceInEuros}\n");

            Console.WriteLine("Нажмите ESC, чтобы выйти, или любую клавишу, чтобы продолжить.");
            isWorking = Console.ReadKey().Key != ConsoleKey.Escape;
        }
    }
}