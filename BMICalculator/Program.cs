using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("BMI Calculator (kg, meters)");
            Console.Write("Weight (kg): ");
            if (!double.TryParse(Console.ReadLine(), out double weight) || weight <= 0)
            {
                Console.WriteLine("Invalid weight.");
                continue;
            }

            Console.Write("Height (m): ");
            if (!double.TryParse(Console.ReadLine(), out double height) || height <= 0)
            {
                Console.WriteLine("Invalid height.");
                continue;
            }

            double bmi = weight / Math.Pow(height, 2);
            string category = bmi switch
            {
                < 18.5 => "Underweight",
                < 25 => "Normal",
                < 30 => "Overweight",
                _ => "Obese"
            };

            Console.WriteLine($"BMI: {bmi:F2} ({category})");
            Console.WriteLine("Press Enter for next, Q to quit.");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToUpper() == "Q") break;
            Console.Clear();
        }
    }
}

