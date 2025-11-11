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

    public class ProduktKatalog2
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

    // En indexer i C# låter dig göra ett objekt åtkomligt som en array eller lista,
    // alltså med hakparenteser [], fast du själv bestämmer hur det fungerar.
    public class ProduktKatalog
    {
        //Ny lista av produkter
        private List<Produkt> produkter = new();

        // Ge åtkomst till Count genom Antal
        public int Antal => produkter.Count;

        //Egen metod där vi hanterar adderingar till listan
        public void LäggTill(Produkt produkt)
        {
            // Om användaren skickar in null kastar vi ett fel
            if (produkt == null)
                throw new ArgumentNullException("du skickade in null" + nameof(produkt));

            // Vi letar efter en match till produktens namn. Om ingen hittas kastar vi ett fel
            if (produkter.Any(p => p.Namn == produkt.Namn))
                throw new Exception($"Produkten '{produkt.Namn}' finns redan.");

            // Om det inte är en dublett lägger vi till i listan
            produkter.Add(produkt);
        }

        // Indexer för position (int) Liknar en egenskap (property), men använder hakparenteser i stället för ett namn.
        public Produkt this[int index]
        {
            get
            {
                if (index < 0 || index >= produkter.Count)
                    throw new IndexOutOfRangeException();
                return produkter[index];
            }
        }

        // Indexer för produktnamn (string) Liknar en egenskap (property), men använder hakparenteser i stället för ett namn.
        public Produkt this[string namn]
        {
            get
            {
                // Leta i listan efter matchande namn ta första matchande
                var produkt = produkter.FirstOrDefault(p => p.Namn == namn);
                // Om vi inte hittar något kasta ett fel
                if (produkt == null)
                    throw new Exception($"Produkten '{namn}' hittades inte.");

                // Annars returnera produkten
                return produkt;
            }
            set
            {
                // Leta i listan efter matchande namn ta första matchande. Om en produkt hittas kasta ett fel
                var index = produkter.FindIndex(p => p.Namn == namn);
                if (index == -1)
                    throw new Exception($"Produkten '{namn}' hittades inte.");

                // Annars ersätter den gamla produkten på det indexet med den nya produkten (value).
                produkter[index] = value;
            }
        }
    }
}