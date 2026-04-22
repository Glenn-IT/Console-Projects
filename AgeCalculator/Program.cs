using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Age Calculator");
            Console.Write("Birth year: ");
            if (!int.TryParse(Console.ReadLine(), out int by) || by < 1900 || by > DateTime.Now.Year)
            {
                Console.WriteLine("Invalid birth year.");
                continue;
            }

            Console.Write("Birth month (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out int bm) || bm < 1 || bm > 12)
            {
                Console.WriteLine("Invalid birth month.");
                continue;
            }

            Console.Write("Birth day (1-31): ");
            if (!int.TryParse(Console.ReadLine(), out int bd) || bd < 1 || bd > 31)
            {
                Console.WriteLine("Invalid birth day.");
                continue;
            }

            Console.Write("Current year: ");
            if (!int.TryParse(Console.ReadLine(), out int cy) || cy < by)
            {
                Console.WriteLine("Invalid current year.");
                continue;
            }

            Console.Write("Current month (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out int cm) || cm < 1 || cm > 12)
            {
                Console.WriteLine("Invalid current month.");
                continue;
            }

            Console.Write("Current day (1-31): ");
            if (!int.TryParse(Console.ReadLine(), out int cd) || cd < 1 || cd > 31)
            {
                Console.WriteLine("Invalid current day.");
                continue;
            }

            var birthDate = new DateTime(by, bm, bd);
            var currentDate = new DateTime(cy, cm, cd);
            int years = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-years)) years--;

            int months = currentDate.Month - birthDate.Month;
            if (currentDate.Day < birthDate.Day) months--;
            if (months < 0) { months += 12; years--; }

            int days = currentDate.Day - birthDate.Day;
            if (days < 0)
            {
                var lastMonth = currentDate.AddMonths(-1);
                days += DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);
            }

            Console.WriteLine($"Age: {years} years, {months} months, {days} days");
            Console.WriteLine("Press Enter for next, Q to quit.");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToUpper() == "Q") break;
            Console.Clear();
        }
    }
}

