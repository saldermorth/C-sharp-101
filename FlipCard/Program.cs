using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class FlashCard
{
    public string Question { get; set; }
    public string Answer { get; set; }
}

class Program
{
    static void Main()
    {
        string filePath = "combined_csharp_azure_quiz.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("JSON file not found. Make sure it's in the same folder as the executable.");
            return;
        }

        // Deserialize with case-insensitive property names
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var json = File.ReadAllText(filePath);
        var allCards = JsonSerializer.Deserialize<List<FlashCard>>(json, options);

        if (allCards == null || allCards.Count == 0)
        {
            Console.WriteLine("No valid flashcards found in JSON.");
            return;
        }

        // Filter invalid entries
        allCards.RemoveAll(c => string.IsNullOrWhiteSpace(c.Question) || string.IsNullOrWhiteSpace(c.Answer));

        Console.Clear();
        Console.WriteLine($"📘 Loaded {allCards.Count} flashcards.\n");
        Console.WriteLine("Press ENTER to start studying...");
        Console.ReadKey(true);

        var random = new Random();
        var remaining = new List<FlashCard>(allCards);

        int round = 1;

        while (remaining.Any())
        {
            Console.Clear();
            Console.WriteLine($"🔁 Round {round} — {remaining.Count} card(s) left to master!\n");

            // Shuffle remaining cards each round
            var cards = remaining.OrderBy(_ => random.Next()).ToList();
            var failed = new List<FlashCard>();

            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                Console.Clear();
                Console.WriteLine($"🃏 Card {i + 1}/{cards.Count}");
                Console.WriteLine("\nQUESTION:");
                Console.WriteLine(card.Question);
                Console.WriteLine("\nPress ENTER to show the answer...");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q) return;

                Console.WriteLine("\n💡 ANSWER:");
                Console.WriteLine(card.Answer);
                Console.WriteLine("\nDid you know the answer? (Y/N, Q=quit)");

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q) return;
                if (key.Key != ConsoleKey.Y)
                    failed.Add(card);
            }

            if (failed.Any())
            {
                Console.Clear();
                Console.WriteLine($"❌ You missed {failed.Count} card(s). Let’s try them again.\n");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey(true);
                remaining = failed;
                round++;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("🎉 Congratulations! You mastered all flashcards!");
                break;
            }
        }

        Console.WriteLine("\n✅ Session complete! Press any key to exit...");
        Console.ReadKey();
    }
}
