using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime LastRestocked { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Category: {Category}, Quantity: {Quantity}, Price: {Price:C}, Last Restocked: {LastRestocked:d}";
    }
}

class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}

class Program
{
    static List<Product> inventory;
    static List<Supplier> suppliers;

    static void Main(string[] args)
    {
        InitializeData();

        // Exempel på en enkel query
        Console.WriteLine("Produkter i kategorin 'Verktyg':");
        var toolProducts = from p in inventory
                           where p.Category == "Verktyg"
                           select p;

        foreach (var product in toolProducts)
        {
            Console.WriteLine(product);
        }

        // Här kan du skriva dina Query Expressions för varje övning

        //Övning 1: Lista alla produkter i kategorin "Verktyg".

        //Övning 2: Hitta alla produkter som kostar mindre än 100 kr.

        //Övning 3: Sortera alla produkter efter pris, från lägsta till högsta.

        //Övning 4: Räkna hur många produkter som finns i kategorin "Säkerhetsutrustning".

        //Övning 5: Visa namnen på alla produkter som har fler än 100 i lager.

        //Övning 6: Gruppera produkterna efter kategori och visa antalet produkter i varje kategori.

        //Övning 7: Hitta den dyraste produkten i varje kategori.

        //Övning 8: Lista alla produkter som har blivit påfyllda (LastRestocked) under de senaste 30 dagarna.

        //Övning 9: Beräkna det totala lagervärdet (Quantity * Price) för alla produkter.

        //Övning 10: Hitta de tre produkterna med lägst lagersaldo (Quantity).

        //Övning 11: Skapa en rapport som visar kategori, antal produkter i kategorin, och det genomsnittliga priset för produkter i den kategorin.

        //Övning 12: Hitta produkter som behöver beställas (anta att en produkt behöver beställas om Quantity < 50) och sortera dem efter hur brådskande beställningen är (baserat på nuvarande Quantity).

        //Övning 13: För varje leverantör, lista alla länder de levererar från och antalet leverantörer per land.

        //Övning 14: Skapa en topplista över de 5 mest värdefulla produkterna baserat på deras totala lagervärde (Quantity * Price).

        //Övning 15: Generera en rapport som visar hur länge sedan varje produkt senast fylldes på (i dagar), sorterat från längst tid till kortast tid.

        //Övning 16: Skapa en pivottabell som visar antalet produkter per kategori och prisklass (t.ex. 0-100 kr, 101-500 kr, 501+ kr).

        //Övning 17: Identifiera produkter som kan vara överlagrade (anta att en produkt är överlagrad om dess Quantity > 200 och den inte har blivit påfylld de senaste 60 dagarna).

        Console.ReadLine();
    }

    static void InitializeData()
    {
        inventory = new List<Product>
        {
            new Product { Id = 1, Name = "Hammare", Category = "Verktyg", Quantity = 100, Price = 149.99m, LastRestocked = DateTime.Parse("2023-05-15") },
            new Product { Id = 2, Name = "Skruvmejsel", Category = "Verktyg", Quantity = 200, Price = 39.99m, LastRestocked = DateTime.Parse("2023-06-01") },
            new Product { Id = 3, Name = "Borrmaskin", Category = "Elverktyg", Quantity = 50, Price = 799.99m, LastRestocked = DateTime.Parse("2023-04-10") },
            new Product { Id = 4, Name = "Spik 100-pack", Category = "Fästmaterial", Quantity = 500, Price = 29.99m, LastRestocked = DateTime.Parse("2023-06-10") },
            new Product { Id = 5, Name = "Skruv 100-pack", Category = "Fästmaterial", Quantity = 600, Price = 39.99m, LastRestocked = DateTime.Parse("2023-06-05") },
            new Product { Id = 6, Name = "Målarpensel", Category = "Måleriutrustning", Quantity = 150, Price = 59.99m, LastRestocked = DateTime.Parse("2023-05-20") },
            new Product { Id = 7, Name = "Färgroller", Category = "Måleriutrustning", Quantity = 100, Price = 79.99m, LastRestocked = DateTime.Parse("2023-05-22") },
            new Product { Id = 8, Name = "Skyddsglasögon", Category = "Säkerhetsutrustning", Quantity = 200, Price = 129.99m, LastRestocked = DateTime.Parse("2023-04-25") },
            new Product { Id = 9, Name = "Hörselskydd", Category = "Säkerhetsutrustning", Quantity = 150, Price = 199.99m, LastRestocked = DateTime.Parse("2023-04-26") },
            new Product { Id = 10, Name = "Cirkelsåg", Category = "Elverktyg", Quantity = 30, Price = 1299.99m, LastRestocked = DateTime.Parse("2023-03-15") },
            new Product { Id = 11, Name = "Multimeter", Category = "Elverktyg", Quantity = 40, Price = 399.99m, LastRestocked = DateTime.Parse("2023-05-05") },
            new Product { Id = 12, Name = "Vattenpass", Category = "Verktyg", Quantity = 80, Price = 89.99m, LastRestocked = DateTime.Parse("2023-05-10") },
            new Product { Id = 13, Name = "Arbetshandskar", Category = "Säkerhetsutrustning", Quantity = 300, Price = 49.99m, LastRestocked = DateTime.Parse("2023-06-02") },
            new Product { Id = 14, Name = "Murslev", Category = "Verktyg", Quantity = 60, Price = 69.99m, LastRestocked = DateTime.Parse("2023-05-18") },
            new Product { Id = 15, Name = "Målarfärg 10L", Category = "Måleriutrustning", Quantity = 40, Price = 449.99m, LastRestocked = DateTime.Parse("2023-05-25") }
        };

        suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "ToolMaster AB", Country = "Sverige" },
            new Supplier { Id = 2, Name = "ElectroTools GmbH", Country = "Tyskland" },
            new Supplier { Id = 3, Name = "SafetyFirst Ltd", Country = "Storbritannien" },
            new Supplier { Id = 4, Name = "PaintPro Inc", Country = "USA" },
            new Supplier { Id = 5, Name = "FastenRight Co", Country = "Kanada" }
        };
    }
}