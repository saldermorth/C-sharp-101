using System;

// Basklasser och arvshierarki
public class Animal
{
    public string Name { get; set; }
}

public class Lion : Animal { }

public class Elephant : Animal
{
    public int TrunkLength { get; set; } // Snabellängd i cm
}

public class Monkey : Animal
{
    public bool CanClimb { get; set; }
}

public class Giraffe : Animal
{
    public int NeckLength { get; set; } // Halslängd i cm
}

public class Tiger : Animal
{
    public bool HasStripes { get; set; }
}

public class Leopard : Animal
{
    public int SpotCount { get; set; }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Lion { Name = "Simba" },
            new Elephant { Name = "Dumbo", TrunkLength = 60 },
            new Monkey { Name = "Rafiki", CanClimb = true },
            new Giraffe { Name = "Melman", NeckLength = 200 },
            new Tiger { Name = "Shere Khan", HasStripes = true },
            new Leopard { Name = "Bagheera", SpotCount = 50 }
        };

        Console.WriteLine("EXEMPEL 1: ANVÄNDNING AV CONST-MÖNSTER");
        Console.WriteLine("--------------------------------------");

        foreach (var animal in animals)
        {
            // Använder konstant-mönster för att matcha ett värde
            // Detta kontrollerar bara exakta värden
            switch (animal.Name)
            {
                case "Simba":
                    Console.WriteLine("Hittade lejonet Simba!");
                    break;
                case "Dumbo":
                    Console.WriteLine("Hittade elefanten Dumbo!");
                    break;
                case "Rafiki":
                    Console.WriteLine("Hittade apan Rafiki!");
                    break;
                default:
                    Console.WriteLine($"Hittade ett djur med namnet {animal.Name}");
                    break;
            }
        }

        Console.WriteLine("\nEXEMPEL 2: ANVÄNDNING AV PATTERN MATCHING");
        Console.WriteLine("------------------------------------------");

        foreach (var animal in animals)
        {
            // Använder pattern matching som kan matcha på typ, egenskaper och villkor
            // Detta är mycket kraftfullare än const-mönster
            string description = animal switch
            {
                // Typ-mönster med property-mönster och villkor
                Elephant { TrunkLength: > 50 } e => $"Stor elefant: {e.Name} med {e.TrunkLength} cm lång snabel",
                Elephant e => $"Elefant: {e.Name} med {e.TrunkLength} cm lång snabel",

                // Kapslade property-mönster
                Monkey { CanClimb: true } m => $"Klättrande apa: {m.Name}",
                Monkey m => $"Apa som inte klättrar: {m.Name}",

                // Kombination av typ och villkor med "and"
                Giraffe g when g.NeckLength > 150 => $"Giraff med lång hals: {g.Name} ({g.NeckLength} cm)",

                // Diskard-mönster med typ-mönster
                Tiger { HasStripes: true } _ => "En randig tiger",

                // Kombinera villkor med "or" (tillgängligt i C# 9.0+)
                Leopard l when l.SpotCount < 30 || l.SpotCount > 100 => "Ovanlig leopard",
                Leopard { SpotCount: 50 } l => $"Leopard med exakt 50 prickar: {l.Name}",

                // Typ-mönster som fallback
                Lion l => $"Ett lejon vid namn {l.Name}",

                // Fånga alla andra fall
                _ => "Okänt djur"
            };

            Console.WriteLine(description);
        }
    }
}