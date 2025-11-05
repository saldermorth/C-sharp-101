using System;
using System.Collections.Generic;
using System.Linq;



class Program
{
    static List<Animal> animals;
    static List<Breeder> breeders;

    static void Main(string[] args)
    {
        InitializeData();

        // Exempel på en enkel query
        Console.WriteLine("Djur i arten 'Kattdjur':");

        foreach (var animal in animals.Where(a => a.Species == "Kattdjur"))
        {
            Console.WriteLine($"{animal.Name} ({animal.Species})");
        }

        // Övning 1: Lista alla djur i arten "Kattdjur".
        var ovning1 = animals.Where(a => a.Species == "Kattdjur");

        // Övning 2: Hitta alla djur som väger mindre än 100 kg.
        var ovning2 = animals.Where(a => a.Weight < 100);

        // Övning 3: Sortera alla djur efter vikt, från lättast till tyngst.
        var ovning3 = animals.OrderBy(a => a.Weight);

        // Övning 4: Räkna hur många djur som finns i arten "Björn".
        var ovning4 = animals.Count(a => a.Species == "Björn");

        // Övning 5: Visa namnen på alla djur som är äldre än 10 år.
        var ovning5 = animals.Where(a => a.Age > 10).Select(a => a.Name);

        // Övning 6: Gruppera djuren efter art och visa antalet djur i varje art.
        var ovning6 = animals.GroupBy(a => a.Species)
                             .Select(g => new { Art = g.Key, Antal = g.Count() });

        // Övning 7: Hitta det tyngsta djuret i varje art.
        var ovning7 = animals.GroupBy(a => a.Species)
                             .Select(g => g.OrderByDescending(a => a.Weight).First());

        // Övning 8: Lista alla djur som haft veterinärkontroll de senaste 30 dagarna.
        var ovning8 = animals.Where(a => (DateTime.Now - a.LastCheckup).TotalDays <= 30);

        // Övning 9: Beräkna total kroppsvikt för alla djur.
        var ovning9 = animals.Sum(a => a.Weight);

        // Övning 10: Hitta de tre djuren med lägst vikt.
        var ovning10 = animals.OrderBy(a => a.Weight).Take(3);

        // Övning 11: Rapport med art, antal djur och genomsnittlig vikt.
        var ovning11 = animals.GroupBy(a => a.Species)
                              .Select(g => new { Art = g.Key, Antal = g.Count(), Medelvikt = g.Average(a => a.Weight) });

        // Övning 12: Djur som behöver hälsokontroll (t.ex. om senaste > 180 dagar) och sortera efter hur länge sedan.
        var ovning12 = animals.Where(a => (DateTime.Now - a.LastCheckup).TotalDays > 180)
                              .OrderByDescending(a => (DateTime.Now - a.LastCheckup).TotalDays);

        // Övning 13: Lista länder där uppfödare finns och antalet uppfödare per land.
        var ovning13 = breeders.GroupBy(b => b.Country)
                               .Select(g => new { Land = g.Key, Antal = g.Count() });

        // Övning 14: Topplista över de 5 tyngsta djuren.
        var ovning14 = animals.OrderByDescending(a => a.Weight).Take(5);

        // Övning 15: Rapport över hur länge sedan varje djur hade kontroll, sorterat från längst till kortast.
        var ovning15 = animals.Select(a => new { a.Name, DagarSedan = (DateTime.Now - a.LastCheckup).Days })
                              .OrderByDescending(x => x.DagarSedan);

        // Övning 16: Pivottabell över antal djur per art och viktklass.
        var ovning16 = animals.GroupBy(a => new
        {
            a.Species,
            Viktklass = a.Weight < 100 ? "Lätt (<100kg)" :
                        a.Weight <= 500 ? "Medel (100–500kg)" : "Tung (>500kg)"
        })
        .Select(g => new { g.Key.Species, g.Key.Viktklass, Antal = g.Count() });

        // Övning 17: Identifiera djur som är "överviktiga" (Weight > 200 och senaste kontroll > 60 dagar).
        var ovning17 = animals.Where(a => a.Weight > 200 && (DateTime.Now - a.LastCheckup).TotalDays > 60);

        // Utskriftsexempel (valfritt)
        Console.WriteLine("\nÖvning 6 – Antal djur per art:");
        foreach (var item in ovning6)
        {
            Console.WriteLine($"{item.Art}: {item.Antal}");
        }

        Console.ReadLine();



    }

    static void InitializeData()
    {
        animals = new List<Animal>();

        for (int i = 0; i < 3; i++)
        {
            int offset = i * 15; // 15 djur per uppsättning
            animals.AddRange(new List<Animal>
        {
            new Animal { Id = 1 + offset, Name = "Lejon", Species = "Kattdjur", Age = 8, Weight = 190.5, LastCheckup = DateTime.Parse("2023-05-15") },
            new Animal { Id = 2 + offset, Name = "Elefant", Species = "Elefantdjur", Age = 25, Weight = 5200.3, LastCheckup = DateTime.Parse("2023-06-01") },
            new Animal { Id = 3 + offset, Name = "Giraff", Species = "Partåiga hovdjur", Age = 12, Weight = 800.7, LastCheckup = DateTime.Parse("2023-04-10") },
            new Animal { Id = 4 + offset, Name = "Zebra", Species = "Hästdjur", Age = 9, Weight = 380.2, LastCheckup = DateTime.Parse("2023-06-10") },
            new Animal { Id = 5 + offset, Name = "Noshörning", Species = "Uddatåiga hovdjur", Age = 18, Weight = 2400.9, LastCheckup = DateTime.Parse("2023-06-05") },
            new Animal { Id = 6 + offset, Name = "Pingvin", Species = "Fåglar", Age = 5, Weight = 12.3, LastCheckup = DateTime.Parse("2023-05-20") },
            new Animal { Id = 7 + offset, Name = "Isbjörn", Species = "Björn", Age = 14, Weight = 480.8, LastCheckup = DateTime.Parse("2023-05-22") },
            new Animal { Id = 8 + offset, Name = "Känguru", Species = "Pungdjur", Age = 7, Weight = 65.5, LastCheckup = DateTime.Parse("2023-04-25") },
            new Animal { Id = 9 + offset, Name = "Flodhäst", Species = "Partåiga hovdjur", Age = 22, Weight = 3400.6, LastCheckup = DateTime.Parse("2023-04-26") },
            new Animal { Id = 10 + offset, Name = "Krokodil", Species = "Kräldjur", Age = 30, Weight = 900.4, LastCheckup = DateTime.Parse("2023-03-15") },
            new Animal { Id = 11 + offset, Name = "Tiger", Species = "Kattdjur", Age = 10, Weight = 220.1, LastCheckup = DateTime.Parse("2023-05-05") },
            new Animal { Id = 12 + offset, Name = "Panda", Species = "Björndjur", Age = 13, Weight = 110.9, LastCheckup = DateTime.Parse("2023-05-10") },
            new Animal { Id = 13 + offset, Name = "Lemur", Species = "Primater", Age = 6, Weight = 2.4, LastCheckup = DateTime.Parse("2023-06-02") },
            new Animal { Id = 14 + offset, Name = "Sjölejon", Species = "Säl", Age = 11, Weight = 290.7, LastCheckup = DateTime.Parse("2023-05-18") },
            new Animal { Id = 15 + offset, Name = "Papegoja", Species = "Fåglar", Age = 4, Weight = 1.1, LastCheckup = DateTime.Parse("2023-05-25") }
        });
        }

        breeders = new List<Breeder>
    {
        new Breeder { Id = 1, Name = "Savanna Wildlife AB", Country = "Sverige" },
        new Breeder { Id = 2, Name = "African Nature Ltd", Country = "Kenya" },
        new Breeder { Id = 3, Name = "Arctic Habitat Oy", Country = "Finland" },
        new Breeder { Id = 4, Name = "Rainforest Conservation", Country = "Brasilien" },
        new Breeder { Id = 5, Name = "Aussie Fauna Co", Country = "Australien" }
    };
    }
    class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public DateTime LastCheckup { get; set; }
    }
    class Breeder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }


}

