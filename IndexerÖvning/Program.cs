namespace IndexerÖvning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa några produkter
            Console.WriteLine("== Produkthantering ==");

            // Vanlig lista med produkter
            List<Produkt> produkter = new();
            produkter.Add(null); // Tillåtet
            produkter.Add(new Produkt("Laptop", 9999));
            produkter.Add(new Produkt("Laptop", 8999)); // Dubblett tillåten

            Console.WriteLine("Standard lista:");
            foreach (var p in produkter)
            {
                Console.WriteLine(p?.Namn + " - " + p?.Pris + " kr");
            }

            // Din uppgift: Implementera ProduktKatalog klassen nedan
            // så att den fungerar enligt exemplet
            Console.WriteLine("\nProduktKatalog:");
            var katalog = new ProduktKatalog();
            katalog.LäggTill(new Produkt("Mobil", 5999));
            katalog.LäggTill(new Produkt("Tangentbord", 899));

            try
            {
                katalog.LäggTill(new Produkt("Mobil", 4999)); // Ska kasta fel - produktnamn finns redan
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel: {ex.Message}");
            }

            // Använd indexer för att hämta produkt på position
            Console.WriteLine(katalog[0].Namn + " - " + katalog[0].Pris + " kr"); // Mobil - 5999 kr
            Console.WriteLine(katalog[1].Namn + " - " + katalog[1].Pris + " kr"); // Tangentbord - 899 kr

            // Använd indexer med sträng för att söka efter produktnamn
            Console.WriteLine(katalog["Mobil"].Pris + " kr"); // 5999 kr

            Console.WriteLine("Antal produkter: " + katalog.Antal); // Antal produkter: 2

            // Bonus: Implementera möjligheten att uppdatera pris via indexer
            katalog["Mobil"] = new Produkt("Mobil", 6499);
            Console.WriteLine("Nytt pris: " + katalog["Mobil"].Pris + " kr"); // Nytt pris: 6499 kr
        }
    }

    public class Produkt
    {
        public string Namn { get; }
        public decimal Pris { get; }

        public Produkt(string namn, decimal pris)
        {
            Namn = namn;
            Pris = pris;
        }
    }

    public class ProduktKatalog
    {
        // Implementera den här klassen så att koden i Main fungerar
        // Tips: Du behöver:
        // 1. En privat lista för att lagra produkter
        // 2. En LäggTill metod som kontrollerar dubletter baserat på namn
        // 3. En indexer som tar int och returnerar Produkt
        // 4. En indexer som tar string (produktnamn) och returnerar Produkt
        // 5. En egenskap som ger antal produkter
        // Bonus: Gör så att string-indexern också kan användas för att uppdatera en produkt
    }
}