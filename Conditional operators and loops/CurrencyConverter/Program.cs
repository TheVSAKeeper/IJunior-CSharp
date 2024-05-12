using System;

namespace CurrencyConverter;

internal static class Program
{
    private static void Main()
    {
        const string RubToUsdCommand = "rub-usd";
        const string RubToEurCommand = "rub-eur";
        const string UsdToRubCommand = "usd-rub";
        const string UsdToEurCommand = "usd-eur";
        const string EurToRubCommand = "eur-rub";
        const string EurToUsdCommand = "eur-usd";
        
        const string Rubles = "RUB";
        const string Dollars = "USD";
        const string Euro = "EUR";

        const string CommandsMessage = "{0} - Конвертировать {1} в {2} (курс {3:f4})";
        const string NotEnoughCurrencyError = "На балансе недостаточно средств {0}.";
        const string AvailableForConversion = "Доступно для конвертации {0} {1}.";
        const string SumForConversionRequest = "Часть баланса для конвертации: ";

        const string BalanceMessage = $"\nРублей ({Rubles}): {{0}}\n"
                                      + $"Долларов ({Dollars}): {{1}}\n"
                                      + $"Евро ({Euro}): {{2}}\n\n";
        double usdToRubRate = 98.0;
        double eurToRubRate = 102.0;
        double usdToEurRate = 1.1;

        double rubToUsdRate = 1 / usdToRubRate;
        double rubToEurRate = 1 / eurToRubRate;
        double eurToUsdRate = 1 / usdToEurRate;

        double balanceInRubles = 100.1;
        double balanceInDollars = 100.2;
        double balanceInEuros = 500.1;

        bool isWorking = true;

        ConsoleKey exitKey = ConsoleKey.Q;

        while (isWorking)
        {
            Console.Clear();

            Console.WriteLine(BalanceMessage, balanceInRubles, balanceInDollars, balanceInEuros);

            Console.WriteLine(CommandsMessage, RubToUsdCommand, Rubles, Dollars, rubToUsdRate);
            Console.WriteLine(CommandsMessage, RubToEurCommand, Rubles, Euro, rubToEurRate);
            Console.WriteLine(CommandsMessage, UsdToRubCommand, Dollars, Rubles, usdToRubRate);
            Console.WriteLine(CommandsMessage, UsdToEurCommand, Dollars, Euro, usdToEurRate);
            Console.WriteLine(CommandsMessage, EurToRubCommand, Euro, Rubles, eurToRubRate);
            Console.WriteLine(CommandsMessage, EurToUsdCommand, Euro, Dollars, eurToUsdRate);

            Console.Write("\nВведите команду из списка: ");
            string enteredCommand = Console.ReadLine()?.ToLower() ?? string.Empty;

            double partOfBalanceForConversion;

            switch (enteredCommand)
            {
                case RubToUsdCommand:
                    Console.WriteLine(AvailableForConversion, balanceInRubles, Rubles);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInRubles)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Rubles);
                        break;
                    }

                    balanceInDollars += partOfBalanceForConversion * rubToUsdRate;
                    balanceInRubles -= partOfBalanceForConversion;
                    break;

                case RubToEurCommand:
                    Console.WriteLine(AvailableForConversion, balanceInRubles, Rubles);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInRubles)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Rubles);
                        break;
                    }

                    balanceInEuros += partOfBalanceForConversion * rubToEurRate;
                    balanceInRubles -= partOfBalanceForConversion;
                    break;

                case UsdToRubCommand:
                    Console.WriteLine(AvailableForConversion, balanceInDollars, Dollars);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInDollars)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Dollars);
                        break;
                    }

                    balanceInRubles += partOfBalanceForConversion * usdToRubRate;
                    balanceInDollars -= partOfBalanceForConversion;
                    break;

                case UsdToEurCommand:
                    Console.WriteLine(AvailableForConversion, balanceInDollars, Dollars);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInDollars)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Dollars);
                        break;
                    }

                    balanceInEuros += partOfBalanceForConversion * usdToEurRate;
                    balanceInDollars -= partOfBalanceForConversion;
                    break;

                case EurToRubCommand:
                    Console.WriteLine(AvailableForConversion, balanceInEuros, Euro);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInEuros)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Euro);
                        break;
                    }

                    balanceInRubles += partOfBalanceForConversion * eurToRubRate;
                    balanceInEuros -= partOfBalanceForConversion;
                    break;

                case EurToUsdCommand:
                    Console.WriteLine(AvailableForConversion, balanceInEuros, Euro);

                    Console.Write(SumForConversionRequest);
                    partOfBalanceForConversion = double.Parse(Console.ReadLine() ?? string.Empty);

                    if (partOfBalanceForConversion > balanceInEuros)
                    {
                        Console.WriteLine(NotEnoughCurrencyError, Euro);
                        break;
                    }

                    balanceInDollars += partOfBalanceForConversion * eurToUsdRate;
                    balanceInEuros -= partOfBalanceForConversion;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }

            Console.WriteLine(BalanceMessage, balanceInRubles, balanceInDollars, balanceInEuros);
            Console.WriteLine($"Нажмите {exitKey}, чтобы выйти, или любую клавишу, чтобы продолжить.");

            isWorking = Console.ReadKey().Key != exitKey;
        }
    }
}