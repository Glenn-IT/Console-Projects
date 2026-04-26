using System;

class Program
{
    private static readonly Random rand = new();
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("🤡 Funny Number Guesser (1-100, secret is random each game!)");
            int target = rand.Next(1, 101);
            int attempts = 0;
            string[] lowJokes = {"Oof, that's low! Did you drop your phone?", "Aim higher – like your goals!", "Too low, channel your inner giraffe!"};
            string[] highJokes = {"Way high! Everest called, wants its height back.", "Too high, calm your jetpack.", "Lower – gravity is calling!"};
            string[] winJokes = {"Nailed it – cookie for you! 🍪", "Wizard! 🎩", "42 vibes? Nah, you guessed " + target + "!", "Beat the machine. Human 1, AI 0."};

            while (true)
            {
                Console.Write("Guess: ");
                if (!int.TryParse(Console.ReadLine(), out int guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Invalid! 1-100 or I'll laugh. 😂");
                    continue;
                }

                attempts++;
                if (guess < target)
                {
                    Console.WriteLine(lowJokes[rand.Next(lowJokes.Length)]);
                }
                else if (guess > target)
                {
                    Console.WriteLine(highJokes[rand.Next(highJokes.Length)]);
                }
                else
                {
                    Console.WriteLine(winJokes[rand.Next(winJokes.Length)]);
                    Console.WriteLine($"Took {attempts} tries. Secret was {target}!");
                    break;
                }
            }

            Console.WriteLine("New game? Enter or Q to quit.");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToUpper() == "Q") break;
            Console.Clear();
        }
    }
}

