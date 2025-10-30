using System;

namespace ExceptionRising
{
    internal class Program
    {
        // Main måste vara static och public
        static void Main(string[] args)
        {
            // Skapa en instans av Program för att kunna anropa instansmetoderna
            Program program = new Program();

            try
            {
                program.FirstMethod();
            }
            catch (Exception ex)
            {
                // Undantaget fångas här om det inte hanteras i anropskedjan
                Console.WriteLine($"Huvudmetoden fångade undantaget: {ex.Message}");
            }

            // Håll konsolfönstret öppet
            Console.WriteLine("\nTryck på en tangent för att avsluta...");
            Console.ReadKey();
        }

        void FirstMethod()
        {
            // Ingen try-catch här, så undantag "bubblar" uppåt
            SecondMethod();
        }

        void SecondMethod()
        {
            try
            {
                ThirdMethod();
            }
            catch (ArgumentException ex)
            {
                // Fångar bara ArgumentException
                Console.WriteLine($"SecondMethod fångade ArgumentException: {ex.Message}");
            }
            // Andra typer av undantag bubblar uppåt
        }

        void ThirdMethod()
        {
            // Kastas olika typer av undantag
            if (DateTime.Now.Second % 3 == 0)
                throw new ArgumentException("Ogiltigt argument");
            else if (DateTime.Now.Second % 3 == 1)
                throw new InvalidOperationException("Ogiltig operation");
            else
                throw new NotImplementedException("Inte implementerad");
        }
    }
}