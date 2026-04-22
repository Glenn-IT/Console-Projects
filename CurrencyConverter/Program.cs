using System;
using System.Collections.Generic;

class Program
{
    private static readonly Dictionary<string, double> Rates = new()
    {
        {"USD", 1.0},
        {"PHP", 58.0}, // 1 USD = 58 PHP
        {"SGD", 1.35}, // 1 USD = 1.35 SGD
        {"EUR", 0.92}, // 1 USD = 0.92 EUR
        {"GBP", 0.78}, // 1 USD = 0.78 GBP
        {"JPY", 150.0}, // 1 USD = 150 JPY
        {"AUD", 1.50}, // 1 USD = 1.50 AUD
        {"CAD", 1.38} // 1 USD = 1.38 CAD
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Currency Converter (USD base)");
            Console.WriteLine("Supported: USD, PHP, SGD, EUR, GBP, JPY, AUD, CAD");
            Console.Write("Enter amount: ");
            if (!double.TryParse(Console.ReadLine(), out double amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                continue;
            }

            Console.Write("From (e.g. PHP): ");
            string? fromInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fromInput))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            string from = fromInput.Trim().ToUpper();
            if (!Rates.ContainsKey(from))
            {
                Console.WriteLine("Invalid from currency.");
                continue;
            }

            Console.Write("To (e.g. USD): ");
            string? toInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(toInput))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            string to = toInput.Trim().ToUpper();
            if (!Rates.ContainsKey(to))
            {
                Console.WriteLine("Invalid to currency.");
                continue;
            }

            double usdAmount = amount / Rates[from];
            double result = usdAmount * Rates[to];
            Console.WriteLine($"{amount} {from} = {result:F2} {to}");
            Console.WriteLine("Press Enter for next, Q to quit.");
            string? quitInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(quitInput) && quitInput.Trim().ToUpper() == "Q") break;
            Console.Clear();
        }
    }
}

